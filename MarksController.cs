using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarksApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MicroserviceController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public MicroserviceController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("StudentsServiceClient");
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetStudentsFromOtherMicroservice()
    {
        try
        {
            // Make a request to the Students microservice's endpoint
            var response = await _httpClient.GetAsync("https://localhost:7130/Students");

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read and return the response content
                var students = await response.Content.ReadFromJsonAsync<Student[]>();
                return Ok(students);
            }
            else
            {
                // Handle error cases
                return StatusCode((int)response.StatusCode, "Error retrieving students");
            }
        }
        catch (HttpRequestException)
        {
            // Handle network-related errors
            return StatusCode(500, "Error communicating with the Students microservice");
        }
    }

    // Other actions for the microservice can be added here

    public class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
    }
}

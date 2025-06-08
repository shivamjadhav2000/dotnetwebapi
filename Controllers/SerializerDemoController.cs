using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

[Route("api/serialization")]
[ApiController]
public class SerializationController : ControllerBase
{
    private readonly Person person = new Person { UserName = "shivamjadhav", Age = 25, Gender = "Male", Email = "Jadhavshivam0228@gmail.com" };

    [HttpGet("manual-json")]
    public IActionResult GetManual()
    {
        var jsonString = JsonSerializer.Serialize(person);
        return Content(jsonString, "application/json");
    }
    [HttpGet("custom-json")]
    public IActionResult GetCustom()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
        var jsonString = JsonSerializer.Serialize(person, options);
        return Content(jsonString, "application/json");
    }
    [HttpGet("json")]
    public IActionResult GetJson()
    {
        return new JsonResult(person);
    }

    [HttpGet("auto")]
    public Person GetAuto()
    {
        return person;
    }
    [HttpPost("auto")]
    public Person createPersonAuto(Person person)
    {
        return person;
    }
    [HttpPost("json")]
    public async Task<IActionResult> CreatePerson()
    {
        var person = await Request.ReadFromJsonAsync<Person>();
        if (person == null)
        {
            return BadRequest();
        }
        return new JsonResult(person);
    }
    [HttpPost("custom-json")]
    public async Task<IActionResult> CustomJson()
    {
        var options = new JsonSerializerOptions
        {
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
        };
        var person = await Request.ReadFromJsonAsync<Person>(options);
        return new JsonResult(person);
    }

}

public class Person {
    required public string UserName { get; set; }
    required public int Age { get; set; }
    required public string Gender { get; set; }
    public string? Email { get; set; }
}
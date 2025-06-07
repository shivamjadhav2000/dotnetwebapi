using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]

public class ErrorHandlingController : ControllerBase
{
    [HttpGet("error")]
    public IActionResult GetDivisionResult(int numerator, int denominator)
    {
        try
        {
            var result = numerator / denominator;
            return Ok("Here is the result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by Zero is not allowed.");
            return BadRequest("Cannot divide by zero.");

        }
    }

}
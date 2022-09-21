using Microsoft.AspNetCore.Mvc;

namespace cursoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorldService,ILogger<HelloWorldController> _logger)
    {
        this.helloWorldService = helloWorldService;   
        this._logger = _logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("imprimiendo Hola Mundo");
        return Ok(helloWorldService.GetSaludo());
    }
}
using Microsoft.AspNetCore.Mvc;

namespace tutsica.Controllers;

[ApiController]
[Route("[controller]")]
public class TutsController : ControllerBase
{

    private readonly ILogger<TutsController> _logger;

    public TutsController(ILogger<TutsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTuts")]
    public IEnumerable<int> Get()
    {
        return Enumerable.Range(1, 5).ToArray();
    }
}

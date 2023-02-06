using ServerApplication.Services;
using ServerApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServerApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class FixtureController : ControllerBase
{
    FixtureService _service;
    public FixtureController(FixtureService service)
    {
        _service = service;
    }

    
    [HttpGet]
    public ActionResult<IEnumerable<Fixture>> GetAllFixtures()
    {
        return _service.GetAllFixtures().ToArray();
    }
    [HttpPost]
    public IActionResult CreateFixture(Fixture newFixture)
    {
        var fixture = _service.CreateFixture(newFixture);
        if (fixture is null) return BadRequest("Used FixtureId (FId)");
        return CreatedAtAction(nameof(GetFixture), new { id = fixture!.Id }, fixture);
    }
    [HttpGet("{id}")]
    public ActionResult<Fixture> GetFixture(int id)
    {
        var fixture = _service.GetFixture(id);
        if (fixture is null) return NotFound("Id Not Found");
        return fixture;
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteFixture(int id)
    {
        var isDeleted = _service.DeleteFixture(id); 
        if (!isDeleted) return NotFound("Id Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpPut("{id}")]
    public IActionResult UpdateFixture(int id, Fixture newFixture){
        var isUpdated = _service.UpdateFixture(id, newFixture);
        if (!isUpdated) return NotFound("Id Not Found");
        return Ok("Succesfully updated.");
    }
    [HttpGet("fId/{fId}")]
    public ActionResult<IEnumerable<Fixture>> GetFixtureByFId(string fId)
    {
        return _service.GetFixtureByFId(fId);
    }
    [HttpGet("type/{type}")]
    public ActionResult<IEnumerable<Fixture>> GetFixtureByType(string type)
    {
        return _service.GetFixtureByType(type);
    }
    [HttpGet("brand/{brand}")]
    public ActionResult<IEnumerable<Fixture>> GetFixtureByBrand(string brand)
    {
        return _service.GetFixtureByBrand(brand);
    }
    [HttpGet("model/{model}")]
    public ActionResult<IEnumerable<Fixture>> GetFixtureByModel(string model)
    {
        return _service.GetFixtureByModel(model);
    }
}
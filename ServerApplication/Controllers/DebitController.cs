using ServerApplication.Services;
using ServerApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServerApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class DebitController : ControllerBase
{
    DebitService _service;
    public DebitController(DebitService service)
    {
        _service = service;
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Debit>> GetAllDebits()
    {
        return _service.GetAllDebits().ToArray(); 
    }
    [HttpPost]
    public IActionResult CreateDebit(Debit newDebit)
    {
        var debit = _service.CreateDebit(newDebit);
        if (debit is null) return BadRequest("Poblematic FixtureId or PersonnelId");
        return CreatedAtAction("CreateDebit", debit.Id, debit);
    }
    [HttpGet("{id}")]
    public ActionResult<Debit> GetDebit(int id)
    {
        var debit = _service.GetDebit(id);
        if(debit is null) return NotFound("Id Not Found");
        return debit;
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteDebit(int id)
    {
        var isDeleted = _service.DeleteDebit(id);
        if(!isDeleted) return NotFound("Id Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpPut("{id}")]
    public IActionResult UpdateDebit(int id, Debit newDebit){
        var isUpdated = _service.UpdateDebit(id, newDebit);
        if(!isUpdated) return NotFound("Id Not Found");
        return Ok("Succesfully Updated");
    }
    [HttpGet("pId/{pId}")]
    public ActionResult<IEnumerable<Debit>> GetDebitsByPId(int pId)
    {
        return _service.GetDebitsByPId(pId);
    }
    [HttpPut("pId/{pId}")]
    public ActionResult UpdateDebitsByPId(int pId, Personnel personnel)
    {
        var isUpdated = _service.UpdateDebitsByPId(pId, personnel); 
        if(!isUpdated) return NotFound("Id Not Found");
        return Ok("Succesfully Updated"); 
    }
    [HttpGet("peId/{peId}")]
    public ActionResult<IEnumerable<Debit>> GetDebitsByPeId(string peId)
    {
        return _service.GetDebitsByPId(peId);
    }
    [HttpDelete("pId/{pId}")]
    public IActionResult DeleteDebitByPId(int pId)
    {
        var isDeleted = _service.DeleteDebitByPId(pId);
        if(!isDeleted) return NotFound("pId Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpDelete("peId/{peId}")]
    public IActionResult DeleteDebitByPId(string peId)
    {
        var isDeleted = _service.DeleteDebitByPId(peId);
        if(!isDeleted) return NotFound("peId Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpGet("fId/{fId}")]
    public ActionResult<Debit> GetDebitByFId(int fId)
    {
        return _service.GetDebitByFId(fId);
    }
    [HttpPut("fId/{fId}")]
    public ActionResult<IEnumerable<Debit>> SetDebitsByFId(int fId, string fixtureId)
    {
        var isUpdated = _service.SetDebitByFId(fId, fixtureId); 
        if(!isUpdated) return NotFound("Id Not Found");
        return Ok("Succesfully Updated");
    }
    [HttpGet("feId/{feId}")]
    public ActionResult<Debit> GetDebitByFeId(string feId)
    {
        return _service.GetDebitByFId(feId);
    }
    [HttpDelete("fId/{fId}")]
    public IActionResult DeleteDebitByFId(int fId)
    {
        var isDeleted = _service.DeleteDebitByFId(fId);
        if(!isDeleted) return NotFound("pId Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpDelete("feId/{feId}")]
    public IActionResult DeleteDebitByFId(string feId)
    {
        var isDeleted = _service.DeleteDebitByFId(feId);
        if(!isDeleted) return NotFound("feId Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpGet("taken/{isTaken}")]
    public ActionResult<IEnumerable<Debit>> GetDebitsByTaken(bool isTaken)
    {
        return _service.GetDebitsByTaken(isTaken);
    }

}
using ServerApplication.Services;
using ServerApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServerApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonnelController : ControllerBase
{
    PersonnelService _service;
    public PersonnelController(PersonnelService service)
    {
        _service = service;
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Personnel>> GetAllPersonnels()
    {
        return _service.GetAllPersonnels().ToArray();
    }
    [HttpPost]
    public IActionResult CreatePersonnel(Personnel newPersonnel)
    {
        var personnel = _service.CreatePersonnel(newPersonnel);
        if (personnel is null) BadRequest("Used PersonnelId (PId)");
        return CreatedAtAction(nameof(GetPersonnel), new { id = personnel!.Id }, personnel);
    }
    [HttpGet("{id}")]
    public ActionResult<Personnel> GetPersonnel(int id)
    {
        var personnel = _service.GetPersonnel(id);
        if(personnel is null) return NotFound("Id Not Found");
        return personnel;
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePersonnel(int id)
    {
        var isDeleted = _service.DeletePersonnel(id);
        if (!isDeleted) NotFound("Id Not Found");
        return Ok("Succesfully Deleted");
    }
    [HttpPut("{id}")]
    public IActionResult UpdatePersonnel(int id, Personnel newPersonnel){
        var isUpdated = _service.UpdatePersonnel(id, newPersonnel);
        if (!isUpdated) NotFound("Id Not Found");
        return Ok("Succesfully Updated");
    }
    [HttpGet("pId/{id}")]
    public ActionResult<IEnumerable<Personnel>> GetPersonnelByPId(string pId)
    {
        return _service.GetPersonnelByPId(pId);
    }
    [HttpGet("name/{id}")]
    public ActionResult<IEnumerable<Personnel>> GetPersonnelByName(string name)
    {
        return _service.GetPersonnelByName(name);
    }
    [HttpGet("surname/{id}")]
    public ActionResult<IEnumerable<Personnel>> GetPersonnelBySurname(string surname)
    {
        return _service.GetPersonnelBySurname(surname);
    }

}
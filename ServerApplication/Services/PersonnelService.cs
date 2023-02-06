using Microsoft.EntityFrameworkCore;
using ServerApplication.Models;
using ServerApplication.Utils;
using ServerApplication.Data;

namespace ServerApplication.Services;

public class PersonnelService
{
    private readonly FixturesContext _context;
    public PersonnelService(FixturesContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Personnel> GetAllPersonnels()
    {
        return _context.Personnels
            .AsNoTracking()
            .ToArray
            ();
    }
    
    public Personnel? CreatePersonnel(Personnel personnel)
    {
        var personnelArray = _context.Personnels.Where(p => p.PersonnelId == personnel.PersonnelId).ToArray();
        if (personnelArray.Length != 0) return null; 
        _context.Personnels.Add(personnel);
        _context.SaveChanges();
        return personnel;
    }
    public bool UpdatePersonnel(int id, Personnel personnel)
    {
        var personnelToUpdate = _context.Personnels.Find(id);
        if (personnelToUpdate is null) return false;
        personnelToUpdate = personnel;
        personnelToUpdate.PersonnelId = personnel.PersonnelId;
        personnelToUpdate.Name = personnel.Name;
        personnelToUpdate.Surname = personnel.Surname;
        personnelToUpdate.Timestamp = TimeUtils.Timestamp();
        _context.SaveChanges();
        return true;
    }
    public bool DeletePersonnel(int id)
    {
        var personnelToDelete = _context.Personnels.Find(id);
        if (personnelToDelete is null) return false;
        _context.Personnels.Remove(personnelToDelete);
        _context.SaveChanges();
        return true;
    }
    public Personnel? GetPersonnel(int id)
    {
        return _context.Personnels
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }
    public Personnel[] GetPersonnelByPId(string pId)
    {
        return _context.Personnels
            .AsNoTracking()
            .Where(p => p.PersonnelId == pId).ToArray();
    }
    public Personnel[] GetPersonnelByName(string name)
    {
        return _context.Personnels
            .AsNoTracking()
            .Where(p => p.Name == name).ToArray();
    }
    public Personnel[] GetPersonnelBySurname(string surname)
    {
        return _context.Personnels
            .AsNoTracking()
            .Where(p => p.Surname == surname).ToArray();
    }
   
    /** Old Unused Codes
    public void UpdatePersonnel(string personnelId, Personnel personnel)
    {
        var personnelToUpdateArray = _context.Personnels.Where(p => p.PersonnelId == personnelId).ToArray();
        if (personnelToUpdateArray.Length == 0) throw new InvalidOperationException("Personnel does not exist");

        var personnelToUpdate = personnelToUpdateArray[0];
        personnelToUpdate = personnel;
        _context.SaveChanges();
    }
    public void DeletePersonnel(string personnelId)
    {
        var personnelToDeleteArray = _context.Personnels.Where(p => p.PersonnelId == personnelId).ToArray();
        if (personnelToDeleteArray.Length != 0) {
            var personnelToDelete = personnelToDeleteArray[0];
            if (personnelToDelete is not null) {
                _context.Personnels.Remove(personnelToDelete);
                _context.SaveChanges();
            }      
        }      
    }
    */
}


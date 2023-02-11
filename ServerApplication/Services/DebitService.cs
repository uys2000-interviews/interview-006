using Microsoft.EntityFrameworkCore;
using ServerApplication.Models;
using ServerApplication.Utils;
using ServerApplication.Data;

namespace ServerApplication.Services;

public class DebitService
{
    private readonly FixturesContext _context;
    public DebitService(FixturesContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Debit> GetAllDebits()
    {
        return _context.Debits
            .AsNoTracking()
            .ToArray();
    }
    public Debit? CreateDebit(Debit debit)
    {
        var debitArray = _context.Debits.Where(p => p.FixtureId == debit.FixtureId).ToArray();
        var fixtureArray = _context.Fixtures.Where(p => p.FixtureId == debit.FixtureId).ToArray();
        var personnelArray = _context.Personnels.Where(p => p.PersonnelId == debit.PersonnelId).ToArray();
        if (debitArray.Length != 0 || fixtureArray.Length == 0 || personnelArray.Length == 0) return null;
        debit.Timestamp = TimeUtils.Timestamp();
        _context.Debits.Add(debit);
        _context.SaveChanges();
        return debit;
    }
    public bool UpdateDebit(int id, Debit debit)
    {
        var debitToUpdate = _context.Debits.Find(id);
        if (debitToUpdate is null) return false;

        debitToUpdate.PersonnelId = debit.PersonnelId;
        debitToUpdate.FixtureId = debit.FixtureId;
        debitToUpdate.IsTaken = debit.IsTaken;
        debitToUpdate.PId = debit.PId;
        debitToUpdate.FId = debit.FId;
        debitToUpdate.Timestamp = TimeUtils.Timestamp();
        
        _context.SaveChanges();
        return true;
    }
    public bool DeleteDebit(int id)
    {
        var debitToDelete = _context.Debits.Find(id);
        if (debitToDelete is null) return false;
        _context.Debits.Remove(debitToDelete);
        _context.SaveChanges();
        return true;
    }
    public Debit? GetDebit(int id)
    {
        return _context.Debits
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }
    public Debit[] GetDebitsByPId(int pId)
    {
        return _context.Debits
            .AsNoTracking()
            .Where((debit) => debit.PId == pId).ToArray();
    }
    public Debit[] GetDebitsByPId(string personnelId)
    {
        return _context.Debits
            .AsNoTracking()
            .Where(p => p.PersonnelId == personnelId).ToArray();
    }
    public bool UpdateDebitsByPId(int id, Personnel personnel)
    {
        try{
            var debits = _context.Debits
                .Where(p => p.PId == id).ToList();
            debits.ForEach(p=>{
                p.PersonnelId = personnel.PersonnelId;
            });
            _context.SaveChanges();
            return true;
        } catch { return false; }
    }
    public Debit GetDebitByFId(int fId)
    {
        return _context.Debits
            .AsNoTracking()
            .First(p => p.FId == fId);
    }
    public Debit GetDebitByFId(string fixtureId)
    {
        return _context.Debits
            .AsNoTracking()
            .First(p => p.FixtureId == fixtureId);
    }
    public bool SetDebitByFId(int id, string fixtureId)
    {
        try{
            var debits = _context.Debits
                .Where(p => p.FId == id).ToList();
            debits.ForEach(p=>{
                p.FixtureId = fixtureId;
            });
            _context.SaveChanges();
            return true;
        } catch { return false; }
    }
    public Debit[] GetDebitsByTaken(bool isTaken)
    {
        return _context.Debits
            .AsNoTracking()
            .Where(p => p.IsTaken == isTaken).ToArray();
    }
    public bool DeleteDebitByPId(int pId)
    {
        var debitsToDelete = _context.Debits
            .AsNoTracking()
            .Where(d => d.PId == pId).ToArray();
        if(debitsToDelete.Count() == 0) return true;
        _context.Debits.RemoveRange(debitsToDelete);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteDebitByPId(string personnelId)
    {
        var debitsToDelete = _context.Debits
            .AsNoTracking()
            .Where(p => p.PersonnelId == personnelId).ToArray();
        if(debitsToDelete.Count() == 0) return true;
        _context.Debits.RemoveRange(debitsToDelete);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteDebitByFId(int fId)
    {   
        var debitToDelete = _context.Debits.SingleOrDefault(d=> d.FId == fId);
        if (debitToDelete is null) return true;
        _context.Debits.Remove(debitToDelete);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteDebitByFId(string fixtureId)
    {
        var debitToDelete = _context.Debits.SingleOrDefault(d=> d.FixtureId == fixtureId);
        if (debitToDelete is null) return true;
        _context.Debits.Remove(debitToDelete);
        _context.SaveChanges();
        return true;
    }
}
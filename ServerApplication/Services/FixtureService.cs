using Microsoft.EntityFrameworkCore;
using ServerApplication.Models;
using ServerApplication.Utils;
using ServerApplication.Data;

namespace ServerApplication.Services;

public class FixtureService
{
    private readonly FixturesContext _context;
    public FixtureService(FixturesContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Fixture> GetAllFixtures()
    {
        return _context.Fixtures
            .AsNoTracking()
            .ToArray();
    }
    public Fixture? CreateFixture(Fixture fixture)
    {
        var fixtureArray = _context.Fixtures.Where(p => p.FixtureId == fixture.FixtureId).ToArray();
        if (fixtureArray.Length != 0) return null;
        _context.Fixtures.Add(fixture);
        _context.SaveChanges();
        return fixture;
    }
    public bool UpdateFixture(int id, Fixture fixture)
    {
        var fixtureToUpdate = _context.Fixtures.Find(id);
        if (fixtureToUpdate is null) return false;
        fixtureToUpdate.Type = fixture.Type;
        fixtureToUpdate.FixtureId = fixture.FixtureId;
        fixtureToUpdate.Brand = fixture.Brand;
        fixtureToUpdate.Model = fixture.Model;
        fixtureToUpdate.Notes = fixture.Notes;
        fixtureToUpdate.Timestamp = TimeUtils.Timestamp();
        _context.SaveChanges();
        return true;
    }
    public bool DeleteFixture(int id)
    {
        var fixtureToDelete = _context.Fixtures.Find(id);
        if (fixtureToDelete is null) return false;
        _context.Fixtures.Remove(fixtureToDelete);
        _context.SaveChanges();
        return true;
    }
    public Fixture? GetFixture(int id)
    {
        return _context.Fixtures
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }
    public Fixture[] GetFixtureByFId(string fId)
    {
        return _context.Fixtures
            .AsNoTracking()
            .Where(p => p.FixtureId == fId).ToArray();
    }
    public Fixture[] GetFixtureByType(string type)
    {
        return _context.Fixtures
            .AsNoTracking()
            .Where(p => p.Type == type).ToArray();
    }
    public Fixture[] GetFixtureByBrand(string brand)
    {
        return _context.Fixtures
            .AsNoTracking()
            .Where(p => p.Brand == brand).ToArray();
    }
    public Fixture[] GetFixtureByModel(string model)
    {
        return _context.Fixtures
            .AsNoTracking()
            .Where(p => p.Model == model).ToArray();
    }
}


using System.ComponentModel.DataAnnotations;

namespace ClientApplication.Models;

public class Fixture
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? FixtureId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Notes { get; set; }
    public int Timestamp { get; set; }
}
public class Fixtures: List<Fixture>{ }
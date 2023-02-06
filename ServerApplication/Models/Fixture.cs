using System.ComponentModel.DataAnnotations;

namespace ServerApplication.Models;

public class Fixture
{
    public int Id { get; set; }
    [Required]
    public string? Type { get; set; }
    [Required]
    public string? FixtureId { get; set; }
    [Required]
    public string? Brand { get; set; }
    [Required]
    public string? Model { get; set; }
    public string? Notes { get; set; }
    [Required]
    public int Timestamp { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ServerApplication.Models;
public class Debit
{
    public int Id { get; set; }
    [Required]
    public int PId { get; set; }
    [Required]
    public string? PersonnelId { get; set; }
    [Required]
    public int FId { get; set; }
    [Required]
    public string? FixtureId { get; set; }
    [Required]
    public bool IsTaken { get; set; }
    [Required]
    public int Timestamp { get; set; }
}
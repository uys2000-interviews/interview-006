using System.ComponentModel.DataAnnotations;

namespace ServerApplication.Models;

public class Personnel
{
    public int Id { get; set; }
    [Required]
    public string? PersonnelId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    public int Timestamp { get; set; }
}
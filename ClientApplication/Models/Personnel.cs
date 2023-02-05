using System.ComponentModel.DataAnnotations;

namespace ClientApplication.Models;

public class Personnel
{
    public int Id { get; set; }
    [Required]
    public string? PersonnelId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Timestamp { get; set; }
}
public class Personnels : List<Personnel>{ }

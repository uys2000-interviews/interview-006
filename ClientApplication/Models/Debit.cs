using System.ComponentModel.DataAnnotations;

namespace ClientApplication.Models;

public class Debit
{
    public int Id { get; set; }
    public int PId { get; set; }
    public string? PersonnelId { get; set; }
    public int FId { get; set; }
    public string? FixtureId { get; set; }
    public bool IsTaken { get; set; }
    public int Timestamp { get; set; }
}

public class Debits : List<Debit>{ }
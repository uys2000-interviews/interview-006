using ServerApplication.Models;
using ServerApplication.Utils;

namespace ServerApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FixturesContext context)
        {

            if (context.Fixtures.Any()
                && context.Debits.Any()
                && context.Personnels.Any()) 
                return;   // DB has been seeded

            var personnels = new Personnel[]{
                new Personnel {
                    PersonnelId = "001100011100",
                    Name = "Mehmet",
                    Surname = "Uysal",
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Personnel {
                    PersonnelId = "110111022200",
                    Name = "Ragıp",
                    Surname = "Kara",
                    Timestamp =  TimeUtils.Timestamp()
                },
            };

            var fixtures = new Fixture[]{
                new Fixture { 
                    Type = "Computer", 
                    FixtureId = "SN0000A1111", 
                    Brand = "MSI", 
                    Model = "GP62M",
                    Notes = "Example Note",
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Fixture { 
                    Type = "Monitor", 
                    FixtureId = "SN1111B0000", 
                    Brand = "LG", 
                    Model = "27GQ50F-B",
                    Notes = null,
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Fixture { 
                    Type = "Phone", 
                    FixtureId = "IMEI457853330624511", 
                    Brand = "Samsung", 
                    Model = "SM-A105F",
                    Notes = "Example Note 2",
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Fixture { 
                    Type = "Computer", 
                    FixtureId = "SN2222B3333", 
                    Brand = "Acer", 
                    Model = "A315-58-516F",
                    Notes = "Example Note 2",
                    Timestamp =  TimeUtils.Timestamp()
                },
            };
            
            var debits = new Debit[]{
                new Debit {
                    PId = 1,
                    PersonnelId = "001100011100",
                    FId = 1,
                    FixtureId = "SN0000A1111",
                    IsTaken = false,
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Debit {
                    PId = 1,
                    PersonnelId = "001100011100",
                    FId = 2,
                    FixtureId = "SN1111B0000",
                    IsTaken = true,
                    Timestamp =  TimeUtils.Timestamp()
                },
                new Debit{
                    PId = 2,
                    PersonnelId = "110111022200",
                    FId = 3,
                    FixtureId = "IMEI457853330624511",
                    IsTaken = false,
                    Timestamp =  TimeUtils.Timestamp()
                },
            };

            context.Personnels.AddRange(personnels);
            context.Fixtures.AddRange(fixtures);
            context.Debits.AddRange(debits);
            context.SaveChanges();
        }
    }
}
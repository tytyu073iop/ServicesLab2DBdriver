using Xunit.Sdk;
using DBdriver;

namespace TestBackend;

public class DBManagerTest
{
    [Fact]
    public void TestAddition()
    {
        DBManager dbm = new();
        Roster test = new()
        {
            Playerid = "adamlem",
            Jersey = 12,
            Fname = "Mike",
            Sname = "Adamle",
            Position = "RW",
            Birthday = "2001-09-21 00:00:00",
            Weight = 90,
            Height = 197,
            Birthcity = "Stamford",
            Birthstate = "CT"
        };

        dbm.AddRoster(test);

        var result = dbm.GetAllRosters();
        Assert.Equal([test], result);
    }

    [Fact]
    public void TestAdditionFalure()
    {
        DBManager dbm = new();
        Roster test = new() { Playerid = "adamlem", Jersey = 12, Fname = "Mike", Sname = "Adamle", Position = "RW", Birthday = "2001-09-21 00:00:00", Weight = 70, Height = 197, Birthcity = "Stamford", Birthstate = "CT" };

        Assert.Throws<Exception>(() => dbm.AddRoster(test));
    }
}

using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;
using SF.PJ03.Task25._7._1.DAL.Database.DAL.Seeds;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            DatabaseSeeder.SeedDatabase(db);
        }
    }
}
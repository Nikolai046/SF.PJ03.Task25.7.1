using SF.PJ03.Task25._7._1.DAL.Database.DAL.Seeds;
using SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

namespace SF.PJ03.Task25._7._1.DAL.Database;

internal class Program
{
    public static MainView mainView;
    public static SubView_1 subView_1;
    public static SubView_2 subView_2;
    public static SubView_3 subView_3;
    public static SubView_4 subView_4;

    private static void Main(string[] args)
    {
        using (var db = new AppContext()) { DatabaseSeeder.SeedDatabase(db); }

        mainView = new MainView();
        subView_1 = new SubView_1();
        subView_2 = new SubView_2();
        subView_3 = new SubView_3();
        subView_4 = new SubView_4();

        mainView.Show();
    }
}
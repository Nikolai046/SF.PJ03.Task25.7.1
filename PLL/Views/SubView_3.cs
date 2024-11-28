using SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

/// <summary>
/// Подменю для работы с книгами. Включает операции взятия, возврата и просмотра книг на руках.
/// </summary>
public class SubView_3
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Операции с книгами" +
                              "\n\t(нажмите 1) Взять книгу" +
                              "\n\t(нажмите 2) Вернуть книгу" +
                              "\n\t(нажмите 3) Список книг на руках" +
                              "\n\t(нажмите 0) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (var userService = new UserService())
                        { userService.TakeBook(); }
                        break;
                    }

                case "2":
                    {
                        using (var userService = new UserService())
                        { userService.ReturnBook(); }
                        break;
                    }
                case "3":
                    {
                        using (var userService = new UserService())
                        { userService.GetBookOnHand(); }
                        break;
                    }
                case "0":
                    {
                        Program.mainView.Show();
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
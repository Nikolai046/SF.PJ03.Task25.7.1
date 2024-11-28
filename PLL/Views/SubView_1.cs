using SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

/// <summary>
/// Подменю для управления пользователями. Включает операции добавления, обновления и получения информации о пользователях.
/// </summary>
public class SubView_1
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Управление пользователями" +
                              "\n\t(нажмите 1) Добавить нового пользователя" +
                              "\n\t(нажмите 2) Просмотреть всех пользователей" +
                              "\n\t(нажмите 3) Обновить данные пользователя" +
                              "\n\t(нажмите 4) Получить информацию о пользователе по Id" +
                              "\n\t(нажмите 0) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (var userService = new UserService())
                        { userService.AddNewUser(); }
                        break;
                    }

                case "2":
                    {
                        using (var userService = new UserService())
                        { userService.GetAllUsers(); }
                        break;
                    }
                case "3":
                    {
                        {
                            using (var userService = new UserService())
                            { userService.UpdateUserData(); }
                            break;
                        };
                    }
                case "4":
                    {
                        using (var userService = new UserService())
                        {
                            userService.GetUserById();
                        }
                        break;
                    }
                case "0":
                    {
                        Program.mainView.Show();
                        break;
                    }
            }
        }
    }
}
namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

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
                              "\n\t(нажмите 3) Обновить имя пользователя" +
                              "\n\t(нажмите 4) Получить информацию о пользователе" +
                              "\n\t(нажмите 5) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        //Program.authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        //Program.registrationView.Show();
                        break;
                    }
                case "3":
                    {
                        break;
                    }
                case "4":
                    {
                        break;
                    }
                case "5":
                    {
                        Program.mainView.Show();
                        break;
                    }
            }
        }
    }
}
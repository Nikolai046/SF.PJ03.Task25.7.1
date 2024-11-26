namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

public class SubView_5
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Статистика" +
                              "\n\t(нажмите 1) Количество книг автора" +
                              "\n\t(нажмите 2) Количество книг жанра" +
                              "\n\t(нажмите 3) Книги определенного автора" +
                              "\n\t(нажмите 4) Наличие книги в библиотеке" +
                              "\n\t(нажмите 5) Книги на руках у пользователя" +
                              "\n\t(нажмите 6) Назад");

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
                        break;
                    }
                case "6":
                    {
                        Program.mainView.Show();
                        break;
                    }
            }
        }
    }
}
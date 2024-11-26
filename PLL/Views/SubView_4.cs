namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

public class SubView_4
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Поиск и фильтрация" +
                              "\n\t(нажмите 1) Книги по жанру" +
                              "\n\t(нажмите 2) Книги между определенными годами" +
                              "\n\t(нажмите 3) Книги определенного автора" +
                              "\n\t(нажмите 4) Последняя вышедшая книга" +
                              "\n\t(нажмите 5) Список книг по алфавиту" +
                              "\n\t(нажмите 6) писок книг по году выхода (убывание)" +
                              "\n\t(нажмите 7) Назад");

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
                        break;
                    }
                case "7":
                    {
                        Program.mainView.Show();
                        break;
                    }
            }
        }
    }
}
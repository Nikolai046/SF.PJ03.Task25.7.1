using SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

/// <summary>
/// Подменю для поиска и фильтрации книг. Включает поиск по жанру, автору, алфавиту и году выпуска.
/// </summary>
public class SubView_4
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Поиск и фильтрация" +
                              "\n\t(нажмите 1) Список книг по жанру" +
                              "\n\t(нажмите 2) Список книг по автору" +
                              "\n\t(нажмите 3) Список книг по алфавиту" +
                              "\n\t(нажмите 4) Список книг по году выхода (убывание)" +
                              "\n\t(нажмите 0) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.GetAllBooksByGenre(); }
                        break;
                    }

                case "2":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.GetAllBooksByAuthor(); }
                        break;
                    }
                case "3":
                    {
                        using var bookService = new Bookservice();
                        bookService.GetAllBooksByAlphabet();
                        break;
                    }
                case "4":
                    {
                        using var bookService = new Bookservice();
                        bookService.GetAllBooksByYear();
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
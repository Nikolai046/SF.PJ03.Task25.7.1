using SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

public class SubView_2
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Управление книгами" +
                              "\n\t(нажмите 1) Добавить новую книгу" +
                              "\n\t(нажмите 2) Просмотреть все книги" +
                              "\n\t(нажмите 3) Удалить книгу по ID" +
                              "\n\t(нажмите 4) Получить информацию о книге по ID" +
                              "\n\t(нажмите 0) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.AddNewBook(); }
                        break;
                    }

                case "2":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.GetAllBooks(); }
                        break;
                    }
                case "3":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.DeleteBookById(); }
                        break;
                    }
                case "4":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.GetBooksById(); }
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
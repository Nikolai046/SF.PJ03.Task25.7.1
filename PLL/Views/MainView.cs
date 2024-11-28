namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

public class MainView
{
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("(нажмите 1) Управление пользователями" +
                              "\n\t-Добавить нового пользователя" +
                              "\n\t-Просмотреть всех пользователей" +
                              "\n\t-Обновить имя пользователя" +
                              "\n\t-Получить информацию о пользователе");
            Console.WriteLine("(нажмите 2) Управление книгами" +
                              "\n\t-Добавить новую книгу" +
                              "\n\t-Просмотреть все книги" +
                              "\n\t-Удалить книгу" +
                              "\n\t-Получить информацию о книге");
            Console.WriteLine("(нажмите 3) Операции с книгами" +
                              "\n\t-Взять книгу" +
                              "\n\t-Вернуть книгу" +
                              "\n\t-Список книг на руках");
            Console.WriteLine("(нажмите 4) Поиск и фильтрация" +
                              "\n\t-Список книг по жанру" +
                              "\n\t-Список книг по автору" +
                              "\n\t-Список книг по алфавиту" +
                              "\n\t-Список книг по году выхода (убывание)");
            Console.WriteLine("(нажмите 0) Выход из программы");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.subView_1.Show();
                        break;
                    }

                case "2":
                    {
                        Program.subView_2.Show();
                        break;
                    }
                case "3":
                    {
                        Program.subView_3.Show();
                        break;
                    }
                case "4":
                    {
                        Program.subView_4.Show();
                        break;
                    }
                case "0":
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
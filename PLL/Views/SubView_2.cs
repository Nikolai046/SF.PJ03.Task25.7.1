﻿using SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

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
                              "\n\t(нажмите 3) Удалить книгу" +
                              "\n\t(нажмите 4) Получить информацию о книге" +
                              "\n\t(нажмите 5) Назад");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (var bookService = new Bookservice())
                        { bookService.GetAllBooks(); }
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
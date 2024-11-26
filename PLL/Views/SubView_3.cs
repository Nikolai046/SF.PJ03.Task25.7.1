namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Views;

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
                              "\n\t(нажмите 4) Назад");

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
                        Program.mainView.Show();
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
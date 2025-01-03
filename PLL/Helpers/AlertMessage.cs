﻿namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Helpers;

/// <summary>
/// Класс для отображения сообщений об ошибках в консоли.
/// </summary>
public class AlertMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}
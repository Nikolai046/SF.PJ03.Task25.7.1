﻿namespace SF.PJ03.Task25._7._1.DAL.Database.PLL.Helpers;

public static class SuccessMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}
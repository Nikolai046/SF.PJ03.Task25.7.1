using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;
using SF.PJ03.Task25._7._1.DAL.Database.PLL.Helpers;
using SF.PJ03.Task25._7._1.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SF.PJ03.Task25._7._1.DAL.Database.BLL.Services;

public class UserService
{

        if (!_userRepository.IsBookTakenByUser(userId, idBookToReturn))
        {
            AlertMessage.Show($"Книги с Id: {idBookToReturn} у пользователя нет");
            Console.ReadKey();
            return;
        }
        _bookRepository.ReturnBook(idBookToReturn, userId);
        db.SaveChanges();
        SuccessMessage.Show($"Книга с Id: {idBookToReturn} успешно возвращена");
        Console.ReadKey();
    }
}
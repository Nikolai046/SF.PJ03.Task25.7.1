using SF.PJ03.Task25._7._1.DAL.Database.DAL.Repositories;
using SF.PJ03.Task25._7._1.DAL.Entities;

namespace SF.PJ03.Task25._7._1.DAL.Database.DAL.Seeds;

/// <summary>
/// Статический класс для начального заполнения базы данных тестовыми данными.
/// </summary>
public static class DatabaseSeeder
{
    public static void SeedDatabase(AppContext db)
    {
        if (!db.Books.Any()) // Проверяем, что база пуста
        {
            var genreRepo = new GenreRepository(db);
            var authorRepo = new AuthorRepository(db);
            var bookRepo = new BookRepository(db);

            var books = new List<Book>
            {
                // Роман
                new Book {
                    Title = "Война и мир",
                    Year = 1869,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Лев") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Роман"),
                        genreRepo.CreateGenre("Исторический роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },
                new Book {
                    Title = "Тихий Дон",
                    Year = 1940,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Шолохов Михаил") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Роман"),
                        genreRepo.CreateGenre("Исторический роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },
                new Book {
                    Title = "Евгений Онегин",
                    Year = 1831,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Пушкин Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Роман"),
                        genreRepo.CreateGenre("Драма"),
                        genreRepo.CreateGenre("Любовный роман")
                    }
                },

                // Детектив
                new Book {
                    Title = "Преступление и наказание",
                    Year = 1866,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Достоевский Федор") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Детектив"),
                        genreRepo.CreateGenre("Психологический роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },
                new Book {
                    Title = "Приключения Эраста Фандорина",
                    Year = 2010,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Акунин Борис") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Детектив"),
                        genreRepo.CreateGenre("Исторический роман"),
                        genreRepo.CreateGenre("Приключения")
                    }
                },
                new Book {
                    Title = "Петровка, 38",
                    Year = 1963,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Семёнов Юлиан") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Детектив"),
                        genreRepo.CreateGenre("Триллер")
                    }
                },

                // Фантастика
                new Book {
                    Title = "Мы",
                    Year = 1920,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Замятин Евгений") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фантастика"),
                        genreRepo.CreateGenre("Антиутопия")
                    }
                },
                new Book {
                    Title = "Пикник на обочине",
                    Year = 1972,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Стругацкий Аркадий"),
                        authorRepo.CreateAuthor("Стругацкий Борис")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фантастика")
                    }
                },
                new Book {
                    Title = "Час Быка",
                    Year = 1968,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Ефремов Иван") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фантастика"),
                        genreRepo.CreateGenre("Философский роман")
                    }
                },

                // Фэнтези
                new Book {
                    Title = "Волкодав",
                    Year = 1995,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Семёнова Мария") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фэнтези")
                    }
                },
                new Book {
                    Title = "Ночной Дозор",
                    Year = 1998,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Лукьяненко Сергей") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фэнтези"),
                        genreRepo.CreateGenre("Городское фэнтези"),
                        genreRepo.CreateGenre("Приключения")
                    }
                },
                new Book {
                    Title = "Лабиринты Ехо",
                    Year = 1997,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Фрай Макс"),
                        authorRepo.CreateAuthor("Мартынчик Светлана")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Фэнтези"),
                        genreRepo.CreateGenre("Приключения")
                    }
                },

                // Триллер
                new Book {
                    Title = "Мастер и Маргарита",
                    Year = 1940,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Булгаков Михаил") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Триллер"),
                        genreRepo.CreateGenre("Фэнтези"),
                        genreRepo.CreateGenre("Любовный роман"),
                        genreRepo.CreateGenre("Сатира")
                    }
                },
                new Book {
                    Title = "НКВД против ГЕСТАПО",
                    Year = 2004,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Долгополов Николай") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Триллер"),
                        genreRepo.CreateGenre("Исторический роман")
                    }
                },
                new Book {
                    Title = "Крот",
                    Year = 2004,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Корецкий Данил") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Триллер"),
                        genreRepo.CreateGenre("Детектив")
                    }
                },

                // Любовный роман
                new Book {
                    Title = "Анна Каренина",
                    Year = 1877,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Лев") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Любовный роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },
                new Book {
                    Title = "Первая любовь",
                    Year = 1860,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Тургенев Иван") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Любовный роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },
                new Book {
                    Title = "Гранатовый браслет",
                    Year = 1911,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Куприн Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Любовный роман"),
                        genreRepo.CreateGenre("Драма")
                    }
                },

                // Исторический роман
                new Book {
                    Title = "Петр Первый",
                    Year = 1945,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Алексей") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Исторический роман")
                    }
                },
                new Book {
                    Title = "Капитанская дочка",
                    Year = 1836,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Пушкин Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Исторический роман"),
                        genreRepo.CreateGenre("Приключения"),
                        genreRepo.CreateGenre("Любовный роман")
                    }
                },
                new Book {
                    Title = "Князь Серебряный",
                    Year = 1862,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Алексей Константинович") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Исторический роман"),
                        genreRepo.CreateGenre("Приключения")
                    }
                },

                // Приключения
                new Book {
                    Title = "Два капитана",
                    Year = 1944,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Каверин Вениамин") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Приключения"),
                        genreRepo.CreateGenre("Любовный роман")
                    }
                },
                new Book {
                    Title = "Дети капитана Гранта",
                    Year = 1867,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Верн Жюль"),
                        authorRepo.CreateAuthor("Вовчок Марко")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Приключения")
                    }
                },
                new Book {
                    Title = "Остров Сокровищ",
                    Year = 1883,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Стивенсон Роберт"),
                        authorRepo.CreateAuthor("Чуковский Николай")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Приключения")
                    }
                },

                // Ужасы
                new Book {
                    Title = "Вий",
                    Year = 1835,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Гоголь Николай") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Ужасы"),
                        genreRepo.CreateGenre("Мистика")
                    }
                },
                new Book {
                    Title = "Упырь",
                    Year = 1841,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Алексей") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Ужасы"),
                        genreRepo.CreateGenre("Мистика")
                    }
                },
                new Book {
                    Title = "Семья вурдалака",
                    Year = 1847,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Толстой Алексей") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Ужасы"),
                        genreRepo.CreateGenre("Мистика")
                    }
                },

                // Драма
                new Book {
                    Title = "Отцы и дети",
                    Year = 1862,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Тургенев Иван") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Драма"),
                        genreRepo.CreateGenre("Роман")
                    }
                },
                new Book {
                    Title = "Обломов",
                    Year = 1859,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Гончаров Иван") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Драма"),
                        genreRepo.CreateGenre("Роман")
                    }
                },
                new Book {
                    Title = "Братья Карамазовы",
                    Year = 1880,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Достоевский Федор") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Драма"),
                        genreRepo.CreateGenre("Философский роман")
                    }
                },

                // Биография
                new Book {
                    Title = "Жизнь Пушкина",
                    Year = 1981,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Лотман Юрий") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Биография")
                    }
                },
                new Book {
                    Title = "Жизнь Льва Толстого",
                    Year = 2010,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Басинский Павел") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Биография")
                    }
                },
                new Book {
                    Title = "Достоевский",
                    Year = 1935,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Гроссман Леонид") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Биография")
                    }
                },

                // Документальная проза
                new Book {
                    Title = "Архипелаг ГУЛАГ",
                    Year = 1968,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Солженицын Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Документальная проза"),
                        genreRepo.CreateGenre("Публицистика")
                    }
                },
                new Book {
                    Title = "Блокадная книга",
                    Year = 1979,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Адамович Алесь"),
                        authorRepo.CreateAuthor("Гранин Даниил")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Документальная проза")
                    }
                },
                new Book {
                    Title = "У войны не женское лицо",
                    Year = 1983,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Алексиевич Светлана") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Документальная проза")
                    }
                },

                // Научно-популярная литература
                new Book {
                    Title = "Занимательная физика",
                    Year = 1913,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Перельман Яков") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Научно-популярная литература")
                    }
                },

                new Book {
                    Title = "Эволюция физики",
                    Year = 1948,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Ландау Лев"),
                        authorRepo.CreateAuthor("Лифшиц Евгений")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Научно-популярная литература")
                    }
                },
                new Book {
                    Title = "В мире науки и техники",
                    Year = 1950,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Обручев Владимир") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Научно-популярная литература")
                    }
                },

                // Публицистика
                new Book {
                    Title = "Дневник писателя",
                    Year = 1881,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Достоевский Федор") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Публицистика"),
                        genreRepo.CreateGenre("Философская литература")
                    }
                },
                new Book {
                    Title = "Окаянные дни",
                    Year = 1920,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Бунин Иван") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Публицистика"),
                        genreRepo.CreateGenre("Документальная проза")
                    }
                },
                new Book {
                    Title = "Крохотки",
                    Year = 1960,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Солженицын Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Публицистика")
                    }
                },

                // Мемуары
                new Book {
                    Title = "Былое и думы",
                    Year = 1867,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Герцен Александр") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Мемуары")
                    }
                },
                new Book {
                    Title = "Воспоминания",
                    Year = 1970,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Мандельштам Надежда") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Мемуары")
                    }
                },
                new Book {
                    Title = "Люди, годы, жизнь",
                    Year = 1965,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Эренбург Илья") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Мемуары")
                    }
                },

                // Философская литература
                new Book {
                    Title = "Оправдание добра",
                    Year = 1894,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Соловьев Владимир") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Философская литература")
                    }
                },
                new Book {
                    Title = "Смысл любви",
                    Year = 1892,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Соловьев Владимир") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Философская литература")
                    }
                },
                new Book {
                    Title = "Философия общего дела",
                    Year = 1913,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Федоров Николай") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Философская литература")
                    }
                },

                // Религиозная литература
                new Book {
                    Title = "Столп и утверждение истины",
                    Year = 1914,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Флоренский Павел") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Религиозная литература")
                    }
                },
                new Book {
                    Title = "Лествица",
                    Year = 1100,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Иоанн Лествичник") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Религиозная литература")
                    }
                },
                new Book {
                    Title = "Добротолюбие",
                    Year = 1877,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Феофан Затворник") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Религиозная литература")
                    }
                },

                // Деловая литература
                new Book {
                    Title = "Бизнес как игра",
                    Year = 2014,
                    Authors = new List<Author> {
                        authorRepo.CreateAuthor("Абдульманов Сергей"),
                        authorRepo.CreateAuthor("Борисов Дмитрий"),
                        authorRepo.CreateAuthor("Кибкало Дмитрий")
                    },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Деловая литература")
                    }
                },
                new Book {
                    Title = "45 татуировок менеджера",
                    Year = 2012,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Батырев Максим") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Деловая литература")
                    }
                },
                new Book {
                    Title = "Номер 1",
                    Year = 2011,
                    Authors = new List<Author> { authorRepo.CreateAuthor("Манн Игорь") },
                    Genres = new List<Genre> {
                        genreRepo.CreateGenre("Деловая литература")
                    }
                }
            };

            bookRepo.AddRange(books);
            db.SaveChanges();
        }
    }
}
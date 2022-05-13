using BookSystem.App.Models;
using BookSystem.Lib;
using System;
using System.Linq;

namespace BookSystem.App
{
    [Obsolete]
    internal class Program
    {
        //public static object Helper { get; private set; }

        static void Main(string[] args)
        {
            const string fileBooks = @"books.dat";
            const string fileAuthors = @"authors.dat";

            Lib.Helper.Init("Book System v1.0");

            var booksGraph = Lib.Helper.LoadFromFile<Book[]>(fileBooks);
            Book[] books = null;
            if (booksGraph == null)
            {
                books = new Book[0];
            }
            else
            {
                books = (Book[])booksGraph;

                //int max = books.Max(b => b.Id);

                //Book.SetCounter(max);
            }

            var authorsGraph = Lib.Helper.LoadFromFile<Author[]>(fileAuthors);
            Author[] authors = null;
            if (authorsGraph == null)
            {
                authors = new Author[0];
            }
            else
            {
                authors = (Author[])authorsGraph;

                //int max = authors.Max(b => b.Id);

                //Author.SetCounter(max);
            }

            int len;
            int id;

        l1:

            PrintMenu();
            MenuStates m = Lib.Helper.ReadMenu("Birini secin: ");

            switch (m)
            {
                case MenuStates.BooksAll:
                    Console.Clear();
                    Console.WriteLine("List of books....");
                    foreach (var book in books)
                    {
                        var author = authors.FirstOrDefault(a=>a.Id == book.AuthorId);
                        Console.WriteLine(book.ToString(author));
                        
                    }
                    goto l1;
                case MenuStates.BookById:
                    id = Lib.Helper.ReadInt("Kitabin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var search = new Book(id);

                    int index = Array.IndexOf(books, search);

                    if (index != -1)
                    {
                        search = books[index];
                        Console.Clear();
                        Lib.Helper.PrintWarning($"Tapildi: {search}");
                        goto l1;
                    }


                    Lib.Helper.PrintError("Kitab tapilmadi");
                    goto case MenuStates.BookById;

                case MenuStates.BookAdd:

                    ShowAllAuthors(authors);
                    int authorId;
                l2:
                    authorId = Lib.Helper.ReadInt("Muellif kodunu daxil edin: ", minValue: 1);

                    var selectedAuthor = new Author(authorId);

                    if (Array.IndexOf(authors, selectedAuthor) == -1)
                    {
                        Lib.Helper.PrintError("Siyahidan secin");
                        goto l2;
                    }

                    len = books.Length;
                    Array.Resize(ref books, len + 1);
                    books[len] = new Book();
                    books[len].AuthorId = authorId;
                    books[len].Name = Lib.Helper.ReadString("Kitabin adi: ", true);
                    books[len].PageCount = Lib.Helper.ReadInt("Kitabin sehife sayi: ", 1);
                    books[len].Price = Lib.Helper.ReadDouble("Kitabin qiymeti: ", 0.50);
                    Console.Clear();
                    goto case MenuStates.BooksAll;
                case MenuStates.BookEdit:
                    id = Lib.Helper.ReadInt("Kitabin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var searchByEdit = new Book(id);

                    int indexByEdit = Array.IndexOf(books, searchByEdit);

                    if (indexByEdit != -1)
                    {
                        search = books[indexByEdit];
                        Console.Clear();
                        Lib.Helper.PrintWarning($"Tapildi: {search}");

                        string nameByEdit = Lib.Helper.ReadString("Kitabin adi: ");

                        if (!string.IsNullOrWhiteSpace(nameByEdit))
                        {
                            search.Name = nameByEdit;
                        }


                        ShowAllAuthors(authors);
                        int authorIdForEdit;
                    l3:
                        authorIdForEdit = Lib.Helper.ReadInt("Muellif kodunu daxil edin: ", minValue: 1);

                        var selectedAuthorForEdit = new Author(authorIdForEdit);

                        if (Array.IndexOf(authors, selectedAuthorForEdit) == -1)
                        {
                            Lib.Helper.PrintError("Siyahidan secin");
                            goto l3;
                        }
                        search.AuthorId = authorIdForEdit;

                        search.PageCount = Lib.Helper.ReadInt("Kitabin sehife sayi: ", 1);
                        search.Price = Lib.Helper.ReadDouble("Kitabin qiymeti: ", 0.50);

                        goto case MenuStates.BooksAll;
                    }


                    Lib.Helper.PrintError("Kitab tapilmadi");
                    goto case MenuStates.BookEdit;
                case MenuStates.BookRemove:
                    id = Lib.Helper.ReadInt("Kitabin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var searchByRemove = new Book(id);

                    int indexByRemove = Array.IndexOf(books, searchByRemove);

                    if (indexByRemove == -1)
                    {
                        Lib.Helper.PrintError("Kitab tapilmadi");
                        goto case MenuStates.BookRemove;
                    }

                    for (int i = indexByRemove; i < books.Length - 1; i++)
                    {
                        books[i] = books[i + 1];
                    }
                    Array.Resize(ref books, books.Length - 1);

                    goto case MenuStates.BooksAll;

                case MenuStates.AuthorAll:
                    Console.Clear();
                    ShowAllAuthors(authors);
                    goto l1;
                case MenuStates.AuthorById:
                    id = Lib.Helper.ReadInt("Muellifin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }

                    var searchAuthor = new Author(id);

                    int indexAuthor = Array.IndexOf(authors, searchAuthor);

                    if (indexAuthor != -1)
                    {
                        searchAuthor = authors[indexAuthor];
                        Console.Clear();
                        Lib.Helper.PrintWarning($"Tapildi: {searchAuthor}");
                        goto l1;
                    }


                    Lib.Helper.PrintError("Muellif tapilmadi");
                    goto case MenuStates.AuthorById;
                case MenuStates.AuthorAdd:
                    len = authors.Length;
                    Array.Resize(ref authors, len + 1);
                    authors[len] = new Author();
                    authors[len].Name = Lib.Helper.ReadString("Muellifin adi: ", true);
                    authors[len].Surname = Lib.Helper.ReadString("Muellifin soyadi: ", true);
                    Console.Clear();
                    goto case MenuStates.AuthorAll;
                case MenuStates.AuthorEdit:
                    id = Lib.Helper.ReadInt("Muellifin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }

                    var searchAuthorByEdit = new Author(id);

                    int indexAuthorByEdit = Array.IndexOf(authors, searchAuthorByEdit);

                    if (indexAuthorByEdit != -1)
                    {
                        searchAuthorByEdit = authors[indexAuthorByEdit];
                        Console.Clear();
                        Lib.Helper.PrintWarning($"Tapildi: {searchAuthorByEdit}");

                        string nameByEdit = Lib.Helper.ReadString("Muellifin adi: ");

                        if (!string.IsNullOrWhiteSpace(nameByEdit))
                        {
                            searchAuthorByEdit.Name = nameByEdit;
                        }

                        string surnameByEdit = Lib.Helper.ReadString("Muellifin soyadi: ");

                        if (!string.IsNullOrWhiteSpace(surnameByEdit))
                        {
                            searchAuthorByEdit.Surname = surnameByEdit;
                        }
                        goto case MenuStates.AuthorAll;
                    }


                    Lib.Helper.PrintError("Muellif tapilmadi");
                    goto case MenuStates.AuthorEdit;
                case MenuStates.AuthorRemove:
                    id = Lib.Helper.ReadInt("Muellifin kodu: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStates.AuthorAll;
                    }

                    var searchAuthorByRemove = new Author(id);

                    int indexAuthorByRemove = Array.IndexOf(authors, searchAuthorByRemove);

                    if (indexAuthorByRemove == -1)
                    {
                        Lib.Helper.PrintError("Muellif tapilmadi");
                        goto case MenuStates.AuthorRemove;
                    }

                    for (int i = indexAuthorByRemove; i < authors.Length - 1; i++)
                    {
                        authors[i] = authors[i + 1];
                    }
                    Array.Resize(ref authors, authors.Length - 1);

                    goto case MenuStates.AuthorAll;
                case MenuStates.Save:
                    Lib.Helper.SaveToFile(fileBooks, books);
                    Lib.Helper.SaveToFile(fileAuthors, authors);

                    Console.Clear();
                    Console.WriteLine("Saved!");
                    goto l1;
                case MenuStates.Exit:
                    Lib.Helper.PrintError("Tesdiq ucun <enter> duymesini sixin.Eks halda Menuya qayidilacaq");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    goto l1;
                default:
                    break;
            }


        }


        static void PrintMenu()
        {
            Lib.Helper.PrintWarning("------------------Menu----------------------");
            foreach (var item in Enum.GetValues(typeof(MenuStates)))
            {
                Lib.Helper.PrintWarning($"{((byte)item).ToString().PadLeft(2)}.{item}");
            }
            Lib.Helper.PrintWarning("--------------------------------------------");
        }


        static void ShowAllAuthors(Author[] authors)
        {
            Console.WriteLine("List of authors....");
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
            Lib.Helper.PrintWarning("--------------------------------------------");
        }
    }
}

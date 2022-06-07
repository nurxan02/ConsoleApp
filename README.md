# Console App Book Management System Basic
**Books Management System** to <br>
***Kamran Abdullayev*** Lessons <br>
on **Code Academy**. <br>
**Baku, Azerbaijan,** GMT+4, 14.05.2022 01:00 <br>

## Screenshot from Console

<div align="center">
   <img src="https://user-images.githubusercontent.com/90649844/172330286-57cd8b6f-f358-4cc6-b398-db01d28b2969.png" alt="Console Screenshot" width="auto" height="300px">
  </div>

## My Project properties

How can i download my project ?

```bash
git clone [--template=<template-directory>]
	  [-l] [-s] [--no-hardlinks] [-q] [-n] [--bare] [--mirror]
	  [-o <name>] [-b <name>] [-u <upload-pack>] [--reference <repository>]
	  [--dissociate] [--separate-git-dir <git-dir>]
	  [--depth <depth>] [--[no-]single-branch] [--no-tags]
	  [--recurse-submodules[=<pathspec>]] [--[no-]shallow-submodules]
	  [--[no-]remote-submodules] [--jobs <n>] [--sparse] [--[no-]reject-shallow]
	  [--filter=<filter> [--also-filter-submodules]] [--] <repository>
	  [<directory>]
```


## Book Class

```cshap
namespace BookSystem.App.Models
{
    [Serializable]
    public class Book : IEquatable<Book>
    {
        static int counter = 0;

        public Book()
        {
            counter++;
            this.Id = counter;
        }
        public Book(int id)
        {
            this.Id = id;
        }

        public static void SetCounter(int counter)
        {
            Book.counter = counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }

        public bool Equals(Book other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {AuthorId} {PageCount}. {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}";
        }

        public string ToString(Author a)
        {
            string data = (a == null) ? null : $"{a.Name} {a.Surname}";


            return $"{Id} {Name} \"{data ?? this.AuthorId.ToString()}\" {PageCount}. {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}";
        }
    }
}

```
## Author Class
```cshap
namespace BookSystem.App.Models
{
    [Serializable]
    public class Author : IEquatable<Author>
    {
        static int counter = 0;

        public Author()
        {
            counter++;
            this.Id = counter;
        }
        public Author(int id)
        {
            this.Id = id;
        }

        public static void SetCounter(int counter)
        {
            Author.counter = counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Equals(Author other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Surname}";
        }
    }
}
```
### Menu State Enum 
```cshap
namespace BookSystem.Lib
{
    public enum MenuStates : byte
    {
        BooksAll = 1,
        BookById,
        BookAdd,
        BookEdit,
        BookRemove,
        AuthorAll,
        AuthorById,
        AuthorAdd,
        AuthorEdit,
        AuthorRemove,

        Save,
        Exit,
        
    }
}
```
## Contributing
Pull requests are welcome.

Please make sure to update tests as appropriate.

## License
[MIT](https://github.com/nurxan02/)

## CopyRights
Nurkhan Masimzade
#### If you want to contact with me: [**Click Here**](https://bio.link/nurxanmasimzade/)


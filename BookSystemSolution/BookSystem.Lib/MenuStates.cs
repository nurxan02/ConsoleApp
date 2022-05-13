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
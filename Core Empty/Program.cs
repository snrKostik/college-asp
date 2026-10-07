using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // У меня эндпоинт тут был по умолчанию
app.MapGet("/about", () => endp("about"));
app.MapGet("/contact", () => endp("contact"));
app.MapGet("/student", () => endp("student"));

app.MapGet("/xor/{a}/{b}", (int a, int b) => a ^ b);

List<Book> books = initBooks();

app.MapGet("/books", () => concatBooks(books));
app.MapPost(
    "/books",
    (string title, string author) =>
    {
        books = addBook(books, title, author);
        return concatBooks(books);
    }
);
app.MapDelete(
    "/books/{id}",
    (int id) =>
    {
        books = deleteBook(books, id);
        return concatBooks(books);
    }
);

app.Run();

List<Book> initBooks()
{
    var id = 0;
    return [new(id++, "title", "author"), new(id++, "another titlr", "another author")];
}
List<Book> deleteBook(List<Book> books, int id)
{
    books.RemoveAt(id);
    return books;
}
List<Book> addBook(List<Book> books, string title, string author)
{
    var lastId = books.Last().ID;
    books.Add(new(lastId + 1, title, author));
    Console.WriteLine("result: " + concatBooks(books));
    return books;
}

string concatBooks(List<Book> books)
{
    string result = "";
    foreach (var book in books)
    {
        result += book.ID.ToString() + " - " + book.Title + ": " + book.Author + "\n";
    }
    return result;
}

string endp(string text)
{
    return "это " + text;
}

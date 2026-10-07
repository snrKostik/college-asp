class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        ID = id;
        Title = title;
        Author = author;
    }
}

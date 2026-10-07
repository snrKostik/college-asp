public class Profile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Profile(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public static List<Profile> InitProfiles()
    {
        return [new Profile(1, "first", 20), new Profile(2, "second", 010)];
    }
}

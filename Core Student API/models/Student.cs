public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public static List<Student> InitStudents()
    {
        return [new Student(1, "first", 20), new Student(2, "second", 010)];
    }
}

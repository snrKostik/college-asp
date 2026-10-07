public class StudentService : IStudentService
{
    private static List<Student> students = Student.InitStudents();
    private static int nextId = 3;

    public IEnumerable<Student> GetAll()
    {
        return students.ToList();
    }

    public Student? GetById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public Student Create(CreateStudentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        var newStudent = new Student(nextId++, dto.Name, dto.Age);
        students.Add(newStudent);

        return newStudent;
    }

    public bool Update(int id, UpdateStudentDto dto)
    {
        var student = GetById(id);
        if (student == null)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Name is required");
        }

        student.Name = dto.Name;
        student.Age = dto.Age;

        return true;
    }

    public bool Delete(int id)
    {
        var student = GetById(id);
        if (student == null)
        {
            return false;
        }

        students.Remove(student);
        return true;
    }
}

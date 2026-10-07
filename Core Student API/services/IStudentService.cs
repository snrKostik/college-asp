public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student? GetById(int id);
    Student Create(CreateStudentDto dto);
    bool Update(int id, UpdateStudentDto dto);
    bool Delete(int id);
}

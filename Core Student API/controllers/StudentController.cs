using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetStudents()
    {
        var students = _studentService.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetStudent(int id)
    {
        var student = _studentService.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> CreateStudent([FromBody] CreateStudentDto dto)
    {
        try
        {
            var student = _studentService.Create(dto);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto dto)
    {
        try
        {
            bool updated = _studentService.Update(id, dto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        bool deleted = _studentService.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}

public class CreateStudentDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class UpdateStudentDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

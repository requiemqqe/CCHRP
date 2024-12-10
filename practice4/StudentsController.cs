using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    // Статичний список студентів для прикладу
    private static List<Student> Students = new List<Student>
    {
        new Student { Id = 1, Name = "Alice", Age = 20, Subjects = new List<string> { "Math", "Physics" } },
        new Student { Id = 2, Name = "Bob", Age = 22, Subjects = new List<string> { "History", "Literature" } }
    };

    // GET api/students
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetStudents() => Students;

    // GET api/students/{id}
    [HttpGet("{id}")]
    public ActionResult<Student> GetStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        return student != null ? Ok(student) : NotFound();
    }

    // POST api/students
    [HttpPost]
    public ActionResult AddStudent(Student student)
    {
        student.Id = Students.Max(s => s.Id) + 1; // Генерація нового ID
        Students.Add(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT api/students/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateStudent(int id, Student updatedStudent)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        student.Name = updatedStudent.Name;
        student.Age = updatedStudent.Age;
        student.Subjects = updatedStudent.Subjects;
        return NoContent();
    }

    // DELETE api/students/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        Students.Remove(student);
        return NoContent();
    }
}

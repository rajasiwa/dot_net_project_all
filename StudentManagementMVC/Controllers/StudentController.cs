using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        // Static list to simulate a database
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Marks = 85 },
            new Student { Id = 2, Name = "Bob", Marks = 92 }
        };

        // Index: Display all students
        public IActionResult Index()
        {
            return View(students);
        }

        // Create (GET): Show the create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create (POST): Add a new student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            return RedirectToAction("Index");
        }

        // Edit (GET): Show the edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Edit (POST): Update an existing student
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Marks = updatedStudent.Marks;
            return RedirectToAction("Index");
        }

        // Delete: Remove a student
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}

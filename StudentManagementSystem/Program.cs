using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem
{
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; }

        public override string ToString()
        {
            return $"Roll Number: {RollNumber}, Name: {Name}, Marks: {Marks}";
        }
    }

    class Program
    {
        private static readonly string FilePath = "C:\\Users\\rajas\\OneDrive - Nesfield International College\\dotnet_6\\netcoreappl\\students.txt";

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Save Students to File");
                Console.WriteLine("4. Load Students from File");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        DisplayStudents(students);
                        break;
                    case "3":
                        SaveStudentsToFile(students);
                        break;
                    case "4":
                        LoadStudentsFromFile(students);
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent(List<Student> students)
        {
            try
            {
                Console.Write("Enter Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Marks: ");
                double marks = double.Parse(Console.ReadLine());

                Student student = new Student
                {
                    RollNumber = rollNumber,
                    Name = name,
                    Marks = marks
                };

                students.Add(student);
                Console.WriteLine("Student added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding a student: " + ex.Message);
            }
        }

        static void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("\n--- List of Students ---");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SaveStudentsToFile(List<Student> students)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var student in students)
                    {
                        // Save each student's data on a new line
                        writer.WriteLine($"{student.RollNumber},{student.Name},{student.Marks}");
                    }
                }
                Console.WriteLine("Students saved to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving students: " + ex.Message);
            }
        }

        static void LoadStudentsFromFile(List<Student> students)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine("No file found to load students.");
                    return;
                }

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    students.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Parse each line to create a Student object
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            students.Add(new Student
                            {
                                RollNumber = int.Parse(parts[0]),
                                Name = parts[1],
                                Marks = double.Parse(parts[2])
                            });
                        }
                    }
                }
                Console.WriteLine("Students loaded from file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading students: " + ex.Message);
            }
        }
    }
}

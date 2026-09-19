using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class SubjectStudent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public SubjectStudent() { }

        public SubjectStudent(string id, string name, string semester, string teacher)
        {
            Id = id;
            Name = name;
            Semester = semester;
            Teacher = teacher;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} (ID: {Id})");
            Console.WriteLine($"Semester: {Semester} | Teacher: {Teacher}");
            Console.WriteLine($"Enrollment: {Students.Count} students");

            foreach (var st in Students)
            {
                st.DisplayInfo();
            }
        }
    }
}
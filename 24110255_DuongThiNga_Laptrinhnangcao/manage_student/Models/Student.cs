using System;

namespace StudentManagement.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Midpoint { get; set; }
        public double Potalpoint { get; set; }

        public Student() { }

        public Student(string id, string name, double midpoint, double potalpoint)
        {
            Id = id;
            Name = name;
            Midpoint = midpoint;
            Potalpoint = potalpoint;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[SV] ID: {Id,-6} | Name: {Name,-18} | Midpoint: {Midpoint,-4} | Final Score: {Potalpoint,-4}");
        }
    }
}
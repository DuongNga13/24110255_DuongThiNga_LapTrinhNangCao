using System;
using StudentManagement.Models; 

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("SV001", "Nguyen Van A", 7.5, 8.0);
            Student st2 = new Student("SV002", "Tran Thi B", 8.5, 9.2);

            SubjectStudent lopHocPhan = new SubjectStudent("OOP101", "Lap trinh huong doi tuong", "HK2-2026", "TS. Nguyen Van X");

            lopHocPhan.AddStudent(st1);
            lopHocPhan.AddStudent(st2);

            lopHocPhan.DisplayInfo();

            Console.ReadKey();
        }
    }
}
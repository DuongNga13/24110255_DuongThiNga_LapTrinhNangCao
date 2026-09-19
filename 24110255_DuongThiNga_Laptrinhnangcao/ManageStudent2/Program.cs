using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap.Entity
{
    // include properties: subID, Name, credit, semester, teacher
    public class SubjectStudent
    {
        public string SubID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public string Teacher { get; set; }
        public List<Student> Students { get; set; }
        public SubjectStudent()
        {
            Students =
                [
                new Student { StuID = "S001", Name = "Nguyen Van A", MidPoint = 8.5, FinalPoint = 9.0, Email = "nguyenvana@example.com" },
                new Student { StuID = "S002", Name = "Tran Thi B", MidPoint = 7.0, FinalPoint = 8.0, Email = "tranthib@example.com" },
                new Student { StuID = "S003", Name = "Le Van C", MidPoint = 6.5, FinalPoint = 7.0, Email = "levanc@example.com" },
                new Student { StuID = "S004", Name = "Pham Thi D", MidPoint = 9.0, FinalPoint = 9.5, Email = "phamthid@example.com" },
                ];
        }
        public List<Student> GetStudents() => Students;
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(string stuID)
        {
            Students.RemoveAll(s => s.StuID == stuID);
        }
        public void UpdateStudent(string stuID, Student updatedStudent)
        {
            var student = Students.Find(s => s.StuID == stuID);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.MidPoint = updatedStudent.MidPoint;
                student.FinalPoint = updatedStudent.FinalPoint;
                student.Email = updatedStudent.Email;
            }
        }
        public Student GetStudentById(string stuID)
        {
            return Students.Find(s => s.StuID == stuID);
        }
        public List<Student> getStudentsPassed(double passCondition)
        {
            return Students.FindAll(s => (s.MidPoint + s.FinalPoint) / 2 >= passCondition);
        }
        public List<Student> getStudentsFailed(double passCondition)
        {
            return Students.FindAll(s => (s.MidPoint + s.FinalPoint) / 2 < passCondition);
        }
        // Lấy về danh sách sinh viên mà mỗi sinh viên có điểm midPoint+1
    }
    public List<Student> getStudentsMidPointPlus1()
        {
            //Cách 1: Dùng ForEach để tăng MidPont từng sinh viên 
            Students.ForEach(s => s.MidPoint += 1);
            return Students;


            // Cách 2: Dùng Select để tạo ra danh sách mới với MidPoint + 1
            return Students.Select(s => new Student
            {
                StuID = s.StuID,
                Name = s.Name,
                MidPoint = s.MidPoint + 1,
                FinalPoint = s.FinalPoint,
                Email = s.Email
            }).ToList();
        }
    }
using System;
using System.Text.RegularExpressions;
using ExampleAdvance.Entities;

SubjectStudent subject = new SubjectStudent();

string hoten = "Nguyen       Van Dao   Anh";
hoten = hoten.Trim();

// 1. Dùng Regex.Replace dạng static để chuẩn hóa khoảng trắng
hoten = Regex.Replace(hoten, @"\s+", " ");

// 2. Biểu thức đúng: Bắt đầu bằng 'Nguyen' (^), giữa là ký tự bất kỳ (.*), kết thúc bằng 'Anh' ($)
string reString = @"^Nguyen .* Anh$";
bool isMatch = Regex.IsMatch(hoten, reString);

Console.WriteLine($"Chuoi chuan hoa: {hoten}"); // Nguyen Van Dao Anh
Console.WriteLine($"Ket qua khop: {isMatch}");      // True

/* teacher
using ExampleAdvance.Entities;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
SubjectStudent subject = new SubjectStudent();
String Hoten = "Nguyen       Van Dao   Anh";
Hoten = Hoten.Trim();
Hoten = regex.Replace(Hoten, @"\s+", " ");
String reString = @"^Nguyen \w*\s* $Anh";
Regex regex = new Regex(reString);
bool isMatch = Regex.IsMatch(Hoten, reString);
/*
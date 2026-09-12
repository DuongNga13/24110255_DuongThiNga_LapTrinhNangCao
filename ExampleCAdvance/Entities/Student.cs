namespace ExampleCAdvance.Entities
{
    public class Student
    {
        public string HoTen { get; set; }
        public string MSSV { get; set; }
        public DateTime NgaySinh { get; set; }

        public Student(string hoTen, string mssv, DateTime ngaySinh)
        {
            HoTen = hoTen;
            MSSV = mssv;
            NgaySinh = ngaySinh;
        }

        public override string ToString()
        {
            return $"MSSV: {MSSV} - Họ tên: {HoTen} - Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
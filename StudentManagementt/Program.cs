using System.Windows.Forms;

namespace StudentManagementt
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQuanLySinhVien());
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.Models;

namespace StudentManagement
{
    public partial class StudentManagementForm : Form
    {
        // Danh sách lưu trữ sinh viên trong bộ nhớ
        private BindingList<Student> _studentList = new BindingList<Student>();

        public StudentManagementForm()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            this.Load += StudentManagementForm_Load;
            this.dgvSinhVien.CellClick += DgvSinhVien_CellClick;
            this.btnLamMoi.Click += BtnLamMoi_Click;
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnTimKiem.Click += BtnTimKiem_Click;
            this.btnHienThiTatCa.Click += BtnHienThiTatCa_Click;
        }

        private void StudentManagementForm_Load(object? sender, EventArgs e)
        {
            // Khởi tạo danh sách lớp và trạng thái vào ComboBox
            InitComboBoxes();

            // Nạp dữ liệu mẫu ban đầu
            InitSampleData();

            // Hiển thị dữ liệu lên DataGridView
            BindData(_studentList.ToList());

            // Đặt trạng thái ban đầu cho Form nhập liệu
            ResetInputFields();
        }

        private void InitComboBoxes()
        {
            // Danh sách lớp học
            string[] danhSachLop = { "CNTT K17A", "CNTT K17B", "KTPM K18A", "HTTT K18B", "KHMT K19A" };
            cboLop.Items.Clear();
            cboLop.Items.AddRange(danhSachLop);
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;

            // Danh sách trạng thái
            string[] danhSachTrangThai = { "Đang học", "Thôi học", "Tốt nghiệp" };
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(danhSachTrangThai);
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            // ComboBox lọc lớp học
            cboFilterLop.Items.Clear();
            cboFilterLop.Items.Add("-- Tất cả lớp --");
            cboFilterLop.Items.AddRange(danhSachLop);
            cboFilterLop.SelectedIndex = 0;
        }

        private void InitSampleData()
        {
            _studentList = new BindingList<Student>
            {
                new Student("SV001", "Nguyễn Văn An", new DateTime(2003, 5, 12), "Nam", "an.nv@vju.edu.vn", "0912345678", 8.5, "CNTT K17A", "Đang học"),
                new Student("SV002", "Trần Thị Mai", new DateTime(2004, 11, 20), "Nữ", "mai.tt@vju.edu.vn", "0987654321", 9.0, "KTPM K18A", "Đang học"),
                new Student("SV003", "Lê Hoàng Nam", new DateTime(2003, 8, 15), "Nam", "nam.lh@vju.edu.vn", "0905123456", 6.8, "CNTT K17B", "Đang học"),
                new Student("SV004", "Phạm Quỳnh Chi", new DateTime(2002, 3, 28), "Nữ", "chi.pq@vju.edu.vn", "0934567890", 9.2, "HTTT K18B", "Tốt nghiệp"),
                new Student("SV005", "Đặng Minh Quân", new DateTime(2005, 1, 9), "Nam", "quan.dm@vju.edu.vn", "0978112233", 4.5, "KHMT K19A", "Thôi học"),
                new Student("SV006", "Hoàng Thu Thảo", new DateTime(2004, 7, 24), "Nữ", "thao.ht@vju.edu.vn", "0945678123", 7.6, "CNTT K17A", "Đang học")
            };
        }

        private void BindData(List<Student> list)
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = list;

            // Cập nhật nhãn tổng số sinh viên
            lblTongSo.Text = $"Tổng số: {list.Count} sinh viên";
        }

        /// <summary>
        /// Sự kiện CellClick trên DataGridView: Đổ dữ liệu của dòng được chọn ngược lại các Controls nhập liệu
        /// </summary>
        private void DgvSinhVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

            var student = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as Student;
            if (student == null) return;

            txtMaSV.Text = student.MaSV;
            txtHoTen.Text = student.HoTen;
            dtpNgaySinh.Value = student.NgaySinh;

            if (student.GioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
            {
                rdoNu.Checked = true;
            }
            else
            {
                rdoNam.Checked = true;
            }

            txtEmail.Text = student.Email;
            txtDienThoai.Text = student.DienThoai;
            txtDiem.Text = student.Diem.ToString("0.0");

            if (cboLop.Items.Contains(student.Lop))
            {
                cboLop.SelectedItem = student.Lop;
            }

            if (cboTrangThai.Items.Contains(student.TrangThai))
            {
                cboTrangThai.SelectedItem = student.TrangThai;
            }
        }

        /// <summary>
        /// Sự kiện Click nút Làm mới: Xóa trắng form nhập liệu và bỏ chọn trên bảng
        /// </summary>
        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            ResetInputFields();
        }

        private void ResetInputFields()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now.AddYears(-20);
            rdoNam.Checked = true;
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtDiem.Clear();

            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            dgvSinhVien.ClearSelection();
            txtMaSV.Focus();
        }

        /// <summary>
        /// Sự kiện Click nút Thêm: Kiểm tra tính hợp lệ và thêm sinh viên mới
        /// </summary>
        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out string maSV, out string hoTen, out double diem, out string email, out string dienThoai))
            {
                return;
            }

            // Kiểm tra trùng mã sinh viên
            if (_studentList.Any(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Mã sinh viên '{maSV}' đã tồn tại trong hệ thống!", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            string gioiTinh = rdoNu.Checked ? "Nữ" : "Nam";
            string lop = cboLop.SelectedItem?.ToString() ?? "";
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học";

            var newStudent = new Student(maSV, hoTen, dtpNgaySinh.Value, gioiTinh, email, dienThoai, diem, lop, trangThai);
            _studentList.Add(newStudent);

            // Làm mới hiển thị
            BindData(_studentList.ToList());
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetInputFields();
        }

        /// <summary>
        /// Sự kiện Click nút Sửa: Cập nhật thông tin sinh viên theo Mã sinh viên đang chọn
        /// </summary>
        private void BtnSua_Click(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã sinh viên cần sửa thông tin!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            var student = _studentList.FirstOrDefault(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (student == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}' để cập nhật!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput(out _, out string hoTen, out double diem, out string email, out string dienThoai))
            {
                return;
            }

            student.HoTen = hoTen;
            student.NgaySinh = dtpNgaySinh.Value;
            student.GioiTinh = rdoNu.Checked ? "Nữ" : "Nam";
            student.Email = email;
            student.DienThoai = dienThoai;
            student.Diem = diem;
            student.Lop = cboLop.SelectedItem?.ToString() ?? "";
            student.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học";

            BindData(_studentList.ToList());
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sự kiện Click nút Xóa: Xác nhận và xóa sinh viên khỏi danh sách
        /// </summary>
        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa trong bảng hoặc nhập Mã sinh viên!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = _studentList.FirstOrDefault(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (student == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}' để xóa!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên [{student.MaSV} - {student.HoTen}]?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                _studentList.Remove(student);
                BindData(_studentList.ToList());
                ResetInputFields();
                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Sự kiện Click nút Tìm kiếm: Lọc theo Từ khóa (Mã SV, Họ tên), Lớp và Điểm tối thiểu
        /// </summary>
        private void BtnTimKiem_Click(object? sender, EventArgs e)
        {
            string keyword = txtTuKhoa.Text.Trim().ToLower();
            string selectedClass = cboFilterLop.SelectedItem?.ToString() ?? "";
            bool hasScoreFilter = double.TryParse(txtDiemTu.Text.Trim(), out double minScore);

            var query = _studentList.AsEnumerable();

            // Lọc theo từ khóa (Mã sinh viên hoặc Họ tên)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(s => s.MaSV.ToLower().Contains(keyword) || s.HoTen.ToLower().Contains(keyword));
            }

            // Lọc theo lớp học
            if (!string.IsNullOrEmpty(selectedClass) && selectedClass != "-- Tất cả lớp --")
            {
                query = query.Where(s => s.Lop.Equals(selectedClass, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo điểm tối thiểu
            if (hasScoreFilter)
            {
                query = query.Where(s => s.Diem >= minScore);
            }

            var result = query.ToList();
            BindData(result);
        }

        /// <summary>
        /// Sự kiện Click nút Hiển thị tất cả: Đặt lại bộ lọc và hiển thị toàn bộ danh sách
        /// </summary>
        private void BtnHienThiTatCa_Click(object? sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cboFilterLop.SelectedIndex = 0;
            txtDiemTu.Clear();
            BindData(_studentList.ToList());
        }

        /// <summary>
        /// Kiểm tra dữ liệu đầu vào khi Thêm / Sửa
        /// </summary>
        private bool ValidateInput(out string maSV, out string hoTen, out double diem, out string email, out string dienThoai)
        {
            maSV = txtMaSV.Text.Trim();
            hoTen = txtHoTen.Text.Trim();
            email = txtEmail.Text.Trim();
            dienThoai = txtDienThoai.Text.Trim();
            diem = 0;

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ và tên sinh viên không được để trống!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!double.TryParse(txtDiem.Text.Trim(), out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm số phải là một số hợp lệ từ 0 đến 10!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return false;
            }

            return true;
        }
    }
}

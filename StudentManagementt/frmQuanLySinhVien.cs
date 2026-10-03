using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementt
{
    public partial class frmQuanLySinhVien : Form
    {
        // 1. Danh sách lưu trữ sinh viên tạm thời trong bộ nhớ
        private BindingList<Student> _studentList = new BindingList<Student>();
        public frmQuanLySinhVien()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu và gán sự kiện khi Form bắt đầu chạy
            LoadDataSample();
            InitComboBoxData();
            BindGrid();
            RegisterEvents();

        }

        // Sự kiện tự sinh khi bạn lỡ click đúp vào panel1 (có thể để trống)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // 2. Tạo dữ liệu mẫu giống hệt hình bài thực hành
        private void LoadDataSample()
        {
            _studentList.Add(new Student { MaSV = "SV000123", HoTen = "Nguyễn Văn An", NgaySinh = "01/01/2006", GioiTinh = "Nam", Email = "an.nv@st.vju.ac.vn", DienThoai = "0912345678", Diem = 9.5, Lop = "Kỹ thuật phần mềm 01", TrangThai = "Đang học" });
            _studentList.Add(new Student { MaSV = "SV000124", HoTen = "Ngô Khắc Anh", NgaySinh = "02/02/2006", GioiTinh = "Nữ", Email = "anh.nk@st.vju.ac.vn", DienThoai = "0901054321", Diem = 9.0, Lop = "Trí tuệ nhân tạo 01", TrangThai = "Đang học" });
            _studentList.Add(new Student { MaSV = "SV000125", HoTen = "Lê Hoàng Bình", NgaySinh = "03/03/2006", GioiTinh = "Nam", Email = "binh.lh@st.vju.ac.vn", DienThoai = "0920366977", Diem = 7.8, Lop = "Kỹ thuật phần mềm 02", TrangThai = "Đang học" });
            _studentList.Add(new Student { MaSV = "SV000126", HoTen = "Đỗ Thế Hùng", NgaySinh = "04/04/2006", GioiTinh = "Nữ", Email = "hung.dt@st.vju.ac.vn", DienThoai = "0977889999", Diem = 8.1, Lop = "Khoa học dữ liệu 01", TrangThai = "Đang học" });
        }

        // 3. Khởi tạo danh sách cho các ComboBox (Lớp, Trạng thái)
        private void InitComboBoxData()
        {
            string[] danhSachLop = { "Kỹ thuật phần mềm 01", "Kỹ thuật phần mềm 02", "Trí tuệ nhân tạo 01", "Khoa học dữ liệu 01" };

            if (cboLop != null) cboLop.Items.AddRange(danhSachLop);
            if (cboLopFilter != null)
            {
                cboLopFilter.Items.Add("Tất cả các lớp");
                cboLopFilter.Items.AddRange(danhSachLop);
                cboLopFilter.SelectedIndex = 0;
            }

            string[] trangThai = { "Đang học", "Đã tốt nghiệp", "Bảo lưu", "Thôi học" };
            if (cboTrangThai != null)
            {
                cboTrangThai.Items.AddRange(trangThai);
                cboTrangThai.SelectedIndex = 0;
            }
        }

        // 4. Hiển thị dữ liệu lên DataGridView & đếm số sinh viên
        private void BindGrid()
        {
            if (dgvSinhVien != null)
            {
                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = _studentList;
            }
            if (lblTongSo != null)
            {
                lblTongSo.Text = $"Tổng số: {_studentList.Count} sinh viên";
            }
        }

        // 5. Đăng ký các sự kiện Click nút bấm
        private void RegisterEvents()
        {
            if (dgvSinhVien != null) dgvSinhVien.CellClick += DgvSinhVien_CellClick;
            if (btnLamMoi != null) btnLamMoi.Click += BtnLamMoi_Click;
            if (btnThem != null) btnThem.Click += BtnThem_Click;
            if (btnSua != null) btnSua.Click += BtnSua_Click;
            if (btnXoa != null) btnXoa.Click += BtnXoa_Click;
            if (btnTimKiem != null) btnTimKiem.Click += BtnTimKiem_Click;
            if (btnHienThi != null) btnHienThi.Click += (s, e) => BindGrid();
        }

        // Sự kiện: Bấm vào 1 dòng trong bảng sẽ đẩy thông tin lên các ô nhập
        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSinhVien.Rows.Count)
            {
                var row = dgvSinhVien.Rows[e.RowIndex];
                if (txtMaSV != null) txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
                if (txtHoTen != null) txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                if (dtpNgaySinh != null && row.Cells["NgaySinh"].Value != null)
                    dtpNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();

                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                if (rdoNam != null) rdoNam.Checked = (gioiTinh == "Nam");
                if (rdoNu != null) rdoNu.Checked = (gioiTinh == "Nữ");

                if (txtEmail != null) txtEmail.Text = row.Cells["Email"].Value?.ToString();
                if (txtDienThoai != null) txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
                if (txtDiem != null) txtDiem.Text = row.Cells["Diem"].Value?.ToString();
                if (cboLop != null) cboLop.SelectedItem = row.Cells["Lop"].Value?.ToString();
                if (cboTrangThai != null) cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value?.ToString();
            }
        }

        // Thêm sinh viên mới
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV?.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sv = new Student
            {
                MaSV = txtMaSV.Text,
                HoTen = txtHoTen?.Text ?? "",
                NgaySinh = dtpNgaySinh?.Value.ToString("dd/MM/yyyy") ?? "",
                GioiTinh = (rdoNam != null && rdoNam.Checked) ? "Nam" : "Nữ",
                Email = txtEmail?.Text ?? "",
                DienThoai = txtDienThoai?.Text ?? "",
                Diem = double.TryParse(txtDiem?.Text, out double d) ? d : 0,
                Lop = cboLop?.SelectedItem?.ToString() ?? "",
                TrangThai = cboTrangThai?.SelectedItem?.ToString() ?? "Đang học"
            };

            _studentList.Add(sv);
            BindGrid();
            BtnLamMoi_Click(null, null);
        }

        // Sửa sinh viên
        private void BtnSua_Click(object sender, EventArgs e)
        {
            var sv = _studentList.FirstOrDefault(x => x.MaSV == txtMaSV?.Text);
            if (sv != null)
            {
                sv.HoTen = txtHoTen?.Text ?? "";
                sv.NgaySinh = dtpNgaySinh?.Value.ToString("dd/MM/yyyy") ?? "";
                sv.GioiTinh = (rdoNam != null && rdoNam.Checked) ? "Nam" : "Nữ";
                sv.Email = txtEmail?.Text ?? "";
                sv.DienThoai = txtDienThoai?.Text ?? "";
                sv.Diem = double.TryParse(txtDiem?.Text, out double d) ? d : 0;
                sv.Lop = cboLop?.SelectedItem?.ToString() ?? "";
                sv.TrangThai = cboTrangThai?.SelectedItem?.ToString() ?? "Đang học";

                BindGrid();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Xóa sinh viên
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var sv = _studentList.FirstOrDefault(x => x.MaSV == txtMaSV?.Text);
            if (sv != null && MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _studentList.Remove(sv);
                BindGrid();
                BtnLamMoi_Click(null, null);
            }
        }

        // Làm mới các ô nhập
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV?.Clear();
            txtHoTen?.Clear();
            txtEmail?.Clear();
            txtDienThoai?.Clear();
            txtDiem?.Clear();
            if (rdoNam != null) rdoNam.Checked = true;
            if (cboLop != null && cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboTrangThai != null && cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            txtMaSV?.Focus();
        }

        // Tìm kiếm sinh viên
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTuKhoa?.Text.ToLower() ?? "";
            string lopSelect = cboLopFilter?.SelectedItem?.ToString() ?? "";

            var filtered = _studentList.Where(s =>
                (string.IsNullOrEmpty(kw) || s.MaSV.ToLower().Contains(kw) || s.HoTen.ToLower().Contains(kw) || s.Email.ToLower().Contains(kw)) &&
                (string.IsNullOrEmpty(lopSelect) || lopSelect == "Tất cả các lớp" || s.Lop == lopSelect)
            ).ToList();

            if (dgvSinhVien != null) dgvSinhVien.DataSource = filtered;
            if (lblTongSo != null) lblTongSo.Text = $"Tổng số: {filtered.Count} sinh viên";
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDataSample();
            txtMaSV.Focus();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            dgvSinhVien.DataSource = _studentList;
            lblTongSo.Text = $"Tổng số: {_studentList.Count} sinh viên";
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void maSV_enter(object sender, EventArgs e)
        {
            txtMaSV.SelectAll();
            txtMaSV.Focus();
        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void lblMaSV_Click(object sender, EventArgs e)
        {

        }

        private void lblDiem_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void lblTongSo_Click(object sender, EventArgs e)
        {
            // Hàm xử lý sự kiện click vào nhãn Tổng số
        }
    }

    // Lớp đối tượng Sinh viên
    public class Student
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public double Diem { get; set; }
        public string Lop { get; set; }
        public string TrangThai { get; set; }
    }
}
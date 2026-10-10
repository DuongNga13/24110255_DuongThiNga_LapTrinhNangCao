using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentManagementt.BUL;
using StudentManagementt.Data.Entity;

namespace StudentManagementt
{
    public partial class frmQuanLySinhVien : Form
    {
        private readonly SinhVienBUL _svBUL = new();
        private readonly LopHocBUL _lopBUL = new();
        private List<LopHoc> _cachedLopList = new();

        private static readonly Dictionary<string, string> ColumnHeaderMap = new()
        {
            ["MaSV"] = "Mã SV",
            ["HoTen"] = "Họ và tên",
            ["NgaySinh"] = "Ngày sinh",
            ["GioiTinh"] = "Giới tính",
            ["Email"] = "Email",
            ["DienThoai"] = "Điện thoại",
            ["Diem"] = "Điểm",
            ["MaLop"] = "Lớp",
            ["TrangThai"] = "Trạng thái",
        };

        public frmQuanLySinhVien()
        {
            InitializeComponent();
            _cachedLopList = _lopBUL.GetAll();
            InitComboBoxes();
            RefreshGrid(_svBUL.GetAll());
            BindEventHandlers();
        }

        // ── Khởi tạo ─────────────────────────────────────────────────────

        private void InitComboBoxes()
        {
            cboLop.DataSource = new List<LopHoc>(_cachedLopList);
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboLopFilter.Items.Clear();
            cboLopFilter.Items.Add("Tất cả các lớp");
            foreach (var lop in _cachedLopList)
                cboLopFilter.Items.Add(lop.TenLop);
            cboLopFilter.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new[] { "Đang học", "Đã tốt nghiệp", "Bảo lưu", "Thôi học" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void BindEventHandlers()
        {
            dgvSinhVien.CellClick += OnGridCellClick;
            btnThem.Click += OnAddClick;
            btnSua.Click += OnUpdateClick;
            btnXoa.Click += OnDeleteClick;
            btnLamMoi.Click += (_, _) => ResetForm();
            btnTimKiem.Click += OnSearchClick;
            btnHienThi.Click += (_, _) => RefreshGrid(_svBUL.GetAll());
        }

        // ── Hiển thị dữ liệu ─────────────────────────────────────────────

        private void RefreshGrid(List<SinhVien> data)
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = data;
            ApplyColumnHeaders();
            lblTongSo.Text = $"Tổng số: {data.Count} sinh viên";
        }

        private void ApplyColumnHeaders()
        {
            foreach (DataGridViewColumn col in dgvSinhVien.Columns)
                if (ColumnHeaderMap.TryGetValue(col.Name, out string? label))
                    col.HeaderText = label;
        }

        // ── Sự kiện ──────────────────────────────────────────────────────

        private void OnGridCellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

            var row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = CellText(row, "MaSV");
            txtHoTen.Text = CellText(row, "HoTen");
            txtEmail.Text = CellText(row, "Email");
            txtDienThoai.Text = CellText(row, "DienThoai");
            txtDiem.Text = CellText(row, "Diem");

            if (row.Cells["NgaySinh"].Value is DateTime ngaySinh)
                dtpNgaySinh.Value = ngaySinh;

            bool isNam = CellText(row, "GioiTinh") == "Nam";
            rdoNam.Checked = isNam;
            rdoNu.Checked = !isNam;

            cboLop.SelectedValue = CellText(row, "MaLop");
            cboTrangThai.SelectedItem = CellText(row, "TrangThai");
        }

        private void OnAddClick(object? sender, EventArgs e)
        {
            string? error = _svBUL.Add(ReadFormData());
            if (error != null) { ShowWarning(error); return; }

            RefreshGrid(_svBUL.GetAll());
            ResetForm();
            ShowInfo("Thêm sinh viên thành công!");
        }

        private void OnUpdateClick(object? sender, EventArgs e)
        {
            string? error = _svBUL.Update(ReadFormData());
            if (error != null) { ShowWarning(error); return; }

            RefreshGrid(_svBUL.GetAll());
            ShowInfo("Cập nhật thông tin thành công!");
        }

        private void OnDeleteClick(object? sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV)) { ShowWarning("Vui lòng chọn sinh viên cần xoá."); return; }

            if (!Confirm($"Bạn có chắc muốn xoá sinh viên '{maSV}'?")) return;

            string? error = _svBUL.Delete(maSV);
            if (error != null) { ShowError(error); return; }

            RefreshGrid(_svBUL.GetAll());
            ResetForm();
            ShowInfo("Đã xoá sinh viên thành công!");
        }

        private void OnSearchClick(object? sender, EventArgs e)
        {
            string keyword = txtTuKhoa.Text.Trim();
            string tenLop = cboLopFilter.SelectedItem?.ToString() ?? "";
            string maLop = tenLop == "Tất cả các lớp"
                ? ""
                : _cachedLopList.Find(l => l.TenLop == tenLop)?.MaLop ?? "";

            RefreshGrid(_svBUL.Search(keyword, maLop));
        }

        // ── Tiện ích ─────────────────────────────────────────────────────

        private SinhVien ReadFormData() => new()
        {
            MaSV = txtMaSV.Text.Trim(),
            HoTen = txtHoTen.Text.Trim(),
            NgaySinh = dtpNgaySinh.Value.Date,
            GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
            Email = txtEmail.Text.Trim(),
            DienThoai = txtDienThoai.Text.Trim(),
            Diem = double.TryParse(txtDiem.Text, out double d) ? d : -1,
            MaLop = cboLop.SelectedValue?.ToString() ?? "",
            TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học",
        };

        private void ResetForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtDiem.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            txtMaSV.Focus();
        }

        private static string CellText(DataGridViewRow row, string colName)
            => row.Cells[colName]?.Value?.ToString() ?? string.Empty;

        private static void ShowInfo(string msg)
            => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void ShowWarning(string msg)
            => MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ShowError(string msg)
            => MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private static bool Confirm(string msg)
            => MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // ── Handlers auto-generated (giữ lại để Designer không báo lỗi) ─
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void frmQuanLySinhVien_Load(object sender, EventArgs e) { }
        private void maSV_enter(object sender, EventArgs e) => txtMaSV.SelectAll();
        private void txtDiem_TextChanged(object sender, EventArgs e) { }
        private void btnTimKiem_Click_1(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void Form1_Load_1(object sender, EventArgs e) { }
        private void lblMaSV_Click(object sender, EventArgs e) { }
        private void lblDiem_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void btnHienThi_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void lblTongSo_Click(object sender, EventArgs e) { }
        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e) { }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
namespace StudentManagementt
{
    partial class frmQuanLySinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            grpInput = new GroupBox();
            textBox1 = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblNgaySinh = new Label();
            lblGioiTinh = new Label();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblDiem = new Label();
            txtDiem = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTuKhoa = new TextBox();
            cboLopFilter = new ComboBox();
            btnTimKiem = new Button();
            btnHienThi = new Button();
            lblTongSo = new Label();
            dgvSinhVien = new DataGridView();
            label1 = new Label();
            lblTuKhoa = new Label();
            lblLophoc = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            panelHeader.SuspendLayout();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(999, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(12, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(326, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            lblTitle.Click += lblTitle_Click;
            // 
            // grpInput
            // 
            grpInput.Controls.Add(textBox1);
            grpInput.Controls.Add(dtpNgaySinh);
            grpInput.Controls.Add(lblMaSV);
            grpInput.Controls.Add(txtMaSV);
            grpInput.Controls.Add(lblHoTen);
            grpInput.Controls.Add(txtHoTen);
            grpInput.Controls.Add(lblLop);
            grpInput.Controls.Add(cboLop);
            grpInput.Controls.Add(lblNgaySinh);
            grpInput.Controls.Add(lblGioiTinh);
            grpInput.Controls.Add(rdoNam);
            grpInput.Controls.Add(rdoNu);
            grpInput.Controls.Add(lblDiem);
            grpInput.Controls.Add(txtDiem);
            grpInput.Controls.Add(lblEmail);
            grpInput.Controls.Add(txtEmail);
            grpInput.Controls.Add(lblDienThoai);
            grpInput.Controls.Add(txtDienThoai);
            grpInput.Controls.Add(lblTrangThai);
            grpInput.Controls.Add(cboTrangThai);
            grpInput.Location = new Point(33, 60);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(933, 140);
            grpInput.TabIndex = 1;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sinh viên";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 137);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 20;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(100, 58);
            dtpNgaySinh.MaxDate = new DateTime(2026, 10, 3, 0, 0, 0, 0);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(180, 31);
            dtpNgaySinh.TabIndex = 1;
            dtpNgaySinh.Value = new DateTime(2026, 3, 10, 0, 0, 0, 0);
            dtpNgaySinh.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblMaSV
            // 
            lblMaSV.Location = new Point(15, 30);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(79, 23);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã SV *";
            lblMaSV.Click += lblMaSV_Click;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(100, 22);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.PlaceholderText = "24110222";
            txtMaSV.Size = new Size(180, 31);
            txtMaSV.TabIndex = 0;
            txtMaSV.KeyPress += txtMaSV_KeyPress;
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(297, 27);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(91, 23);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên *";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(390, 22);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "Dương Nga";
            txtHoTen.Size = new Size(200, 31);
            txtHoTen.TabIndex = 3;
            // 
            // lblLop
            // 
            lblLop.Location = new Point(610, 32);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(89, 23);
            lblLop.TabIndex = 4;
            lblLop.Text = "Lớp học *";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(705, 22);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(210, 33);
            cboLop.TabIndex = 7;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.Location = new Point(0, 65);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(94, 23);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.Location = new Point(310, 59);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(83, 23);
            lblGioiTinh.TabIndex = 8;
            lblGioiTinh.Text = "Giới tính";
            // 
            // rdoNam
            // 
            rdoNam.Checked = true;
            rdoNam.Location = new Point(399, 58);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(77, 24);
            rdoNam.TabIndex = 4;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            // 
            // rdoNu
            // 
            rdoNu.Location = new Point(486, 60);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(104, 24);
            rdoNu.TabIndex = 5;
            rdoNu.Text = "Nữ";
            // 
            // lblDiem
            // 
            lblDiem.Location = new Point(626, 63);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(73, 23);
            lblDiem.TabIndex = 11;
            lblDiem.Text = "Điểm *";
            lblDiem.Click += lblDiem_Click;
            // 
            // txtDiem
            // 
            txtDiem.Location = new Point(705, 56);
            txtDiem.Name = "txtDiem";
            txtDiem.PlaceholderText = "0.0";
            txtDiem.Size = new Size(210, 31);
            txtDiem.TabIndex = 8;
            txtDiem.TextChanged += txtDiem_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(26, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(68, 23);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "abc@st.vju.ac.vn";
            txtEmail.Size = new Size(180, 31);
            txtEmail.TabIndex = 2;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblDienThoai
            // 
            lblDienThoai.Location = new Point(297, 100);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(96, 23);
            lblDienThoai.TabIndex = 15;
            lblDienThoai.Text = "Điện thoại *";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(390, 92);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.PlaceholderText = "0926254364";
            txtDienThoai.Size = new Size(200, 31);
            txtDienThoai.TabIndex = 6;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Location = new Point(610, 100);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(89, 23);
            lblTrangThai.TabIndex = 17;
            lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(705, 90);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(210, 33);
            cboTrangThai.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.ForestGreen;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(559, 208);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(85, 32);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.SteelBlue;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(654, 208);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(85, 32);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(749, 208);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 32);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.SlateGray;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(844, 208);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(85, 32);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(112, 259);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txtTuKhoa.Size = new Size(274, 31);
            txtTuKhoa.TabIndex = 14;
            // 
            // cboLopFilter
            // 
            cboLopFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLopFilter.Location = new Point(449, 259);
            cboLopFilter.Name = "cboLopFilter";
            cboLopFilter.Size = new Size(81, 33);
            cboLopFilter.TabIndex = 15;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.SteelBlue;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(709, 262);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 31);
            btnTimKiem.TabIndex = 17;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click_1;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(805, 262);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(139, 31);
            btnHienThi.TabIndex = 18;
            btnHienThi.Text = "Hiển thị tất cả";
            btnHienThi.Click += btnHienThi_Click;
            // 
            // lblTongSo
            // 
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 7F);
            lblTongSo.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblTongSo.Location = new Point(817, 303);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(131, 19);
            lblTongSo.TabIndex = 10;
            lblTongSo.Text = "Tổng số: 0 sinh viên";
            lblTongSo.Click += lblTongSo_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeight = 34;
            dgvSinhVien.Location = new Point(17, 325);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 62;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(933, 250);
            dgvSinhVien.TabIndex = 11;
            dgvSinhVien.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 303);
            label1.Name = "label1";
            label1.Size = new Size(162, 21);
            label1.TabIndex = 10;
            label1.Text = "Danh sách sinh viên";
            label1.Click += label1_Click;
            // 
            // lblTuKhoa
            // 
            lblTuKhoa.Location = new Point(33, 262);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(84, 23);
            lblTuKhoa.TabIndex = 13;
            lblTuKhoa.Text = "Từ khóa";
            lblTuKhoa.Click += label2_Click;
            // 
            // lblLophoc
            // 
            lblLophoc.AccessibleName = "lblDiem";
            lblLophoc.Location = new Point(550, 263);
            lblLophoc.Name = "lblLophoc";
            lblLophoc.Size = new Size(85, 23);
            lblLophoc.TabIndex = 13;
            lblLophoc.Text = "Điểm từ";
            lblLophoc.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(634, 259);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "0.0";
            textBox2.Size = new Size(69, 31);
            textBox2.TabIndex = 16;
            // 
            // label2
            // 
            label2.AccessibleName = "lblLopHoc";
            label2.Location = new Point(398, 264);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 13;
            label2.Text = "Lớp";
            label2.Click += label2_Click;
            // 
            // frmQuanLySinhVien
            // 
            AccessibleName = "lblDiem";
            AutoSize = true;
            ClientSize = new Size(999, 633);
            Controls.Add(panelHeader);
            Controls.Add(grpInput);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTuKhoa);
            Controls.Add(cboLopFilter);
            Controls.Add(btnTimKiem);
            Controls.Add(btnHienThi);
            Controls.Add(label1);
            Controls.Add(lblTongSo);
            Controls.Add(dgvSinhVien);
            Controls.Add(label2);
            Controls.Add(lblLophoc);
            Controls.Add(lblTuKhoa);
            Controls.Add(textBox2);
            Name = "frmQuanLySinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý sinh viên";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblMaSV;         private System.Windows.Forms.Label lblHoTen; private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblLop; private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblNgaySinh;         private System.Windows.Forms.Label lblGioiTinh; private System.Windows.Forms.RadioButton rdoNam; private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblDiem; private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label lblEmail;         private System.Windows.Forms.Label lblDienThoai; private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblTrangThai; private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.ComboBox cboLopFilter;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private DateTimePicker dtpNgaySinh;
        private TextBox textBox1;
        private TextBox txtMaSV;
        private TextBox txtEmail;
        private Label label1;
        private Label lblTuKhoa;
        private Label lblLophoc;
        private TextBox textBox2;
        private Label label2;
    }
}
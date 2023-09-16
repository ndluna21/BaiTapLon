using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmHoaDon : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string username;
        string SoHDB;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void LoadDataHD()
        {
            DataTable dthd = dtb.DataReader("SELECT * FROM Hoa_Don_Ban WHERE Username = '" + username + "' or SoHDB = '"+SoHDB+"'");
            dgvHoaDon.DataSource = dthd;
        }
        public string Message
        {
            get { return username; }
            set { username = value; }
        }
        public string Sohdb
        {
            get { return SoHDB; }
            set { SoHDB = value; }

        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDB.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            txtMaNV.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
            txtMaKH.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            txtNgayBan.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();
            txtTongTien.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
            txtUsername.Text = dgvHoaDon.CurrentRow.Cells[5].Value.ToString();
            btnChiTiet.Enabled = true;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataHD();
            dgvHoaDon.Columns[0].HeaderText = "Số HDB";
            dgvHoaDon.Columns[1].HeaderText = "Mã NV";
            dgvHoaDon.Columns[2].HeaderText = "Mã KH";
            dgvHoaDon.Columns[3].HeaderText = "Ngày Bán";
            dgvHoaDon.Columns[4].HeaderText = "Tổng Tiền";
            dgvHoaDon.Columns[5].HeaderText = "Username";
            HoaDonEnable();
            
            btnChiTiet.Enabled = false;
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Sohdb = txtSoHDB.Text;
            
            f5.Message = username;
            f5.Show();
            this.Hide();
        }

        void HoaDonEnable()
        {
            txtMaKH.Enabled = false;
            txtMaNV.Enabled = false;
            txtNgayBan.Enabled = false;
            txtSoHDB.Enabled = false;
            txtTongTien.Enabled = false;
            txtUsername.Enabled = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frmNguoiDung f2 = new frmNguoiDung();
            f2.Message = username;
            f2.Show();
            this.Hide();
        }
    }
}

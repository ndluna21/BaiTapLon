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
    public partial class Form5 : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string SoHDB, SoHDN, username;
        public Form5()
        {
            InitializeComponent();
        }
        public void LoadDataCTHDB()
        {
            DataTable dthd = dtb.DataReader("SELECT * FROM ChiTietHDB WHERE SoHDB = '" + SoHDB + "'");
            dgvCTHD.DataSource = dthd;
        }
        public void LoadDataCTHDN()
        {
            DataTable dthdn = dtb.DataReader("SELECT * FROM ChiTietHDN WHERE SoHDN = '" + SoHDN + "'");
            dgvCTHD.DataSource = dthdn;
        }
        public string Sohdn
        {
            get { return SoHDN; }
            set { SoHDN = value; }
        }
        public string Sohdb
        {
            get { return SoHDB; }
            set { SoHDB = value; }
        }
        public string Message
        {
            get { return username; }
            set { username = value; }
        }
        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDB.Text = dgvCTHD.CurrentRow.Cells[0].Value.ToString();
            txtMaHang.Text = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dgvCTHD.CurrentRow.Cells[2].Value.ToString();
            txtGiamGia.Text = dgvCTHD.CurrentRow.Cells[3].Value.ToString();
            txtThanhTien.Text = dgvCTHD.CurrentRow.Cells[4].Value.ToString();
        }
        private void Form5_Load(object sender, EventArgs e)
        {            
            if(Sohdb.Trim() != "")
            {
                MessageBox.Show("Số Hoá Đơn Bán: " + Sohdb);
                LoadDataCTHDB();
            }
            dgvCTHD.Columns[0].HeaderText = "Số HDB";
            dgvCTHD.Columns[1].HeaderText = "Mã Hàng";
            dgvCTHD.Columns[2].HeaderText = "Số Lượng";
            dgvCTHD.Columns[3].HeaderText = "Giảm Giá";
            dgvCTHD.Columns[4].HeaderText = "Thành Tiền";
        }
        private void btnQuayLaiCH_Click(object sender, EventArgs e)
        {
            frmNguoiDung f2 = new frmNguoiDung();
            f2.Message = username;
            f2.Show();
            this.Hide();
        }
        private void btnQuayLaiHD_Click(object sender, EventArgs e)
        {
            string nv = "nv";
            if (username.Contains(nv.ToUpper()))
            {
                frmAdmin fad = new frmAdmin();
                fad.Message = username;
                fad.Show();
            }
            else
            {
                frmHoaDon f3 = new frmHoaDon();
                f3.Message = Sohdb;
                f3.Show();
                this.Hide();
            }
        }
    }
}

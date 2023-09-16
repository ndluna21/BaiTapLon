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
    public partial class frmDangKi : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string makh;
        public frmDangKi()
        {
            InitializeComponent();
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPass.Text == "" || txtNhapLaiPass.Text == "" ||
                txtDiaChi.Text == "" || txtSDT.Text == "" || txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin, mời xem lại");
            }
            else
            {
                if (String.Compare(txtPass.Text, txtNhapLaiPass.Text, false) == 0)
                {
                    lbThongBao.Text = "Mật khẩu ở 2 trường không giống nhau";
                }
                else
                {
                    int count = 0;
                    count = dataGridView1.Rows.Count;
                    string chuoi = "";
                    int chuoi2 = 0;
                    chuoi = Convert.ToString(dataGridView1.Rows[count - 2].Cells[0].Value);
                    chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
                    if (chuoi2 + 1 < 10)
                    {
                        txtMaKH.Text = "KH00" + (chuoi2 + 1).ToString();
                    }
                    else if (chuoi2 + 1 < 100)
                    {
                        txtMaKH.Text = "KH0" + (chuoi2 + 1).ToString();
                    }
                    else
                    {
                        txtMaKH.Text = "KH" + (chuoi2 + 1).ToString();
                    }
                    DataTable dtkh = dtb.DataReader("SELECT Username FROM Khach_Hang WHERE Username = '"+txtUsername.Text+"'");
                    if (dtkh.Rows.Count > 0)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tại");
                    }
                    else
                    {
                        string sql = "INSERT INTO UserName VALUES ('" + txtUsername.Text + "','" + txtPass.Text + "')";
                        dtb.DataReader(sql);
                        string sqlIn = "INSERT INTO Khach_Hang VALUES ('" + txtMaKH.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "','" + txtUsername.Text + "')";
                        MessageBox.Show("Chúc mừng bạn đã đăng kí thành công");
                        LoadData();
                    }
                    
                }
            }
        }
        void LoadData()
        {
            dataGridView1.DataSource = dtb.DataReader("SELECT * FROM Khach_Hang");
        }
        private void frmDangKi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtUsername.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}

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
    public partial class frmNguoiDung : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string loai, nsx, username;        
        int thanhtien = 0, tongtien = 0;
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return username; }
            set { username = value; }

        }      
        void LoadDataCH()
        {
            DataTable dtch = dtb.DataReader("SELECT*FROM Hang_Hoa");
            dgvCH.DataSource = dtch;
            
        }        
        private void btnThoat_User_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnThem_User_Click(object sender, EventArgs e)
        {
            string slhc = dgvCH.CurrentRow.Cells[6].Value.ToString();
            string sl = txtSoLuong.Text;
            string mahang = txtMaHang.Text;
            string name = txtMaHang.Text + " | " + txtTenHang.Text + " | " + txtDungTich.Text +
                " | " + cmbLoai.Text + " | " + cmbNuocSX.Text + " | " + txtDonGia.Text +
                " | " + txtDoRuou.Text + " | " + sl;
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || txtDungTich.Text == "" || cmbLoai.Text == "" || cmbNuocSX.Text == "" || txtDonGia.Text == "" || txtSoLuong.Text == "" || txtDoRuou.Text == "")
            {
                MessageBox.Show("Không hợp lệ", "Thông báo");
            }
            else
            {                    
                if (int.Parse(sl) > int.Parse(slhc))
                {
                    MessageBox.Show("Không đủ số lượng");
                }
                else
                {
                    //tongtien = tongtien + thanhtien;
                    DataTable dthang = dtb.DataReader("SELECT * FROM ##HDBExcel WHERE mahang = '" + txtMaHang.Text + "'");
                    if (dthang.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Bạn có muốn thay thế không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sqlDelete = "DELETE FROM ##HDBExcel WHERE mahang = '" + txtMaHang.Text + "'";
                            dtb.DataReader(sqlDelete);
                            for (int i = 0; i < lsbCH.Items.Count; i++)
                            {
                                if (lsbCH.Items[i].ToString().Contains(txtMaHang.Text))
                                {
                                    lsbCH.Items.Remove(lsbCH.Items[i]);
                                }
                            }
                            tongtien = tongtien - thanhtien;
                            thanhtien = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text);
                            string sqlInsert = "INSERT INTO ##HDBExcel VALUES ('" + txtMaHang.Text + "',N'" + txtTenHang.Text + "','" + txtSoLuong.Text + "','" + thanhtien + "')";
                            dtb.DataReader(sqlInsert);
                            lsbCH.Items.Add(name);
                            tongtien = tongtien + thanhtien;
                        }
                    }
                    else
                    {
                        thanhtien = int.Parse(sl) * int.Parse(txtDonGia.Text);
                        lsbCH.Items.Add(name);
                        string sql = "INSERT INTO ##HDBExcel VALUES ('" + txtMaHang.Text + "',N'" + txtTenHang.Text + "','" + txtSoLuong.Text + "','" + thanhtien + "')";
                        dtb.DataReader(sql);
                        tongtien = tongtien + thanhtien;
                    }
                    Form6 f6 = new Form6();
                    f6.Tongtien = tongtien;
                }
                
            }
        }
        private void btnXoa_User_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                == DialogResult.Yes)
            {
                string str = lsbCH.SelectedItem.ToString();
                string[] arrStr = str.Split(new char[] { '|' });
                string sql = "DELETE FROM ##HDBExcel WHERE mahang = '"+arrStr[0]+"'";
                dtb.DataReader(sql);
                lsbCH.Items.Remove(lsbCH.SelectedItem);
                tongtien = tongtien - thanhtien;
            }
        }
        private void btnThongtin_User_Click(object sender, EventArgs e)
        {
            string str = "Thông tin sản phẩm: ";
            str = str + "\nMã Sản Phẩm: " + txtMaHang.Text;
            str = str + "\nTên Sản Phẩm: " + txtTenHang.Text;
            str = str + "\nLoại: " + cmbLoai.Text;
            str = str + "\nĐơn Giá: " + txtDonGia.Text;
            str = str + "\nNước Sản Xuất: " + cmbNuocSX.Text;
            str = str + "\nĐộ rượu: " + txtDoRuou.Text;
            str = str + "\nSố Lượng Hiện Có: " + txtSoLuongHienCo.Text;
            
            //str = str +  dtb.DataReader("SELECT DonGiaBan FROM Hang_Hoa WHERE MaHang = '" + txtMaHang.Text + "'").ToString();
            MessageBox.Show(str, "Thông tin");
        }
        private void btnTimKiem_User_Click(object sender, EventArgs e)
        {
            string sql = "SELECT*FROM Hang_Hoa INNER JOIN Loai ON Hang_Hoa.MaLoai = Loai.MaLoai " +
                "INNER JOIN NuocSX ON Hang_Hoa.MaNuocSX = NuocSX.MaNuocSX WHERE MaHang is not null";
            if (txtMaHang.Text == "" && txtTenHang.Text == "" && txtDungTich.Text == "" &&
                cmbLoai.Text == "" && cmbNuocSX.Text == "" && txtDonGia.Text == "" && 
                txtDoRuou.Text == "" && cmbGiaBe.Text == "" && cmbGiaLon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập trường thông tin nào, mời bạn nhập để tìm", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (txtMaHang.Text != "")
                {
                    sql += " and MaHang LIKE '%" + txtMaHang.Text.Trim() + "%'";
                }
                if (txtTenHang.Text != "")
                {
                    sql += " and TenHang LIKE N'%" + txtTenHang.Text.Trim() + "%'";
                }
                if (txtDungTich.Text != "")
                {
                    sql += " and DungTich = '%" + txtDungTich.Text + "%'";
                }
                if (cmbLoai.Text != "")
                {
                    sql += " and TenLoai LIKE N'%" + cmbLoai.Text.Trim() + "%'";
                }
                if (cmbNuocSX.Text != "")
                {
                    sql += " and TenNuocSX LIKE N'%" + cmbNuocSX.Text.Trim() + "%'";
                }
                if (txtDoRuou.Text != "")
                {
                    sql += " and DoRuou LIKE '%" + txtDoRuou.Text + "%'";
                }
                if (txtSoLuong.Text != "")
                {
                    sql += " and SoLuong LIKE '%" + txtSoLuong.Text + "%'";
                }
                if (cmbGiaBe.Text != "")
                {
                    sql += " and DonGiaBan >= '" + cmbGiaBe.Text + "'";
                }
                if (cmbGiaLon.Text != "")
                {
                    sql += " and DonGiaBan <= '" + cmbGiaLon.Text + "'";
                }
                dgvCH.DataSource = dtb.DataReader(sql);
            }
        }
        void Reset()
        {
            txtDoRuou.ResetText();
            txtMaHang.ResetText();
            txtTenHang.ResetText();
            txtDungTich.ResetText();
            txtDonGia.ResetText();
            cmbGiaBe.ResetText();
            cmbGiaLon.ResetText();
            cmbLoai.ResetText();
            cmbNuocSX.ResetText();
            txtMaHang.Focus();
        }
        private void btnReset_User_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void txtDoRuou_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        private void txtDungTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        void Loai()
        {
            loai = dgvCH.CurrentRow.Cells[3].Value.ToString();
            if (loai == "L001")
            {
                cmbLoai.SelectedIndex = 0;
            }
            else if (loai == "L002")
            {
                cmbLoai.SelectedIndex = 1;
            }
            else if (loai == "L003")
            {
                cmbLoai.SelectedIndex = 2;
            }
            else if (loai == "L004")
            {
                cmbLoai.SelectedIndex = 3;
            }
            else if (loai == "L005")
            {
                cmbLoai.SelectedIndex = 4;
            }
            else if (loai == "L006")
            {
                cmbLoai.SelectedIndex = 5;
            }
            else if (loai == "L007")
            {
                cmbLoai.SelectedIndex = 6;
            }
            else if (loai == "L008")
            {
                cmbLoai.SelectedIndex = 7;
            }
        }
        void NuocSX()
        {
            nsx = dgvCH.CurrentRow.Cells[4].Value.ToString();
            if (nsx == "NSX01")
            {
                cmbNuocSX.SelectedIndex = 0;
            }
            else if (nsx == "NSX02")
            {
                cmbNuocSX.SelectedIndex = 1;
            }
            else if (nsx == "NSX03")
            {
                cmbNuocSX.SelectedIndex = 2;
            }
            else if (nsx == "NSX04")
            {
                cmbNuocSX.SelectedIndex = 3;
            }
            else if (nsx == "NSX05")
            {
                cmbNuocSX.SelectedIndex = 4;
            }
            else if (nsx == "NSX06")
            {
                cmbNuocSX.SelectedIndex = 5;
            }
        }
        private void dgvCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbSoLuong.Text = "Số lượng hiện có";
            txtMaHang.Text = dgvCH.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dgvCH.CurrentRow.Cells[1].Value.ToString();
            txtDungTich.Text = dgvCH.CurrentRow.Cells[2].Value.ToString();
            Loai();
            NuocSX();
            txtDoRuou.Text = dgvCH.CurrentRow.Cells[5].Value.ToString();
            txtDonGia.Text = dgvCH.CurrentRow.Cells[7].Value.ToString();
            txtSoLuongHienCo.Text = dgvCH.CurrentRow.Cells[6].Value.ToString();
            txtSoLuong.ResetText();
        }
        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            frmLogin f1 = new frmLogin();
            f1.Show();
            this.Close();
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Message = username;
            f6.Tongtien = tongtien;
            f6.Show();
        }
        private void btnLichsu_Click(object sender, EventArgs e)
        {
            frmHoaDon f4 = new frmHoaDon();
            f4.Message = username;
            f4.Show();
        }
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadDataCH();
            dgvCH.Columns[0].HeaderText = "Mã Hàng";
            dgvCH.Columns[1].HeaderText = "Tên Hàng";
            dgvCH.Columns[2].HeaderText = "Dung Tích";
            dgvCH.Columns[3].HeaderText = "Loại";
            dgvCH.Columns[4].HeaderText = "Nước Sản Xuất";
            dgvCH.Columns[5].HeaderText = "Độ rượu";
            dgvCH.Columns[6].HeaderText = "Số lượng hiện có";
            dgvCH.Columns[7].HeaderText = "Đơn giá bán";
            dgvCH.Columns[8].HeaderText = "Đơn giá nhập";
            dtb.DataReader("DELETE FROM ##HDBExcel");
        }
    }
}

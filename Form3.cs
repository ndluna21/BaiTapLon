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
    public partial class frmAdmin : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string SoHDB, SoHDN, username;
        public frmAdmin()
        {
            InitializeComponent();
            this.txtTimKiem.Leave += new EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new EventHandler(this.txtTimKiem_Enter);

            this.txtNgaySinh.Leave += new EventHandler(this.txtNgaySinh_Leave);
            this.txtNgaySinh.Enter += new EventHandler(this.txtNgaySinh_Enter);

            this.txtNgayBan_HDB.Leave += new EventHandler(this.txtNgayBan_HDB_Leave);
            this.txtNgayBan_HDB.Enter += new EventHandler(this.txtNgayBan_HDB_Enter);

            this.txtNgayNhap_HDN.Leave += new EventHandler(this.txtNgayNhap_HDN_Leave);
            this.txtNgayNhap_HDN.Enter += new EventHandler(this.txtNgayNhap_HDN_Enter);
        }
        void LoadDataNV()
        {
            dgvNhanVien.DataSource = dtb.DataReader("SELECT * FROM Nhan_Vien");
        }
        void LoadDataSP()
        {
            dgvSP.DataSource = dtb.DataReader("SELECT * FROM Hang_Hoa");
        }
        void LoadDataHDB()
        {
            dgvHDB.DataSource = dtb.DataReader("SELECT * FROM Hoa_Don_Ban");
        }
        void LoadDataHDN()
        {
            dgvHDN.DataSource = dtb.DataReader("SELECT * FROM Hoa_Don_Nhap");
        }
        void LoadDataNCC()
        {
            dgvNCC.DataSource = dtb.DataReader("SELECT * FROM Nha_Cung_Cap");
        }
        void LoadDataKH()
        {
            dgvKH.DataSource = dtb.DataReader("SELECT * FROM Khach_Hang");
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemNV.Enabled = false;
            string gt = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            if (gt == "True")
            {
                cmbGioiTinh.Text = "Nữ";
            }
            else
            {
                cmbGioiTinh.Text = "Nam";
            }
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            //cmbGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtUsername_NV.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            btnXoaNV.Enabled = true;
            btnSuaNV.Enabled = true;
        }
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemSP.Enabled = false;
            btnSuaSP.Enabled = true;
            btnXoaSP.Enabled = true;
            string loai = dgvSP.CurrentRow.Cells[3].Value.ToString();
            if (cmbLoai.Text == "L001") loai = "Rượu nhẹ";
            else if (cmbLoai.Text == "L002") loai = "Rượu mạnh";
            else if (cmbLoai.Text == "L003") loai = "Vodka rượu mạnh";
            else if (cmbLoai.Text == "L004") loai = "Vodka rượu nhẹ";
            else if (cmbLoai.Text == "L005") loai = "Vang Đỏ";
            else if (cmbLoai.Text == "L006") loai = "Vang hồng";
            else if (cmbLoai.Text == "L007") loai = "Vang trắng";
            else loai = "Vang nổ";
            string nsx = dgvSP.CurrentRow.Cells[4].Value.ToString();
            if (cmbNuocSX.Text == "NSX01")  nsx = "Việt Nam";
            else if (cmbNuocSX.Text == "NSX02") nsx = "Chile";            
            else if (cmbNuocSX.Text == "NSX03") nsx = "Mỹ";            
            else if (cmbNuocSX.Text == "NSX04") nsx = "Tây Ban Nha";
            else if (cmbNuocSX.Text == "NSX05") nsx = "Ý";           
            else nsx = "Pháp";           
            txtMaHang.Text = dgvSP.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dgvSP.CurrentRow.Cells[1].Value.ToString();
            txtDungTich.Text = dgvSP.CurrentRow.Cells[2].Value.ToString();
            cmbLoai.Text = loai;
            cmbNuocSX.Text = nsx;
            txtDoRuou.Text = dgvSP.CurrentRow.Cells[5].Value.ToString();
            txtSoLuong.Text = dgvSP.CurrentRow.Cells[6].Value.ToString();
            txtDonGiaNhap.Text = dgvSP.CurrentRow.Cells[7].Value.ToString();
            txtDonGiaBan.Text = dgvSP.CurrentRow.Cells[8].Value.ToString();
        }
        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnChiTiet_HDB.Enabled = true;
            txtSoHDB.Text = dgvHDB.CurrentRow.Cells[0].Value.ToString();
            txtMaNV_HDB.Text = dgvHDB.CurrentRow.Cells[1].Value.ToString();
            txtMaKH_HDB.Text = dgvHDB.CurrentRow.Cells[2].Value.ToString();
            txtNgayBan_HDB.Text = dgvHDB.CurrentRow.Cells[3].Value.ToString();
            txtTongTien_HDB.Text = dgvHDB.CurrentRow.Cells[4].Value.ToString();
            //txtUser.Text = dgvHDB.CurrentRow.Cells[5].Value.ToString();
        }
        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnChiTiet_HDN.Enabled = true;
            txtSoHDN.Text = dgvHDN.CurrentRow.Cells[0].Value.ToString();
            txtMaNV_HDN.Text = dgvHDN.CurrentRow.Cells[1].Value.ToString();
            txtNgayNhap_HDN.Text = dgvHDN.CurrentRow.Cells[2].Value.ToString();
            txtMaNCC_HDN.Text = dgvHDN.CurrentRow.Cells[3].Value.ToString();
            txtTongTien_HDN.Text = dgvHDN.CurrentRow.Cells[4].Value.ToString();
        }
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem_NCC.Enabled = false;
            btnSua_NCC.Enabled = true;
            btnXoa_NCC.Enabled = true;
            txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi_NCC.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
            txtSDT_NCC.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
        }
        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem_KH.Enabled = false;
            btnXoa_KH.Enabled = true;
            btnSua_KH.Enabled = true;
            txtMaKH.Text = dgvKH.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi_KH.Text = dgvKH.CurrentRow.Cells[2].Value.ToString();
            txtSDT_KH.Text = dgvKH.CurrentRow.Cells[3].Value.ToString();
            txtUsername_NV.Text = dgvKH.CurrentRow.Cells[4].Value.ToString();
        }
        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Nhan_Vien WHERE MaNV is not null";
            if (cmbTimKiem.Text == "" || txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin, mời bạn nhập để tìm", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (cmbTimKiem.SelectedIndex == 0)
                {
                    sql += " and MaNV LIKE '%" + txtTimKiem.Text + "%'";
                }
                else if (cmbTimKiem.SelectedIndex == 1)
                {
                    sql += " and TenNV LIKE N'%" + txtTimKiem.Text + "%'";
                }
                else if (cmbTimKiem.SelectedIndex == 2)
                {
                    if (txtTimKiem.Text != "0" && txtTimKiem.Text != "1")
                    {
                        MessageBox.Show("Mời nhập lại \nLưu ý: 1 là Nữ, 0 là Nam");
                    }
                    else
                    {
                        sql += " and GioiTinh = " + txtTimKiem.Text + "";
                    }
                }
                else if (cmbTimKiem.SelectedIndex == 3)
                {
                    sql += " and NgaySinh LIKE '%" + txtTimKiem.Text + "%'";
                }
                else if (cmbTimKiem.SelectedIndex == 4)
                {
                    sql += " and SDT LIKE '%" + txtTimKiem.Text + "%'";
                }
                else if (cmbTimKiem.SelectedIndex == 5)
                {
                    sql += " and DiaChi LIKE '%" + txtTimKiem.Text + "%'";
                }
                else if (cmbTimKiem.SelectedIndex == 6)
                {
                    sql += " and Username LIKE '%" + txtTimKiem.Text.Trim() + "%'";
                }
                dgvNhanVien.DataSource = dtb.DataReader(sql);
            }
        }
        void ResetNV()
        {
            txtTenNV.ResetText();
            txtMaNV.ResetText();
            txtSDT.ResetText();
            txtDiaChi.ResetText();
            cmbGioiTinh.ResetText();
            txtNgaySinh.ResetText();
            txtUsername_NV.ResetText();
            txtTenNV.Focus();
            LoadDataNV();
            btnThemNV.Enabled = true;
            btnXoaNV.Enabled = false;
            btnSuaNV.Enabled = false;
        }
        private void btnResetNV_Click(object sender, EventArgs e)
        {
            cmbTimKiem.Text = "";
            txtTimKiem.Text = "";
            txtTenNV.Focus();
        }
        string GioiTinh()
        {
            string gt;
            if (cmbGioiTinh.SelectedIndex == 0)
            {
                gt = "False";
                
            }
            else
            {
                gt = "True";
            }
            return gt;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "" && txtTenNV.Text == "" && txtNgaySinh.Text == ""
                && txtSDT.Text == "" && txtDiaChi.Text == "" && txtUsername_NV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin nhân viên");
            }
            else
            {
                string gt;
                if (cmbGioiTinh.SelectedIndex == 0) gt = "False";                
                else gt = "True";                
                string user = txtUsername_NV.Text;
                DataTable dtus = dtb.DataReader("SELECT * FROM UserName WHERE Username = '"+user+"'");
                if (dtus.Rows.Count == 0)
                {
                    string sqlAddUser = "INSERT UserName VALUES ('" + txtUsername_NV.Text + "','12345')";
                    dtb.DataReader(sqlAddUser);
                }
                string sqlAdd = "INSERT Nhan_Vien VALUES ('"+txtMaNV.Text+"',N'"+txtTenNV.Text+"'," +
                    "'"+gt+"','"+txtNgaySinh.Text+"','"+txtSDT.Text+"'" +
                    ",N'"+txtDiaChi.Text+"','"+txtUsername_NV.Text+"')";
                dtb.DataReader(sqlAdd);
                LoadDataNV();
            }
        }
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "UPDATE Nhan_Vien SET TenNV = N'"+txtTenNV.Text+"', " +
                "GioiTinh = '"+GioiTinh()+"', NgaySinh = '"+txtNgaySinh.Text+"', SDT = '"+txtSDT.Text+"'," +
                "DiaChi = N'"+txtDiaChi.Text+"' WHERE MaNV = '"+txtMaNV.Text+"'";
            dtb.DataReader(sqlUpdate);
            ResetNV();
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string us = "SELECT * FROM Username WHERE Username = '"+txtUsername_NV.Text+"'";
            DataTable dtus = dtb.DataReader(us);
            if (dtus.Rows.Count == 0)
            {
                MessageBox.Show("Không có nhân viên này");
            }
            else
            {
                string sqlDelete = "DELETE FROM Nhan_Vien WHERE MaNV = '" + txtMaNV.Text + "'";
                dtb.DataReader(sqlDelete);
                string sqlDeleteUser = "DELETE FROM Username WHERE Username = '" + txtUsername_NV.Text + "'";
                dtb.DataReader(sqlDeleteUser);
                ResetNV();
            }
            
        }
        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            ResetNV();
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        public string Loai()
        {
            string loai;
            if (cmbLoai.Text == "Rượu nhẹ") loai = "L001";
            else if (cmbLoai.Text == "Rượu mạnh") loai = "L002";
            else if (cmbLoai.Text == "Vodka rượu mạnh") loai = "L003";
            else if (cmbLoai.Text == "Vodka rượu nhẹ") loai = "L004";            
            else if (cmbLoai.Text == "Vang Đỏ") loai = "L005";            
            else if (cmbLoai.Text == "Vang hồng") loai = "L006";           
            else if (cmbLoai.Text == "Vang trắng") loai = "L007";            
            else loai = "L008";            
            return loai;
        }
        public string NuocSX()
        {
            string nsx;
            if (cmbNuocSX.Text == "Việt Nam") nsx = "NSX01";            
            else if (cmbNuocSX.Text == "Chile") nsx = "NSX02";            
            else if (cmbNuocSX.Text == "Mỹ") nsx = "NSX03";           
            else if (cmbNuocSX.Text == "Tây Ban Nha") nsx = "NSX04";           
            else if (cmbNuocSX.Text == "Ý") nsx = "NSX05";           
            else  nsx = "NSX06";           
            return nsx;
        }
        void ResetSP()
        {
            txtMaHang.ResetText();
            txtTenHang.ResetText();
            txtDungTich.ResetText();
            cmbLoai.DropDownStyle = ComboBoxStyle.DropDown;
            cmbLoai.Text = "";
            cmbNuocSX.DropDownStyle = ComboBoxStyle.DropDown;
            cmbNuocSX.Text = "";
            txtDoRuou.ResetText();
            txtDonGiaBan.ResetText();
            txtDonGiaNhap.ResetText();
            txtSoLuong.ResetText();
            LoadDataSP();
            btnThemSP.Enabled = true;
            btnXoaSP.Enabled = false;
            btnSuaSP.Enabled = false;
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "" && txtTenHang.Text == "" && txtDungTich.Text == ""
                && cmbLoai.Text == "" && cmbNuocSX.Text == "" && txtDoRuou.Text == ""
                && txtDonGiaBan.Text == "" && txtDonGiaNhap.Text == "" && txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin nào của rượu");
            }
            else if (txtMaHang.Text != "" && txtTenHang.Text != "" && txtDungTich.Text != ""
                && cmbLoai.Text != "" && cmbNuocSX.Text != "" && txtDoRuou.Text != "" &&
                txtDonGiaBan.Text != "" && txtDonGiaNhap.Text != "" && txtSoLuong.Text != "")
            { 
                string sqlIn = "INSERT INTO Hang_Hoa VALUES ('"+txtMaHang.Text+"',N'"+txtTenHang.Text+"'," +
                    "'"+txtDungTich.Text+"','"+Loai()+"','"+NuocSX()+"','"+txtDoRuou.Text+"'," +
                    "'"+txtSoLuong.Text+"','"+txtDonGiaNhap.Text+"','"+txtDonGiaBan.Text+"')";
                dtb.DataReader(sqlIn);
                ResetSP();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin, có vài ô còn trống kìa");
            }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || txtDungTich.Text == "" ||
                cmbLoai.Text == "" || cmbNuocSX.Text == "" || txtDoRuou.Text == "" ||
                txtDonGiaNhap.Text == "" || txtDonGiaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin");
            }
            else
            {
                string sqlUp = "UPDATE Hang_Hoa SET TenHang = N'" + txtTenHang.Text + "', DungTich = '" + txtDungTich.Text + "'," +
                "MaLoai = '" + Loai() + "', MaNuocSX = '" + NuocSX() + "', DoRuou = '" + txtDoRuou.Text + "'," +
                " SoLuong = '" + txtSoLuong.Text + "', DonGiaNhap = '" + txtDonGiaNhap.Text + "'," +
                " DonGiaBan = '" + txtDonGiaBan.Text + "' WHERE Mahang = '" + txtMaHang.Text + "'";
                dtb.DataReader(sqlUp);
                ResetSP();
            }
        }
        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            string sqlFind = "SELECT * FROM Hang_Hoa WHERE MaHang is not null";
            if (txtMaHang.Text.Trim() != "")
            {
                sqlFind += " and MaHang LIKE '%"+txtMaHang.Text+"%'";
            }
            if (txtTenHang.Text != "")
            {
                sqlFind += " and TenHang LIKE '%" + txtTenHang.Text + "%'";
            }
            if (txtDungTich.Text != "")
            {
                sqlFind += " and DungTich LIKE '%" + txtDungTich.Text + "%'";
            }
            if (cmbLoai.Text != "")
            {
                sqlFind += " and MaLoai LIKE '%" + Loai() + "%'";
            }
            if (cmbNuocSX.Text != "")
            {
                sqlFind += " and MaNuocSX LIKE '%" + NuocSX() + "%'";
            }
            if (txtDoRuou.Text != "")
            {
                sqlFind += " and DoRuou LIKE '%" + txtDoRuou.Text + "%'";
            }
            if (txtSoLuong.Text != "")
            {
                sqlFind += " and SoLuong LIKE '%" + txtSoLuong.Text + "%'";
            }
            if (txtDonGiaNhap.Text != "")
            {
                sqlFind += " and DonGiaNhap LIKE '%" + txtDonGiaNhap.Text + "%'";
            }
            if (txtDonGiaBan.Text != "")
            {
                sqlFind += " and DonGiaBan LIKE '%" + txtDonGiaBan.Text + "%'";
            }
            dtb.DataReader(sqlFind);
        }
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sqlDelete = "DELETE FROM Hang_Hoa WHERE MaHang = '" + txtMaHang.Text + "'";
                dtb.DataReader(sqlDelete);
                ResetSP();
            }
        }
        private void btnHuySP_Click(object sender, EventArgs e)
        {
            ResetSP();
        }
        private void txtDungTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
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
        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        void ResetNCC()
        {
            txtDiaChi_NCC.ResetText();
            txtSDT_NCC.ResetText();
            txtMaNCC.ResetText();
            txtTenNCC.ResetText();
            txtMaNCC.Focus();
            LoadDataNCC();
            btnThem_NCC.Enabled = true;
            btnXoa_NCC.Enabled = false;
            btnSua_NCC.Enabled = false;
        }
        private void btnThem_NCC_Click(object sender, EventArgs e)
        {
            if (txtSDT_NCC.Text.Trim() == "" || txtMaNCC.Text.Trim() == "" || txtTenNCC.Text == "" || txtDiaChi_NCC.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
            else
            {
                string sql = "INSERT INTO Nha_Cung_Cap VALUES ('" + txtMaNCC.Text + "','" + txtTenNCC.Text + "','" + txtDiaChi_NCC.Text + "','" + txtSDT_NCC.Text + "')";
                dtb.DataReader(sql);
                ResetNCC();
            }
        }
        private void btnSua_NCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sqlUp = "UPDATE Nha_Cung_Cap SET TenNCC = N'" + txtTenNCC.Text + "', DiaChi = '" + txtDiaChi_NCC.Text + "', DienThoai = '" + txtSDT_NCC.Text + "' WHERE MaNCC = '" + txtMaNCC.Text + "'";
                dtb.DataReader(sqlUp);
                ResetNCC();
            }
        }
        private void btnXoa_NCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sqlDel = "DELETE FROM Nha_Cung_Cap WHERE MaNCC = '" + txtMaNCC.Text + "'";
                dtb.DataReader(sqlDel);
                ResetNCC();
            }
        }
        private void btnTimKiem_NCC_Click(object sender, EventArgs e)
        {
            string sqlFind = "SELECT * FROM Nha_Cung_Cap WHERE MaNCC is not null";
            if (txtMaNCC.Text != "")
            {
                sqlFind += " and MaNCC LIKE '%" + txtMaNCC.Text + "%'";
            }
            if (txtTenNCC.Text != "")
            {
                sqlFind += " and TenNCC LIKE '%" + txtTenNCC.Text + "%'";
            }
            if (txtDiaChi_NCC.Text != "")
            {
                sqlFind += " and DiaChi LIKE '%" + txtDiaChi_NCC.Text + "%'";
            }
            if (txtSDT_NCC.Text != "")
            {
                sqlFind += " and DienThoai LIKE '%" + txtSDT_NCC.Text + "%'";
            }
            dtb.DataReader(sqlFind);
        }
        private void txtSDT_NCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        private void btnHuyNCC_Click(object sender, EventArgs e)
        {
            ResetNCC();
        }
        private void txtSDT_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Kí tự vừa nhập không hợp lệ");
                e.Handled = true;
            }
        }
        void ResetKH()
        {
            txtDiaChi_KH.ResetText();
            txtTenKH.ResetText();
            txtMaKH.ResetText();
            txtUsername_KH.ResetText();
            txtSDT_KH.ResetText();
            txtMaKH.Focus();
            LoadDataNCC();
            btnThem_KH.Enabled = true;
            btnXoa_KH.Enabled = false;
            btnSua_KH.Enabled = true;
        }
        private void btnThem_KH_Click(object sender, EventArgs e)
        {
            if (txtUsername_KH.Text == "" || txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi_KH.Text == "" || txtSDT_KH.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin khách hàn, mời nhập lại");
            }
            else
            {
                string sql = "INSERT INTO Khach_Hang VALUES ('" + txtMaKH.Text + "','" + txtTenHang.Text + "','" + txtDiaChi_KH.Text + "','" + txtDiaChi_KH.Text + "','" + txtUsername_KH.Text + "')";
                dtb.DataReader(sql);
                ResetKH();
            }
        }
        private void btnSua_KH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sqlUp = "UPDATE Khach_Hang SET TenKH = N'" + txtTenKH.Text + "', DiaChi = '" + txtDiaChi_KH.Text + "', SDT = '" + txtSDT_KH.Text + "' WHERE MaKH = '" + txtMaKH.Text + "'";
                dtb.DataReader(sqlUp);
                ResetKH();
            }
        }
        private void btnXoa_KH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                string sqlDel = "DELETE FROM Khach_Hang WHERE MaKH = '" + txtMaKH.Text + "'";
                dtb.DataReader(sqlDel);
                ResetKH();
            }
        }
        private void btnTimKiem_KH_Click(object sender, EventArgs e)
        {
            string sqlFind = "SELECT * FROM Khach_Hang WHERE MaKH is not null";
            if (txtMaKH.Text != "")
            {
                sqlFind += " and MaKH LIKE '%" + txtMaKH.Text + "%'";
            }
            if (txtTenKH.Text != "")
            {
                sqlFind += " and TenKH LIKE '%" + txtTenKH.Text + "%'";
            }
            if (txtDiaChi_KH.Text != "")
            {
                sqlFind += " and DiaChi LIKE '%" + txtDiaChi_KH.Text + "%'";
            }
            if (txtSDT_KH.Text != "")
            {
                sqlFind += " and SDT LIKE '%" + txtSDT_KH.Text + "%'";
            }
            dtb.DataReader(sqlFind);
        }
        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            ResetKH();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnSuaSP.Enabled = false;
            btnXoaSP.Enabled = false;
            btnXoa_KH.Enabled = false;
            btnSua_KH.Enabled = false;
            btnXoa_NCC.Enabled = false;
            btnSua_NCC.Enabled = false;
            btnChiTiet_HDB.Enabled = false;
            btnChiTiet_HDN.Enabled = false;
            LoadDataNV();
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "SĐT";
            dgvNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[6].HeaderText = "Username";
            LoadDataSP();
            dgvSP.Columns[0].HeaderText = "Mã Hàng";
            dgvSP.Columns[1].HeaderText = "Tên Hàng";
            dgvSP.Columns[2].HeaderText = "Dung Tích";
            dgvSP.Columns[3].HeaderText = "Mã Loại";
            dgvSP.Columns[4].HeaderText = "Mã Nước Sản Xuất";
            dgvSP.Columns[5].HeaderText = "Độ Rượu";
            dgvSP.Columns[6].HeaderText = "Số Lượng";
            dgvSP.Columns[7].HeaderText = "Đơn Giá Nhập";
            dgvSP.Columns[8].HeaderText = "Đơn Giá Bán";
            LoadDataHDB();
            dgvSP.Columns[0].HeaderText = "Số HĐB";
            dgvSP.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvSP.Columns[2].HeaderText = "Mã Khách Hàng";
            dgvSP.Columns[3].HeaderText = "Ngày Bán";
            dgvSP.Columns[4].HeaderText = "Tổng Tiền";
            dgvSP.Columns[5].HeaderText = "Username";
            LoadDataHDN();
            dgvSP.Columns[0].HeaderText = "Số HĐN";
            dgvSP.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvSP.Columns[2].HeaderText = "Ngày Nhập";
            dgvSP.Columns[3].HeaderText = "Mã Nhà Cung Cấp";
            dgvSP.Columns[4].HeaderText = "Tổng Tiền";
            LoadDataNCC();
            dgvSP.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvSP.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvSP.Columns[2].HeaderText = "Địa Chỉ";
            dgvSP.Columns[3].HeaderText = "SĐT";
            LoadDataKH();
            dgvSP.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvSP.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvSP.Columns[2].HeaderText = "Địa Chỉ";
            dgvSP.Columns[3].HeaderText = "SĐT";
            dgvSP.Columns[4].HeaderText = "Username";
        }
        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "1 là Nam, 0 là Nữ";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "1 là Nam, 0 là Nữ")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }
        private void txtNgaySinh_Leave(object sender, EventArgs e)
        {
            if (txtNgaySinh.Text == "")
            {
                txtNgaySinh.Text = "Tháng/Ngày/Năm";
                txtNgaySinh.ForeColor = Color.Gray;
            }
        }
        private void txtNgaySinh_Enter(object sender, EventArgs e)
        {
            if (txtNgaySinh.Text == "Tháng/Ngày/Năm")
            {
                txtNgaySinh.Text = "";
                txtNgaySinh.ForeColor = Color.Black;
            }
        }
        private void btnTimKiem_HDB_Click_1(object sender, EventArgs e)
        {
            if (txtMaKH_HDB.Text == "" && txtSoHDB.Text == "" && txtNgayBan_HDB.Text == "" && txtMaNV_HDB.Text == "" && txtTongTien_HDB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin");
            }
            else
            {
                string sql = "SELECT * FROM Hoa_Don_Ban WHERE SoHDB is not null ";
                if (txtSoHDB.Text != "")
                {
                    sql += "and SoHDB = '" + txtSoHDB.Text + "'";
                }
                else if (txtMaNV_HDB.Text != "")
                {
                    sql += "and MaNV = '" + txtMaNV_HDB.Text + "'";
                }
                else if (txtMaKH_HDB.Text != "")
                {
                    sql += "and MaKH = '" + txtMaKH_HDB.Text + "'";
                }
                else if (txtNgayBan_HDB.Text != "")
                {
                    sql += "and NgayBan = '" + txtNgayBan_HDB.Text + "'";
                }
                else if (txtTongTien_HDB.Text != "")
                {
                    sql += "and TongTien = '" + txtTongTien_HDB.Text + "'";
                }
                dtb.DataReader(sql);
            }
        }
        private void btnChiTiet_HDB_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Message = username;
            f5.Sohdb = txtSoHDB.Text;
           
            f5.Show();
        }
        private void btnTimKiem_HDN_Click_1(object sender, EventArgs e)
        {
            if (txtMaNCC_HDN.Text == "" && txtSoHDN.Text == "" && txtNgayNhap_HDN.Text == "" && txtMaNV_HDN.Text == "" && txtTongTien_HDN.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin");
            }
            else
            {
                string sql = "SELECT * FROM Hoa_Don_Nhap WHERE SoHDN is not null ";
                if (txtSoHDN.Text != "")
                {
                    sql += "and SoHDN = '" + txtSoHDN.Text + "'";
                }
                else if (txtMaNV_HDN.Text != "")
                {
                    sql += "and MaNV = '" + txtMaNV_HDN.Text + "'";
                }
                else if (txtMaNCC_HDN.Text != "")
                {
                    sql += "and MaNCC = '" + txtMaNCC_HDN.Text + "'";
                }
                else if (txtNgayNhap_HDN.Text != "")
                {
                    sql += "and NgayNhap = '" + txtNgayNhap_HDN.Text + "'";
                }
                else if (txtTongTien_HDN.Text != "")
                {
                    sql += "and TongTien = '" + txtTongTien_HDN.Text + "'";
                }
                dtb.DataReader(sql);
            }
        }
        private void btnChiTiet_HDN_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Message = username;
            f5.Sohdn = txtSoHDN.Text;
            
            f5.Show();
        }
        private void txtNgayBan_HDB_Leave(object sender, EventArgs e)
        {
            if (txtNgayBan_HDB.Text == "")
            {
                txtNgayBan_HDB.Text = "Tháng/Ngày/Năm";
                txtNgayBan_HDB.ForeColor = Color.Gray;
            }
        }
        private void txtNgayBan_HDB_Enter(object sender, EventArgs e)
        {
            if (txtNgayBan_HDB.Text == "Tháng/Ngày/Năm")
            {
                txtNgayBan_HDB.Text = "";
                txtNgayBan_HDB.ForeColor = Color.Black;
            }
        }
        private void txtNgayNhap_HDN_Leave(object sender, EventArgs e)
        {
            if (txtNgayNhap_HDN.Text == "")
            {
                txtNgayNhap_HDN.Text = "Tháng/Ngày/Năm";
                txtNgayNhap_HDN.ForeColor = Color.Gray;
            }
        }
        private void txtNgayNhap_HDN_Enter(object sender, EventArgs e)
        {
            if (txtNgayNhap_HDN.Text == "Tháng/Ngày/Năm")
            {
                txtNgayNhap_HDN.Text = "";
                txtNgayNhap_HDN.ForeColor = Color.Black;
            }
        }
        public string Sohdn
        {
            get { return SoHDN; }
            set { SoHDN = value; }
        }
        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            frmLogin f1 = new frmLogin();
            f1.Show();
            this.Close();
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
    }
}

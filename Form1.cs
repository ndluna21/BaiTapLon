using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmLogin : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string nv = "nv";
        string admin = "admin";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                if (txtUser.Text == "")
                {
                    errorProvider1.SetError(txtUser, "Bạn chưa nhập username");
                    return;
                }
                else if (txtPass.Text == "")
                {
                    errorProvider1.SetError(txtPass, "Bạn chưa nhập mật khẩu");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                string sql = "SELECT * FROM Username WHERE UserName = '" + txtUser.Text +
                    "' AND Password = '" + txtPass.Text + "'";
                DataTable dtTable = dtb.DataReader(sql);
                if (dtTable.Rows.Count == 0)
                {
                    label2.Text = "Sai tài khoản hoặc mật khẩu";
                    txtPass.Text = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                }
                else
                {
                    
                    if(txtUser.Text.ToLower().Contains(nv) || txtUser.Text.ToLower().Contains(admin))
                    {
                        frmAdmin f3 = new frmAdmin();
                        f3.Message = txtUser.Text;
                        f3.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        frmNguoiDung f2 = new frmNguoiDung();
                        f2.Message = txtUser.Text;
                        f2.Show();
                        this.Hide();
                    }
                }
            }        
        }
        private void btnDangki_Click(object sender, EventArgs e)
        {
            /*if (txtUser.Text == "" || txtPass.Text == "")
            {
                if (txtUser.Text == "")
                {
                    errorProvider1.SetError(txtUser, "Bạn chưa nhập username");
                    return;
                }
                else if (txtPass.Text == "")
                {
                    errorProvider1.SetError(txtPass, "Bạn chưa nhập mật khẩu");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            else if (txtUser.Text != "" && txtPass.Text != "")
            {
                string sqlKiemTra = "SELECT * FROM UserName WHERE UserName = '" + txtUser.Text +"'";
                DataTable dtTable = dtb.DataReader(sqlKiemTra);
                if (dtTable.Rows.Count > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại, mời chọn tên khác");
                }
            }
            else
            {
                string sqlInsert = "INSERT INTO UserName VALUES ('" + txtUser.Text + "','" + txtPass.Text + "')";
                dtb.DataReader(sqlInsert);
                MessageBox.Show("Đăng kí thành công", "Thông báo");
            }*/
            frmDangKi fdk = new frmDangKi();
            fdk.Show();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Bài tập lớn môn Lập trình trực quan";
            shortcut.Hotkey = "Ctrl+M";
            shortcut.IconLocation = "C:\\Users\\duclu\\source\\repos\\BaiTapLon\\Resources";
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            CreateShortcut("Bài tập lớn", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Assembly.GetExecutingAssembly().Location);
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
        }
    }
}

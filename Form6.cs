using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaiTapLon
{
    public partial class Form6 : Form
    {
        Classes.DataBase dtb = new Classes.DataBase();
        string mahang, tenhang, username;
        int soluong, dongia, thanhtien, tongtien;
        public Form6()
        {
            InitializeComponent();
        }
        public int Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        public string Mahang
        {
            get { return mahang; }
            set { mahang = value; }
        }
        public string Message
        {
            get { return username; }
            set { username = value; }

        }
        public string Tenhang
        {
            get { return tenhang; }
            set { tenhang = value; }
        }
        void LoadData()
        {
            
            dataGridView1.DataSource = dtb.DataReader("SELECT*FROM ##HDBExcel");
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            string sql = "DELETE FROM ##HDBExcel WHERE (soluong = 0 and thanhtien = 0)";
            dtb.DataReader(sql);
            LoadData();
        }

/*        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sqlDelete = "DELETE FROM ##HDBExcel WHERE mahang = '" + mh + "'";
            dtb.DataReader(sqlDelete);
            LoadData();
        }*/

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Số tiền bạn cần phải thanh toán là: " + tongtien);
            
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        private void btnIn_User_Click(object sender, EventArgs e)
        {
            DataTable dthang = dtb.DataReader("SELECT * FROM ##HDBExcel");
            if (dthang.Rows.Count > 0)
            {
                //Khai báo + khởi tạo đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                Excel.Range tenCH = (Excel.Range)exSheet.Cells[1, 1];
                tenCH.Value = "THẾ GIỚI RƯỢU";
                tenCH.Font.Bold = true;
                tenCH.Font.Size = 12;
                tenCH.Font.Color = Color.Black;

                Excel.Range dcCH = (Excel.Range)exSheet.Cells[2, 1];
                dcCH.Value = "Địa chỉ: 3 Cầu Giấy, Láng Thượng, Đống Đa, Hà Nội";
                dcCH.Font.Bold = true;
                dcCH.Font.Size = 12;
                dcCH.Font.Color = Color.Black;

                Excel.Range dtCH = (Excel.Range)exSheet.Cells[3, 1];
                dtCH.Value = "Điện thoại: 024 3766 3311";
                dtCH.Font.Bold = true;
                dtCH.Font.Size = 12;
                dtCH.Font.Color = Color.Black;

                Excel.Range header = (Excel.Range)exSheet.Cells[5, 3];
                exSheet.get_Range("C5: G5").Merge(true);
                header.Value = "DANH SÁCH CÁC SẢN PHẨM TRONG HOÁ ĐƠN";
                tenCH.Font.Bold = true;
                tenCH.Font.Size = 15;
                tenCH.Font.Color = Color.Blue;

                //Định dạng tiêu đề bảng
                exSheet.get_Range("A7:E7").Font.Bold = true;
                exSheet.get_Range("A7:E7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã Hàng";
                exSheet.get_Range("C7").Value = "Tên Hàng";
                exSheet.get_Range("D7").Value = "Số Lượng";
                exSheet.get_Range("E7").Value = "Thành Tiền";
                //exSheet.get_Range("G7").Value = "STT";

                //In dữ liệu
                for (int i = 0; i < dthang.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":E" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dthang.Rows[i]["MaHang"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dthang.Rows[i]["TenHang"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dthang.Rows[i]["SoLuong"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dthang.Rows[i]["ThanhTien"].ToString();
                }
                exSheet.Name = "HoaDon";
                exBook.Activate();
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(*.xls)|*.xls|Word Document(*.doc)|*.doc|All Flie(*.*)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = "*.xls";
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(dlgSave.FileName.ToString()); //Lưu file Excel
                }
                exApp.Quit();
            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in");
            }
        }
    }
}

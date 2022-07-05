using QLRapChieuPhim.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRapChieuPhim
{
    public partial class frmKhachhang : Form
    {
        string sql;
        Boolean addnewflag = false;

        public frmKhachhang()
        {
            InitializeComponent();
        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            string sql = "Select MaKH, TenKH, Email, Sdt from KHACHHANG";

            grdData.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            grdData.Refresh();
            NapCT();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            grdData.CurrentCell = grdData[0, 0];
            NapCT();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int i = grdData.CurrentRow.Index;
            if (i > 0)
            {
                grdData.CurrentCell = grdData[0, i - 1];
                NapCT();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int i = grdData.CurrentRow.Index;
            if (i < grdData.RowCount - 1)
            {
                grdData.CurrentCell = grdData[0, i + 1];
                NapCT();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            sql = "Select MaKH, TenKH, Email, Sdt from KHACHHANG " +
                "where MaKH like '%" + txtFind.Text + "%' or TenKH like N'%" + txtFind.Text + "%' or Email like N'%" + txtFind.Text + "%' or Sdt like '%" + txtFind.Text + "%'";
            grdData.DataSource = DataProvider.Instance.ExecuteQuery(sql); 
            grdData.Refresh();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtFind.Text = "";
            NapLai();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
            txtMaKH.Focus();
            btnUpdate.Enabled = true;
            addnewflag = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            MessageBox.Show("Hãy thực hiện sửa đổi thông tin Tài Liệu và Cập Nhật!");
            txtMaKH.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mahang;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng hiện thời? (Y/N)", "Xác nhận yêu cầu",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int i = Convert.ToInt16(grdData.CurrentRow.Index.ToString());
                mahang = grdData.Rows[i].Cells[1].Value.ToString();
                sql = "Delete from KHACHHANG where MaKH='" + txtMaKH.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(sql);
                grdData.Rows.RemoveAt(grdData.CurrentRow.Index);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addnewflag == true)
            {
                //cập nhật thêm mới
                if (CheckControl())
                {
                    sql = "insert into KHACHHANG(MaKH,TenKH,Email,Sdt)  Values ('" + txtMaKH.Text + "','" + txtTenKH.Text + "',N'" + txtEmail.Text + "','" + txtSdt.Text + "')";
                    DataProvider.Instance.ExecuteNonQuery(sql);
                    MessageBox.Show("Thêm mới thành công");
                    btnUpdate.Enabled = false;
                    addnewflag = false;
                    NapLai();
                }
            }
            else
            {
                //cập nhật sửa chữa
                sql = "update KHACHHANG set MaKH='" + txtMaKH.Text + "',TenKH=N'" + txtTenKH.Text
                        + "',Email='" + txtEmail.Text + "',Sdt='" + txtSdt.Text + "' where MaKH='" + txtMaKH.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(sql);
                btnUpdate.Enabled = false;
                NapLai();
                MessageBox.Show("Đã lưu thay đổi!");
            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void NapCT()
        {
            int i = grdData.CurrentRow.Index;
            txtMaKH.Text = grdData.Rows[i].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = grdData.Rows[i].Cells["TenKH"].Value.ToString();
            txtEmail.Text = grdData.Rows[i].Cells["Email"].Value.ToString();
            txtSdt.Text = grdData.Rows[i].Cells["Sdt"].Value.ToString();
        }

        public void NapLai()
        {
            sql = "Select MaKH,TenKH,Email,Sdt from KHACHHANG order by MaKH";
            grdData.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            grdData.Refresh();

        }

        public bool CheckControl()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return false;
            }
            return true;
        }

    }
}

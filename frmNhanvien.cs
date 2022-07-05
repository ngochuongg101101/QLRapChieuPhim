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
    public partial class frmNhanvien : Form
    {
        string sql;
        Boolean addnewflag = false;

        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            string sql = "Select MaNV, TenNV, Ngaysinh, GioiTinh, Sdt from NHANVIEN";

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
            sql = "Select MaNV, TenNV, Ngaysinh, GioiTinh, Sdt from NHANVIEN " +
                "where MaNV like '%" + txtFind.Text + "%' or TenNV like N'%" + txtFind.Text + "%' or Ngaysinh like '%" + txtFind.Text + "%' or Gioitinh like N'%" + txtFind.Text + "%' or Sdt like '%" + txtFind.Text + "%'";
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
            txtMaNV.Focus();
            btnUpdate.Enabled = true;
            addnewflag = true;

            sql = " Select Distinct GioiTinh From NHANVIEN";
            DataTable comdt = DataProvider.Instance.ExecuteQuery(sql);
            cbGioitinh.DataSource = comdt;
            cbGioitinh.DisplayMember = "Gioitinh";
            cbGioitinh.ValueMember = "Gioitinh";
            cbGioitinh.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            MessageBox.Show("Hãy thực hiện sửa đổi thông tin Tài Liệu và Cập Nhật!");
            txtMaNV.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mahang;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dòng hiện thời? (Y/N)", "Xác nhận yêu cầu",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int i = Convert.ToInt16(grdData.CurrentRow.Index.ToString());
                mahang = grdData.Rows[i].Cells[1].Value.ToString();
                sql = "Delete from NHANVIEN where MaNV='" + txtMaNV.Text + "'";
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
                    sql = "insert into NHANVIEN (MaNV, TenNV, Ngaysinh, Gioitinh, Sdt) Values (@MaNV , @TenNV , @Ngaysinh , @Gioitinh , @Sdt)";
                    DataProvider.Instance.ExecuteQuery(sql, new object[] {Convert.ToString(txtMaNV.Text), Convert.ToString(txtTenNV.Text), Convert.ToDateTime(dtpNgaysinh.Text), Convert.ToString(cbGioitinh.Text), Convert.ToString(txtSdt.Text)});
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
                sql = "update NHANVIEN set MaNV='" + txtMaNV.Text + "',TenNV=N'" + txtTenNV.Text + "',Ngaysinh='" + dtpNgaysinh.Text
                        + "',Gioitinh='" + cbGioitinh.Text + "',Sdt='" + txtSdt.Text + "' where MaKH='" + txtMaNV.Text + "'";
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
            txtMaNV.Text = grdData.Rows[i].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = grdData.Rows[i].Cells["TenNV"].Value.ToString();
            dtpNgaysinh.Text = grdData.Rows[i].Cells["Ngaysinh"].Value.ToString();
            cbGioitinh.Text = grdData.Rows[i].Cells["Gioitinh"].Value.ToString();
            txtSdt.Text = grdData.Rows[i].Cells["Sdt"].Value.ToString();
        }

        public void NapLai()
        {
            sql = "Select MaNV,TenNV,Ngaysinh,Gioitinh,Sdt from NHANVIEN order by MaNV";
            grdData.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            grdData.Refresh();

        }

        public bool CheckControl()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
                return false;
            }
            return true;
        }
    }
}

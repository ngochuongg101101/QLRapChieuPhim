using QLRapChieuPhim.DAO;
using QLRapChieuPhim.DTO;
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
    public partial class frmBanVe : Form
    {
        string phongchon;
        public frmBanVe()
        {
            InitializeComponent();
        }

        private void frmBanVe_Load(object sender, EventArgs e)
        {
            dtpNgayban.Value = DateTime.Today;
            string query1 = "Select * from PHIM where Trangthai=N'Đang chiếu'";
            grdData.DataSource = DataProvider.Instance.ExecuteQuery(query1);
            grdData.Refresh();
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = grdData.CurrentRow.Index;
            string query2 = "Select distinct SUATCHIEU.* from SUATCHIEU,PHIM where SUATCHIEU.Maphim='" + grdData.Rows[i].Cells[0].Value.ToString() + "'"; 
            //and Ngaychieu ='"+ Convert.ToDateTime(dtpNgayban.Text) +"'";
            grdData1.DataSource = DataProvider.Instance.ExecuteQuery(query2);
            grdData1.Refresh();
        }

        private void btnChonghe_Click(object sender, EventArgs e)
        {
            
            int i = grdData1.CurrentRow.Index;

            phongchon = grdData1.Rows[i].Cells["Maphong"].Value.ToString();
            
            List<Ghe> gheList = GheDAO.Instance.LoadGheList(phongchon);

            foreach (Ghe item in gheList)
            {
                Button btn = new Button() { Width = GheDAO.GheWidth, Height = GheDAO.GheHeight };

                btn.Text = item.Tenghe;
                btn.Click += btn_Click;
                btn.Tag = item;
                string maloai = item.Maloai;
                if(maloai=="LG01") { btn.BackColor = Color.Red; }
                
                switch (item.Trangthai)
                {
                    case "Trống":
                        btn.BackColor = Color.Purple;
                        /* đoạn này không work
                        switch (item.Maloai)
                        {
                            case "LG01":
                                btn.BackColor = Color.White;
                                break;
                            case "LG02":
                                btn.BackColor = Color.Red;
                                break;
                            case "LG03":
                                btn.BackColor = Color.Purple;
                                break;
                        }
                        */
                        break;
                    
                    default:
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;
                        break;
                }
                
                flpGhe.Controls.Add(btn);
            }
            pnChonghe.Visible = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string maloai = ((sender as Button).Tag as Ghe).Maloai;
            string mausac = (sender as Button).BackColor.ToString();
            switch (mausac)
            {
                case "Yellow":
                    /* cũng thế :v
                    switch (maloai)
                    {
                        case "LG01":
                            (sender as Button).BackColor = Color.White;
                            break;
                        case "LG02":
                            (sender as Button).BackColor = Color.Red;
                            break;
                        default:
                            (sender as Button).BackColor = Color.Purple;
                            break;
                    }
                    break;
                    */
                default:
                    (sender as Button).BackColor = Color.Yellow;
                    break;
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            string query3 = "Select Maghe, Tenghe, Tenloai, Dongia from GHE,LOAIGHE where GHE.Maloai=LOAIGHE.Maloai and Maghe in ";
            grdData2.DataSource = DataProvider.Instance.ExecuteQuery(query3);
            grdData2.Refresh();
        }
    }
}

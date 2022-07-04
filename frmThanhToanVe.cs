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
    public partial class frmThanhToanVe : Form
    {
        public frmThanhToanVe()
        {
            InitializeComponent();
        }

        private void frmThanhToanVe_Load(object sender, EventArgs e)
        {
            string query = "Select Tenghe, Tenloai, Dongia from LOAIGHE, GHE where LOAIGHE.Maloai = GHE.Maloai and Maphong ='PHONG01'";
                //and Tenghe=" + ((sender as Button).Tag as Ghe).Tenghe;

            grdData.DataSource = DataProvider.Instance.ExecuteQuery(query);
            grdData.Refresh();

        }

        public void NapCT()
        {

        }
    }
}

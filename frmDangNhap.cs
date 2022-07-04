using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRapChieuPhim
{
    public partial class frmDangNhap : Form
    {
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text.Trim();
                if(username.Length > 0 && password.Length>0)
                {
                    if (SubmitLogin(username,password)) { 
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi máy chủ 500");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {

        }
        private bool SubmitLogin(string username,string password)
        {

            return DAO.AccountEmployeeDAO.Instance.Login(username,password);
        }
    }
}

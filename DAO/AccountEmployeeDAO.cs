using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DAO
{
    public class AccountEmployeeDAO
    {
        private static AccountEmployeeDAO instance;

        public static AccountEmployeeDAO Instance
        {
            get { if (instance == null) instance = new AccountEmployeeDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountEmployeeDAO() { }

        public bool Login(string username,string password)
        {
            string query = "SELECT * FROM NHANVIEN WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }
    }
}

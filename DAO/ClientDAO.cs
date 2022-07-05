using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DAO
{
    public class ClientDAO
    {
        private static ClientDAO instance;

        public static ClientDAO Instance
        {
            get { if (instance == null) instance = new ClientDAO(); return ClientDAO.instance; }
            private set => instance = value;
        }

        public ClientDAO () { }

        public List<DTO.Client> GetClientById(int id) 
        {
            List<DTO.Client> listclient = new List<DTO.Client>();
            string query = "SELECT * FROM KHACHHANG WHERE ID = "+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                DTO.Client info = new DTO.Client(item);
                listclient.Add(info);
            }
            return listclient;
        }
        public List<DTO.Client> GetClientByName(String name)
        {
            List<DTO.Client> listclient = new List<DTO.Client>();
            string query = "SELECT * FROM KHACHHANG WHERE TenKH LIKE %" + name +"%";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.Client info = new DTO.Client(item);
                listclient.Add(info);
            }
            return listclient;
        }
        public List<DTO.Client> GetClientByEmail(String email)
        {
            List<DTO.Client> listclient = new List<DTO.Client>();
            string query = "SELECT * FROM KHACHHANG WHERE Email = " + email;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.Client info = new DTO.Client(item);
                listclient.Add(info);
            }
            return listclient;
        }
        public List<DTO.Client> GetClientByPhoneNumber(String phonenumber)
        {
            List<DTO.Client> listclient = new List<DTO.Client>();
            string query = "SELECT * FROM KHACHHANG WHERE Sdt = " + phonenumber;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.Client info = new DTO.Client(item);
                listclient.Add(info);
            }
            return listclient;
        }
        public bool InsertClient(string maKH,string tenKH,string email,string sdt)
        {
            string query = String.Format("INSERT INTO [dbo].[KHACHHANG]([MaKH],[TenKH],[Email],[Sdt])VALUES(N'{0},N'{1},N'{2},'{3}','{4}')");
            int _result = DataProvider.Instance.ExecuteNonQuery(query);
            return _result > 0;
        }
        public bool UpdateClient (string maKH, string TenKH,string Email,string Sdt)
        {
            string query = String.Format("UPDATE CLIENT SET MaKH ='{1}',TenKH = N'{2}',Email = '{3}',Sdt='{4}'   ",maKH,TenKH,Email,Sdt);
            int _result = DataProvider.Instance.ExecuteNonQuery(query);
            return _result > 0;
        }
        public bool DeleteClient(string maKH)
        {
            string query = String.Format("DELETE CLIENT WHERE MaKH={0}", maKH);
            int _result = DataProvider.Instance.ExecuteNonQuery(query);
            return _result > 0;
        }
    }
}

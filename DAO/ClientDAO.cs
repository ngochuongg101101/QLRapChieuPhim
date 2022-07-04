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
        public List<DTO.Client> GetClientByName(int id)
        {
            List<DTO.Client> listclient = new List<DTO.Client>();
            string query = "SELECT * FROM KHACHHANG WHERE ID = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DTO.Client info = new DTO.Client(item);
                listclient.Add(info);
            }
            return listclient;
        }
    }
}

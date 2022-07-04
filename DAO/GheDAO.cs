using QLRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DAO
{
    class GheDAO
    {
        private static GheDAO instance;

        internal static GheDAO Instance { get { if (instance == null) instance = new GheDAO(); return GheDAO.instance; } set => instance = value; }

        public static int GheWidth = 40;
        public static int GheHeight = 30;

        private GheDAO() { }

        public List<Ghe> LoadGheList(string str)
        {
            List<Ghe> gheList = new List<Ghe>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select Maghe,Tenghe,Trangthai,Maloai from GHE where Maphong='"+ str +"'order by Soghe ");
            foreach (DataRow item in dt.Rows)
            {
                Ghe ghe = new Ghe(item);
                gheList.Add(ghe);
            }
            return gheList;
        }
    }
}

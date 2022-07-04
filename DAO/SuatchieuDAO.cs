using QLRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DAO
{
    class SuatchieuDAO
    {
        private static SuatchieuDAO instance;

        internal static SuatchieuDAO Instance { get { if (instance == null) instance = new SuatchieuDAO(); return SuatchieuDAO.instance; } set => instance = value; }

        private SuatchieuDAO() { }

        public List<Suatchieu> LoadGheList()
        {
            List<Suatchieu> suatchieuList = new List<Suatchieu>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from SUATCHIEU");
            foreach (DataRow item in dt.Rows)
            {
                Suatchieu suatchieu = new Suatchieu(item);
                suatchieuList.Add(suatchieu);
            }
            return suatchieuList;
        }
    }
}

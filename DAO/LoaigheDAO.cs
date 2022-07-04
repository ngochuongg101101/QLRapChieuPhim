using QLRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DAO
{
    class LoaigheDAO //lấy loại vé từ Maghe
    {
        private static LoaigheDAO instance;

        internal static LoaigheDAO Instance { get { if (instance == null) instance = new LoaigheDAO(); return LoaigheDAO.instance; } set => instance = value; }

        private LoaigheDAO() { }

        private int GetMaLoai(int maghe)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select LOAIGHE.* from LOAIGHE, GHE where LOAIGHE.Maloai = GHE.Maloai and Maghe=" + maghe);
            if (dt.Rows.Count>0)
            {
                Loaighe loaighe = new Loaighe(dt.Rows[0]);
                //return loaighe.Maloai;
            }
            return -1;
        }
    }
}

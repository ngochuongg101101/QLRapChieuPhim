using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DTO
{
    class Ghe
    {
        public Ghe(string maghe, string tenghe, string trangthai, string maloai)
        {
            this.Maghe = maghe;
            this.Tenghe = tenghe;
            this.Trangthai = trangthai;
            this.Maloai = maloai;

        }

        public Ghe(DataRow row)
        {
            this.Maghe = row["Maghe"].ToString();
            this.Tenghe = row["Tenghe"].ToString();
            this.Trangthai = row["Trangthai"].ToString();
            this.Maloai = row["Maloai"].ToString();
        }

        private string maghe;

        public string Maghe { get => maghe; set => maghe = value; }

        private string tenghe;

        public string Tenghe { get => tenghe; set => tenghe = value; }

        private string trangthai;

        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Maloai { get => maloai; set => maloai = value; }

        private string maloai;

    }
}

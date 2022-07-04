using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DTO
{
    class Suatchieu
    {
        public Suatchieu(string masc, string dinhdang, string ngonngu, string maphim, string maphong)
        {
            this.Masc = masc;
            this.Dinhdang = dinhdang;
            this.Ngonngu = ngonngu;
            this.Maphim = maphim;
            this.Maphong = maphong;
        }

        public Suatchieu(DataRow row)
        {
            this.Masc = row["Masc"].ToString();
            this.Dinhdang = row["Dinhdang"].ToString();
            this.Ngonngu = row["Ngonngu"].ToString();
            this.Maphim = row["Maphim"].ToString();
            this.Maphong = row["Maphong"].ToString();
        }

        private string masc;

        public string Masc { get => masc; set => masc = value; }

        private string dinhdang;

        public string Dinhdang { get => dinhdang; set => dinhdang = value; }

        private string ngonngu ;

        public string Ngonngu { get => ngonngu; set => ngonngu = value; }

        private string maphim;

        public string Maphim { get => maphim; set => maphim = value; }

        private string maphong;

        public string Maphong { get => maphong; set => maphong = value; }

    }
}

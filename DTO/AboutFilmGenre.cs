using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class AboutFilmGenre
    {
        private int maphim;
        private int matl;

        public AboutFilmGenre(int maphim, int matl)
        {
            this.Maphim = maphim;
            this.Matl = matl;
        }
        public AboutFilmGenre(DataRow Row)
        {
            this.Maphim = (int)Row["Maphim"];
            this.Matl = (int)Row["Matl"];
        }

        public int Maphim { get => maphim; set => maphim = value; }
        public int Matl { get => matl; set => matl = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class FilmGenre
    {
        private int matl;
        private string tentl;

        public FilmGenre(int matl, string tentl)
        {
            this.Matl = matl;
            this.Tentl = tentl;
        }
        public FilmGenre(DataRow Row)
        {
            this.Matl = (int)Row["Matl"];
            this.Tentl = Row["tentl"].ToString();
        }

        public int Matl { get => matl; set => matl = value; }
        public string Tentl { get => tentl; set => tentl = value; }
    }
}

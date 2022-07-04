using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Food
    {
        private int maDA;
        private string tenDA;
        private string chitiet;
        private int dongia;

        public Food(int maDA, string tenDA, string chitiet, int dongia)
        {
            this.maDA = maDA;
            this.tenDA = tenDA;
            this.chitiet = chitiet;
            this.dongia = dongia;
        }
        public Food(DataRow Row)
        {
            this.MaDA = (int)Row["MaDA"];
            this.TenDA = Row["TenDA"].ToString();
            this.Chitiet = Row["Chitiet"].ToString();
            this.Dongia = (int)Row["dongia"];
        }

        public int MaDA { get => maDA; set => maDA = value; }
        public string TenDA { get => tenDA; set => tenDA = value; }
        public string Chitiet { get => chitiet; set => chitiet = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}

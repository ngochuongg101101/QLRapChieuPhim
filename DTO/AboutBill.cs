using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class AboutBill
    {
        private int maHD;
        private int maDA;
        private int soluong;
        private int dongia;

        public AboutBill(int maHD, int maDA, int soluong, int dongia)
        {
            this.MaHD = maHD;
            this.MaDA = maDA;
            this.Soluong = soluong;
            this.Dongia = dongia;
        }
        public AboutBill(DataRow Row)
        {
            this.MaHD = (int)Row["MaHD"];
            this.MaDA = (int)Row["MaDA"]; ;
            this.Soluong = (int)Row["Soluong"]; ;
            this.Dongia = (int)Row["Dongia"]; ;
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaDA { get => maDA; set => maDA = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}

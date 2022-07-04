using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRapChieuPhim.DTO
{
    public class Loaighe
    {
        public Loaighe(string maloai, string tenloai, int dongia)
        {
            this.Maloai = maloai;
            this.Tenloai = tenloai;
            this.Dongia = dongia;
        }

        public Loaighe(DataRow row)
        {
            //this.Maloai = row["Maloai"].ToString;
            //this.Tenloai = row["Tenloai"].ToString;
            this.Dongia = (int)row["Dongia"];
        }

        private string maloai;
        public string Maloai { get => maloai; set => maloai = value; }

        private string tenloai;
        public string Tenloai { get => tenloai; set => tenloai = value; }

        private int dongia;
        public int Dongia { get => dongia; set => dongia = value; }

        
    }
}

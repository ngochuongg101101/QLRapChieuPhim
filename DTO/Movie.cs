using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Movie
    {
        private int maphim;
        private string tenphim;
        private string thoiluong;
        private string ngonngu;
        private DateTime ngaykc;
        private string daodien;
        private string dienvien;
        private string trangthai;

        public Movie(int maphim, string tenphim, string thoiluong, string ngonngu, DateTime ngaykc, string daodien, string dienvien, string trangthai)
        {
            this.Maphim = maphim;
            this.Tenphim = tenphim;
            this.Thoiluong = thoiluong;
            this.Ngonngu = ngonngu;
            this.Ngaykc = ngaykc;
            this.Daodien = daodien;
            this.Dienvien = dienvien;
            this.Trangthai = trangthai;
        }
        public Movie(DataRow Row)
        {
            this.Maphim = (int)Row["Maphim"];
            this.Tenphim = Row["Tenphim"].ToString();
            this.Thoiluong = Row["Thoiluong"].ToString();
            this.Ngonngu = Row["Ngonngu"].ToString();
            this.Ngaykc = (DateTime)Row["Ngaykc"];
            this.Daodien = Row["Daodien"].ToString();
            this.Dienvien = Row["Dienvien"].ToString();
            this.Trangthai = Row["Trangthai"].ToString();
        }

        public int Maphim { get => maphim; set => maphim = value; }
        public string Tenphim { get => tenphim; set => tenphim = value; }
        public string Thoiluong { get => thoiluong; set => thoiluong = value; }
        public string Ngonngu { get => ngonngu; set => ngonngu = value; }
        public DateTime Ngaykc { get => ngaykc; set => ngaykc = value; }
        public string Daodien { get => daodien; set => daodien = value; }
        public string Dienvien { get => dienvien; set => dienvien = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}

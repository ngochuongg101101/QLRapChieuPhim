using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Bill
    {
        private int maHD;
        private DateTime ngayban;
        private int maNV;
        private int maKH;

        public Bill(DataRow Row)
        {
            this.MaHD = (int)Row["MaHD"];
            this.Ngayban = (DateTime)Row["Ngayban"];
            this.MaNV = (int)Row["maNV"];
            this.MaKH = (int)Row["maKH"];
        }
        public Bill(int maHD, DateTime ngayban, int maNV, int maKH)
        {
            this.MaHD = maHD;
            this.Ngayban = ngayban;
            this.MaNV = maNV;
            this.MaKH = maKH;
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public DateTime Ngayban { get => ngayban; set => ngayban = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int MaKH { get => maKH; set => maKH = value; }
    }
}

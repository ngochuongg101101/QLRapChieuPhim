using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Ticket
    {
        private int mave;
        private DateTime ngayban;
        private int tongthu;
        private string masuat;
        private string maghe;
        private string manv;
        private string makh;
        public int Mave { get => mave; set => mave = value; }
        public DateTime Ngayban { get => ngayban; set => ngayban = value; }
        public int Tongthu { get => tongthu; set => tongthu = value; }
        public string Masuat { get => masuat; set => masuat = value; }
        public string Maghe { get => maghe; set => maghe = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Makh { get => makh; set => makh = value; }
        public Ticket(int Mave, DateTime Ngayban, int Tongthu, string Masuat, string Maghe,string Manv, string Makh)
        {
            this.Mave = mave;
            this.Ngayban = ngayban;
            this.Tongthu = tongthu;
            this.Masuat = masuat;
            this.Maghe = maghe;
            this.Manv = manv;
            this.Makh = makh;
        }
        public Ticket(DataRow Row)
        {
            this.mave = (int)Row["Mave"];
            this.ngayban = (DateTime)Row["Ngayban"];
            this.tongthu = (int)Row["Tongthu"];
            this.masuat = Row["Masuat"].ToString();
            this.maghe = Row["Maghe"].ToString();
            this.manv = Row["Manv"].ToString();
            this.makh = Row["Makh"].ToString();
        }

    }
}


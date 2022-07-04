using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class RoomCinema
    {
        private int maphong;
        private string tenphong;
        private int soghe;

        public RoomCinema(int maphong, string tenphong, int soghe)
        {
            this.Maphong = maphong;
            this.Tenphong = tenphong;
            this.Soghe = soghe;
        }
        public RoomCinema(DataRow Row)
        {
            this.Maphong = (int)Row["Maphong"];
            this.Tenphong = Row["Tenphong"].ToString();
            this.Soghe = (int)Row["soghe"];
        }

        public int Maphong { get => maphong; set => maphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public int Soghe { get => soghe; set => soghe = value; }
    }
}

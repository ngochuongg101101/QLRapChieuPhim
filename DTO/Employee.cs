using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Employee
    {
        public Employee(int MaNV, string TenNV,DateTime Ngaysinh, string Gioitinh, string Sdt)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.Gioitinh = gioitinh;
            this.Ngaysinh = ngaysinh;
            this.Sdt = sdt;
        }
        public Employee(DataRow Row)
        {
            this.MaNV = (int)Row["MaNV"];
            this.TenNV = Row["TenNV"].ToString();
            this.Gioitinh = Row["Gioitinh"].ToString();
            this.Ngaysinh = (DateTime)Row["Ngaysinh"];
            this.Sdt = Row["Sdt"].ToString();

        }
        private int maNV;
        private string tenNV;
        private DateTime ngaysinh;
        private string gioitinh;
        private string sdt;
        public int MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
}

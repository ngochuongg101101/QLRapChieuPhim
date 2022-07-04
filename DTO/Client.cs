﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLRapChieuPhim.DTO
{
    public class Client
    {
        public Client (int MaKH,string TenKH,string Email, string Sdt)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.Email = email;
            this.Sdt = sdt;
        }
        public Client (DataRow Row)
        {
            this.MaKH = (int)Row["MaKH"];
            this.TenKH = Row["TenKH"].ToString();
            this.Email = Row["Email"].ToString();
            this.Sdt = Row["Sdt"].ToString();

        }
        private int maKH;
        private string tenKH;
        private string email;
        private string sdt;
        public int MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }

}
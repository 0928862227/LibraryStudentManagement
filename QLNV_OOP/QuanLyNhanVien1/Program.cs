using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien1
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyNhanVien nhanVien = new QuanLyNhanVien();
            nhanVien.Input();
            nhanVien.PrintInfor();
            Console.WriteLine($"Lương: {nhanVien.TinhLuong()}");
            


        }
    }
}


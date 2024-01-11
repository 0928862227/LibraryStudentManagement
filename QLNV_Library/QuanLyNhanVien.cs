
namespace QuanLyNhanVienLib
{
    public class QuanLyNhanVien
    {
        

        // Các thuộc tính private=
        public int maNV { get => maNV; set => maNV = value; }
        public string tenNV { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngayvaolam { get; set; }
        public string bangcap { get; set; }
        public string hinhthucNV { get; set; }
        public string dieukien { get; set; }
        public int ngayNghi { get; set; }


        //// Constructor mặc định
        //public QuanLyNhanVien()
        //{

        //}


        //// Constructor có truyền thông số
        //public QuanLyNhanVien(int maNV, string tenNV, DateTime ngaySinh, bool gioiTinh, string diaChi, DateTime ngayVaoLam, string bangCap, string hinhThucNV)
        //{
        //    // Kiểm tra năm sinh 
        //    if (ngaySinh.Year > DateTime.Now.Year - 18)
        //    {
        //        throw new ArgumentException("Năm sinh không hợp lệ");
        //    }


        //    MaNV = maNV;
        //    TenNV = tenNV;
        //    NgaySinh = ngaySinh;
        //    GioiTinh = gioiTinh;
        //    DiaChi = diaChi;
        //    NgayVaoLam = ngayVaoLam;
        //    BangCap = bangCap;
        //    HinhThucNV = hinhThucNV;
        //}


        /*Hàm tính thời gian làm việc 
          nhận 2 giá trị : thời gian bắt đầu vào làm , thời gian ra về 
          trả về giá trị : thời gian nhân viên làm việc trong cty
        */
        public double TinhWorkingTime(DateTime start, DateTime end)
        {
            /*Thời gian làm việc = end - start.
            Nếu ngày làm vc < 8h 
               1. Nếu trễ <1.5 tiếng ngày làm vc được tính 1 ngày 
               2. Nếu trễ 1.5-2h ngày làm vc được tính 1/2 ngày
            Ngày làm vc từ 8-12 tiếng: mỗi giờ thêm được tính bằng 2 giờ làm bình thường
            */

            TimeSpan duration = end - start;

            double totalWorkingTime = duration.TotalHours;

            if (totalWorkingTime < 8)
            {
                if (totalWorkingTime >= 6.5)
                {
                    return 0.5;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                int extraHours = (int)Math.Ceiling(totalWorkingTime - 8);
                return 8 + extraHours * 2;
            }
        }


        /*Hàm tính ngày nghỉ phép của nhân viên 
          nhận 2 giá trị : hoàn cảnh cá nhân , ngày nghỉ nv đã sử dụng
          trả về giá trị : ngày nghỉ phép hợp lệ của nhân viên 
          Ngoài ra : đã bổ sung 2 quy định từ công ty 
        */
        public double TinhPhep(string dieuKien, int ngayNghi)
        {
            int thamNien = DateTime.Now.Year - ngayvaolam.Year;
            double ngayPhep = 0;
            double luongThang = TinhLuong();

            if (thamNien >= 12)
            {
                switch (dieuKien)
                {
                    case "Điều kiện bình thường":
                        ngayPhep = 12;
                        break;
                    case "Điều kiện đặc biệt":
                        ngayPhep = 14;
                        break;
                    case "Điều kiện nặng nhọc":
                        ngayPhep = 16;
                        break;
                }
            }
            else
            {
                return ngayPhep;
            }

            if (ngayNghi > ngayPhep)
            {
                return luongThang * 0.2;
            }
            else if (ngayNghi < 0)
            {
                return luongThang * 2;
            }

            // Return a default value if none of the conditions are satisfied
            return 0;
        }

        /*
         Hàm tính phụ cấp/ trợ cấp của nhân viên 
         không cần nhận giá trị đầu vào !
         trả về giá trị : số tiền đã được phụ cấp        
       */

        public double TinhPhuCap(string BangCap ,string HinhThucNV)
        {

            /* 
            Học vị :THPT Phụ cấp 0; 
                    trung cấp phụ cấp 2000
                    cao đẳng phụ cấp 4000
                    đại học phụ cấp 6000 
                    thạc sỉ phụ cấp 8000 
                    tiến sĩ phụ cấp 10000

            Chức danh: "Nhan vien": phụ cấp chức danh = 2000; 
                       "Pho truong phong":phụ cấp chức danh  = 5000;
                       "Truong phong": phụ cấp = 10000;

            phụ cấp phòng ban: Kinh doanh phụ :cấp 5000;
                               Ke toan phụ :cấp  5000; 
                               Ban giam doc :phụ cấp  20000;
                               Hanh chanh :phụ cấp 10000; 
                               Bao ve     : phụ cấp 1000;

            Dòng này để trong hàm tính Lương nhé!
            luongThang = LCB + luongThamNien + luongHocVi + luongChucDanh + luongPhongBan;           
            */
            

            // Phụ cấp theo học vị
            int phuCapHocVi = 0;
            switch (BangCap)
            {
                case "Phụ cấp":
                    phuCapHocVi = 0;
                    break;
                case "Trung cấp":
                    phuCapHocVi = 2000;
                    break;
                case "Cao đẳng":
                    phuCapHocVi = 4000;
                    break;
                case "Đại học":
                    phuCapHocVi = 6000;
                    break;
                case "Thạc sĩ":
                    phuCapHocVi = 8000;
                    break;
                case "Tiến sĩ":
                    phuCapHocVi = 10000;
                    break;
            }

            // Phụ cấp theo chức danh
            int phuCapChucDanh = 0;
            switch (HinhThucNV)
            {
                case "Nhân viên":
                    phuCapChucDanh = 2000;
                    break;
                case "Phó trưởng phòng":
                    phuCapChucDanh = 5000;
                    break;
                case "Trưởng phòng":
                    phuCapChucDanh = 10000;
                    break;
            }

            // Phụ cấp theo phòng ban
            int phuCapPhongBan = 0;
            switch (HinhThucNV)
            {
                case "Kinh doanh":
                    phuCapPhongBan = 5000;
                    break;
                case "Kế toán":
                    phuCapPhongBan = 5000;
                    break;
                case "Ban giám đốc":
                    phuCapPhongBan = 20000;
                    break;
                case "Hành chính":
                    phuCapPhongBan = 10000;
                    break;
                case "Bảo vệ":
                    phuCapPhongBan = 1000;
                    break;
            }

            return phuCapHocVi + phuCapChucDanh + phuCapPhongBan;
        }


        public double TinhLuongParttime(string loaiCV)
        {
            /*
                loaiCV là "Van phong": lương partime 19000;
             
                loaiCV  "San xuat":luongParttime = 20000;
            */
            double luongParttime = 0;
            switch (loaiCV)
            {
                case "Văn phòng":
                    luongParttime = 19000;
                    break;
                case "Sản xuất":
                    luongParttime = 20000;
                    break;
                default:
                    return 0;
            }
            double soGioLam = TinhWorkingTime(ngayvaolam, DateTime.Now) - TinhPhep(dieukien, ngayNghi);
            double luong = luongParttime * soGioLam;
            return luong;
        }



        public double TinhLuong()
        {
            /*
             Số giờ làm được tính = giờ làm - ngày nghỉ phép 
             luong = luongGio * gioLam + Phucap - thue;
            */
            double luongGio = 23000;
            double soGioLam = TinhWorkingTime(ngayvaolam, DateTime.Now) - TinhPhep(dieukien, ngayNghi);
            double luong = luongGio * soGioLam + TinhPhuCap(bangcap ,hinhthucNV) - TinhThue();
            return luong;
        }

        public double TinhThue()
        {
            /*
                BHXH = luongThang * 8 / 100;
                BHYT = luongThang * 1.5 / 100;
                BHTN = luongThang * 1 / 100;
                TNCN = luongThang * 10 / 100;
                thue = BHXH + BHYT + BHTN + TNCN;
            */
            double luongThang = TinhLuong();
            double BHXH = luongThang * 8 / 100;
            double BHYT = luongThang * 1.5 / 100;
            double BHTN = luongThang * 1 / 100;
            double TNCN = luongThang * 10 / 100;
            double thue = BHXH + BHYT + BHTN + TNCN;

            return thue;
        }

        
    }
}
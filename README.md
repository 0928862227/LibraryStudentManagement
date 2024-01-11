Mục đích : Học OOP cơ bản ,Tạo 1 thư viện tái sử dụng nhiều lần 

Ngôn ngữ : C# với Console Window  và Class Library của Visual Studio

Bao gồm : Attributes, Constructor, Methods, Get/Set nếu biến ở phạm vi private ,...

Các chức năng bao gồm: 

1. Hàm tính thời gian làm việc 
          nhận 2 giá trị : thời gian bắt đầu vào làm , thời gian ra về 
          trả về giá trị : thời gian nhân viên làm việc trong cty
Có logic như sau :Thời gian làm việc = end - start.
            Nếu ngày làm vc < 8h 
               1. Nếu trễ <1.5 tiếng ngày làm vc được tính 1 ngày 
               2. Nếu trễ 1.5-2h ngày làm vc được tính 1/2 ngày
            Ngày làm vc từ 8-12 tiếng: mỗi giờ thêm được tính bằng 2 giờ làm bình thường
   
2. Hàm tính ngày nghỉ phép của nhân viên 
          nhận 2 giá trị : hoàn cảnh cá nhân , ngày nghỉ nv đã sử dụng
          trả về giá trị : ngày nghỉ phép hợp lệ của nhân viên 
          Ngoài ra : đã bổ sung 2 quy định từ công ty
   Có logic như sau :  Nếu thâm niên >= 12 thì 
			    1. Điều kiện bình thương có ngayphep là 12
			    2. điều kiện đặc biệt có ngayphep là 14
			    3. điều kiện nặng nhọc có ngày phép là 16
			Ngược lại thâm niên <12 thì ngayphep = thamNien
			    nếu nghỉ quá ngày phép thì tiền phạt = bằng 20% lương tháng
			    nếu ngày nghỉ <0 (tức là đi làm thêm ca) thì những ngày làm thêm lương = 200% lương thông thường

3.    Hàm tính phụ cấp/ trợ cấp của nhân viên 
         không cần nhận giá trị đầu vào !
         trả về giá trị : số tiền đã được phụ cấp

  Có logic như sau : Học vị :THPT Phụ cấp 0; 
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

4.  Hàm tính lương parttime của nhân viên parttime
            Nhận 1 giá trị đầu vào : loại CV 
            trả về giá trị : lương 1 giờ của nhân viên
    
    Logic :  loaiCV là "Van phong": lương partime 19000;
             
                loaiCV  "San xuat":luongParttime = 20000;

5. Tính Lương
  
6. Tính Thuế
Logic :  BHXH = luongThang * 8 / 100;
         BHYT = luongThang * 1.5 / 100;
         BHTN = luongThang * 1 / 100;
         TNCN = luongThang * 10 / 100;
         thue = BHXH + BHYT + BHTN + TNCN;


# :wave: Quản lý bán hàng lv1   :wave:

## ⏲️ Time: `*5/2023*`  📄 Language: `C#`  🗃️ Database: `SQL Sever`  

## 👨‍🏫 Teacher [Do Duy Cop](https://github.com/duycop)

---

# 💬 About Project:

### `🌱 Project nhỏ đầu tiên 🌱`
- Ứng dụng quản lý bán hàng xây dụng nhằm việc học ngôn ngữ `C#` và quản lý database `SQL Sever`.

    => Cùi mía  😥.

- App vừa theo kiểu mô hình 3 lớp vừa theo kiểu xây dựng thư viện xử lý tại form và các class chức năng. 

    => code == nồi lẩu 😥.

- Thực hành đến những phần đơn giản **C# .NET Framework 4.8** và tương tác đơn giản **Sql Sever**, phần thống kê báo cáo liên quan đến nhiều bảng và xử lý logic business chưa nhiều + độ chính xác chưa cao => 😥

### `🔥 But - However 🔥`
- Chưa code đc mấy phần khó chắc lại dùng laptop đểu. 🙄🤣🤪

- Đây chỉ là dự án đầu tiên, tiếp tới còn nhiều dự án khác. :sunrise_over_mountains: **Become better✈️**

### 🥰 Send your teacher: `Đỗ Duy Cốp` 👨‍🏫 (anh Cốp 🤗!!!)
> Sau khi học môn `lập trình Windows`, em cảm thấy đã học được rất nhiều kiến thức từ thầy và phần quý giá hơn là **`cảm hứng - mục tiêu học tập 👨‍🎓 `**

> Em cảm ơn thầy!😀 - mong thầy dạy dỗ chúng em nhiều hơn ạ! 😵💫
---

# 💣 ỨNG DỤNG QUẢN LÝ BÁN HÀNG 💣

### ✍️ Describe
- Solution: **QLBanHang** bao gồm 5 project `GUI`, `BLL`, `DAL`, `DTO` và `BotBanHang`
    -  **GUI:** Winform application phần thiết kế giao diện.
    -  **BLL:** Đúng chuẩn thì phần này sử lý logic NHƯNG mình chả xử lý gì ở đây cả => **~~BLL~~**.
    -  **DAL:** Phần tương tác DB - mk có viết code ở đó! nhưng tại vì khi tạo thêm một thư viện tương tác với DB thì mk k code chay ở phần DAL nữa.
    -  **DTO:** Các class hỗ trợ lữu trữ dữ liệu thành đối tượng khi tương tác trương trình.
    -  **BotBanHang:** Một con bot telegram được dùng để báo cáo vài thông tin tìm được ở DB.
 => Ứng dụng chạy trên máy mình cũng ổn 🤭 Mọi người có thể clone solution và chạy file sql để có database.
### Source Code

<b>1.Code 🧾 =>Clone gitHub:(src project: [QLBanHang_lv1](https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1))  </b>
<img src="severe pro" width="500">

**2.Database🗃️ => Image diagram (File source: [script_data_QLBanHang.sql](https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/GUI/T-SQL/script_data_QLBanHang.sql))**

<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/diag.png"  width="500">

**3.Image demo application🖼️ => Một số hình ảnh của ứng dụng:**

##### 💥Đăng nhập ứng dụng:

<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/dangNhap.png" width= 450>

##### 💥Module quản lý:

Gồm nhiều tab mỗi tab quản lý 1 đối tượng hay nhiệm vụ khác nhau:
| Mặt hàng | Đơn hàng |
| :--- | :--- |
| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/MatHang.png" width= 450>| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/DonHang.png" width= 450> |

|Khách hàng | Nhân viên |
|:--- | :--- |
|<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/KhachHang.png" width= 450>|<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/NhanVien.png" width= 450>|

| Nhà cung cấp | Thống kê - Báo cáo |
| :--- | :--- |
| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/NhaCC.png" with= 450>| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/TKBC.png" with= 450> |

| Quản lý sao lưu | About |
| :--- | :--- |
|<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/QLSL.png" with= 450> | <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/About.png" with= 450> |

##### 💥Module nhân viên:

Nhân viên hiện tại có chức năng chủ yếu quan trọng nhất là lập hóa đơn bán hàng:

<img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/LapHoaDOn.png" width= 550>


##### 💥Bot Telegram:

Tự động báo cáo một số hoạt động và trả lời dữ liệu thực về cửa hàng khi được hỏi:

| Lập hóa đơn mới | Tìm khách hàng | Báo cáo doanh thu | 
| :--- | :--- | :--- | 
| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/BotLapHD.png" width= 350>| <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/BotTimKIem.png" width= 350> | <img src="https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1/blob/master/img_redmid/BotThongKE.png" width= 350> |

...

...

...

## ⏹️ The end -- Ứng dụng hiện tại chỉ được như vậy! 😴 WAE kid2D 👋



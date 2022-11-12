<div id="Top"></div>

# QUẢN LÝ BÁN HÀNG QUẦN ÁO
Hỗ trợ các cửa hàng quần áo dễ dàng hơn trong việc quản lý.

## Mục lục

 [I. Mở đầu](#Modau)

 [II. Mô tả](#Mota)

> [1. Ý tưởng](#Ytuong)
>
> [2. Công nghệ](#Congnghe)
>
> [3. Người dùng](#Doituongsudung)
>
> [4. Mục tiêu](#Muctieu)
>
> [5. Tính năng](#Tinhnang)

[III. Tác giả](#Tacgia)

[IV. Người hướng dẫn](#Nguoihuongdan)

[V. Tổng kết](#Tongket)


<!-- MỞ ĐẦU -->
<div id="Modau"></div>

## I. Mở đầu
Kinh tế ngày càng phát triển, đây là thời buổi của công nghệ, của hệ thống số hóa, phần mềm và hệ thống quản lý bùng nổ một cách mạnh mẽ. Tận dụng điều đó, Chúng tôi nhìn thấy rằng thời trang đang là nhu cầu thiết yếu thường ngày và là sự lựa chọn ưu tiên của giới trẻ nói riêng cũng như toàn thể người dân nói chung. Để phục vụ cho việc quản lý bán quần áo một cách hiệu quả và an toàn, đáp ứng được công nghệ của thời đại, nhóm chúng tôi xây dựng lên phần mềm quản lý cửa hàng bán quần áo, sử dụng những công nghệ phù hợp, xây dựng lên giao diện thuận mắt nhằm phục vụ cho người tiêu dùng, cho cộng đồng cùng với bên cạnh là rất nhiều chức năng phục vụ cho việc quản lý sát với thực tiễn.


<!-- MÔ TẢ -->
<div id="Mota"></div>

## II. Mô tả

<!-- Ý TƯỞNG -->
<div id="Ytuong"></div>

### 1. Ý tưởng
* Hướng đến cải thiện trải nghiệm của người dùng, sử dụng công nghệ WPF, ngôn ngữ XAML đáp ứng được các yêu cầu khắt khe hơn, giao diện mới hơn, hiện đại và trực quan hơn, phù hợp với những tiêu chuẩn hiện tại, ngôn ngữ lập trình dễ hiểu, dễ tiếp cận, dễ dàng tạo và chỉnh sửa GUI.

* Sử dụng mô hình MVVM để tách riêng giao diện và xử lý, tăng khả năng sử dụng lại các thành phần hay việc thay đổi giao diện chương trình mà không cần phải viết lại code quá nhiều, có thể phát triển ứng dụng nhanh, dễ nâng cấp, bảo trì, mở rộng hay sửa chữa.

* Sử dụng Microsoft SQL Sever, đây chính là một loại phần mềm đã được phát triển bởi Microsoft và nó được sử dụng để có thể dễ dàng lưu trữ cho những dữ liệu dựa theo tiêu chuẩn RDBMS. SQL Server có khả năng cung cấp đầy đủ các công cụ cho việc quản lý từ giao diện GUI đến sử dụng ngôn ngữ cho việc truy vấn SQL


<div id="Congnghe"></div>

### 2. Công nghệ
* Hệ thống API: WPF - Mô hình MVVM
* IDE: Visual Studio 2019 (C#/.Net)
* Database: SQL Server
* Công cụ quản lý: Git, GitHub
* Entity Framework


<div id="Doituongsudung"></div>

### 3. Đối tượng sử dụng
Hệ thống các cửa hàng gồm:
* Chủ cửa hàng: Vai trò quản lý
* Nhân viên quản lý


<div id="Muctieu"></div>

### 4. Mục tiêu

 * <strong>Ứng dụng thực tế</strong>
 
    * Đáp ứng được các yêu cầu của khách hàng đặt ra, hệ thống mang tính ổn định cao, dễ sử dụng, không gây khó khăn cho người dùng, thiết kế dựa trên cơ sở sử dụng cho khách hàng là người Việt Nam.
    * Được sử dụng rộng rãi trong hệ thống các cửa hàng bán quần áo, thay thế cho các ứng dụng cũ còn nhiều hạn chế, giao diện lỗi thời hoặc các hình thức quản lý theo các thủ công truyền thống gây cồng kềnh, khó quản lý và dễ dẫn đến những sai sót không đáng có.
    * Trở thành một trong những ứng dụng được khách hàng lựa chọn, tin tưởng sử dụng.


 * <strong>Yêu cầu ứng dụng</strong>
 
    * Đáp ứng những tính năng tiêu chuẩn cần có trên những ứng dụng quản lý có trên thị trường. Ngoài ra, mở rộng và phát triển những tính năng mới hỗ trợ tối đa cho người dùng, tự động hóa các giai đoạn và các nghiệp vụ quản lý, khắc phục những hạn chế và yếu kém của hệ thống quản lý hiện tại.

    
    * Giao diện thân thiện, dễ sử dụng, bố cục hợp lý, hài hoà về màu sắc và mang tính đồng bộ cao, phân quyền cho người dùng thông qua tài khoản.
    
    * Ứng dụng phải tương thích với đa số các hệ điều hành phổ biến hiện nay như Window Vista SP1, Window 8.1, Window 10,...Đặc biệt, ứng dụng  trong quá trình sử dụng phải hoạt động ổn định, tránh những trường hợp xảy ra lỗi xung đột với hệ thống gây ra khó chịu cho người dùng trong quá trình sử dụng, tệ hơn là ảnh hưởng trực tiếp. Việc mở rộng, nâng cấp ứng dụng về sau phải dễ dàng khi người dùng có nhu cầu.


<div id="Tinhnang"></div>

### 5. Tính năng

  * Quản lý sản phẩm
  * Quản lý hóa đơn
  * Quản lý khách hàng
  * Quản lý nhân viên
  * Quản lý nhập hàng
  * Đăng nhập và đăng xuất
  * Báo cáo và thống kê
  * Cài đặt

<!-- TÁC GIẢ -->
<div id="Tacgia"></div>

## III. Tác giả

* [Tô Thế Kiệt – Trưởng nhóm](https://github.com/kiethongngu)

* [Đào Anh Tú](https://github.com/anhtu301003)

* [Ngô Hữu Thiên](https://github.com/takaesa)

* [Vũ Hoàng Nhật Minh](https://github.com/Minguml)


<!-- NGƯỜI HƯỚNG DẪN -->
<div id="Nguoihuongdan"></div>

## IV. Người hướng dẫn
* Giảng viên: Nguyễn Tấn Toàn



<!-- TỔNG KẾT -->
<div id="Tongket"></div>

## V. Tổng kết
Sản phẩm là kết quả sau quá trình cùng nhau thực hiện đồ án của những thành viên trong nhóm. Thông qua quá trình này, các thành viên đã có cho mình những lượng kiến thức và kỹ năng chuyên môn nhất định về quy trình lập trình thực tế, hiểu hơn về lập trình và có riêng cho mình những bài học quý giá làm hành trang cho công việc sau này.

Ngoài ra, nhóm cũng muốn gửi lời cảm ơn chân thành và sự tri ân sâu sắc đến giảng viên giảng dạy, thầy Nguyễn Tấn Toàn đã cùng đồng hành với nhóm trong suốt quá trình thực hiện đồ án để có được thành quả như hôm nay.

Sản phẩm của nhóm có thể còn nhiều thiếu sót trong quá trình xây dựng và phát triển. Vì vậy, đừng ngần ngại gửi những đóng góp hoặc ý kiến của bạn Mỗi đóng góp của các bạn đều sẽ được ghi nhận và sẽ là động lực để nhóm có thể hoàn thiện sản phẩm hơn nữa.

Cảm ơn bạn đã quan tâm!

---

<p align="right"><a href="#Top">Quay lại đầu trang</a></p>


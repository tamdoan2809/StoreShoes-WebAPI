-- Tạo cơ sở dữ liệu QL_ShopGiayTest1
USE master;
Go

DROP DATABASE QL_ShopGiay;
Go

CREATE DATABASE QL_ShopGiay;
GO

-- Sử dụng cơ sở dữ liệu QL_ShopGiayTest1
USE QL_ShopGiay;
GO

-- Tạo bảng Loai với MaLoai tự động tăng dần
CREATE TABLE Loai (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(50),
    Note NVARCHAR(150)
);

-- Tạo bảng SanPham với MaSP tự động tăng dần
CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(100),
    GiaBan FLOAT,
    MoTa NVARCHAR(600),
    NgayCapNhat DATE,
    Anh NVARCHAR(100),
    SLTon INT, 
    MaLoai INT,
    FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);

-- Tạo bảng KhachHang với MaKH tự động tăng dần
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(30),
    NgaySinh DATE,
    GioiTinh NVARCHAR(3),
    DienThoai NVARCHAR(15),
    TaiKhoan NVARCHAR(20),
    MatKhau NVARCHAR(20),
    Email NVARCHAR(20),
    DiaChi NVARCHAR(50)
);

-- Tạo bảng DonHang với MaDonHang tự động tăng dần
CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    NgayGiao DATE,
    NgayDat DATE,
    DaThanhToan NVARCHAR(10),
    TinhTrangGiaoHang NVARCHAR(10),
    MaKH INT,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaSP INT, 
    SoLuong INT, 
    DonGia FLOAT,
    PRIMARY KEY (MaDonHang, MaSP),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

-- Chèn một loại sản phẩm để đảm bảo MaLoai tồn tại
Insert into Loai(TenLoai,Note)
values (N'Giày chạy',N'Giày chạy bộ'),
(N'Giày bóng rổ',N'Giày chơi bóng rổ'),
(N'Giày Golf',N'Giày Đánh Golf');

-- Chèn 3 sản phẩm giày vào bảng SanPham
INSERT INTO SanPham (TenSP, GiaBan, MoTa, NgayCapNhat, Anh, SLTon, MaLoai)
VALUES 
(N'Giày Thể Thao Nike Air Max', 2000000, N'Giày thể thao cao cấp Nike Air Max, kiểu dáng hiện đại', '2024-06-07', N'nike_air_max.png', 50, 1),
(N'Giày Chạy Bộ Adidas Ultraboost', 3000000, N'Giày chạy bộ Adidas Ultraboost, đệm êm ái, hỗ trợ tốt', '2024-06-07', N'adidas_ultraboost.png', 30, 1),
(N'Giày Sneaker Converse Chuck Taylor', 1500000, N'Giày sneaker Converse Chuck Taylor cổ điển, phong cách và bền bỉ', '2024-06-07', N'converse_chuck_taylor.png', 100, 1),
(N'Giày Air Jordan 4 Retro ‘Military Blue’ 2024 FV5029-141', 6890000, N'Giày Air Jordan 4 Retro ‘Military Blue’ 2024 FV5029-141 là phiên bản tái phát hành đầy ấn tượng của mẫu giày bóng rổ huyền thoại được ra mắt lần đầu vào năm 1989. Mang trong mình thiết kế nguyên bản kết hợp với những cải tiến hiện đại, đôi giày này hứa hẹn sẽ khuấy đảo cộng đồng sneakerheads vào mùa hè năm 2024.', '2024-06-07', N'Air_Jordan_4_Retro_Military_Blue_2024_Fv5029_141.jpg', 20, 2),
(N'Giày Nike Zoom Kobe 6 Protro ‘Italian Camo’ FQ3546-001', 12690000, N'Nike Zoom Kobe 6 Protro ‘Italian Camo’ mang lại phối màu năm 2011 kỷ niệm những năm thành lập Kobe Bryant tại Ý. Họa tiết ngụy trang tinh tế màu ô liu và đen bao phủ phần trên bằng lưới vi mô, nổi bật với các ‘hòn đảo’ polyurethane nổi lên mô phỏng họa tiết da rắn. Một dấu Swoosh màu đỏ thẫm tô điểm cho mặt bên, phù hợp với logo cá nhân của Kobe Bryant trên lưỡi gà. Phần trên thấp được trang bị bộ đếm gót TPU trong mờ mang dấu ấn đặc trưng của Kobe. Được cải tiến bằng bọt Cushlon nhẹ, đế giữa có bộ phận Zoom Turbo ở bàn chân trước.', '2024-06-07', N'Nike-Zoom-Kobe-6-Protro-Italian-Camo-FQ3546-001.jpg', 20, 2),
(N'Giày Air Jordan 1 Retro High OG ‘Green Glow’ DZ5485-130', 4690000, N'Air Jordan 1 Retro High OG ‘Green Glow’ thể hiện phong cách phối màu ‘Bred Toe’ với những gam màu rực rỡ. Phần trên bằng da mịn kết hợp các mặt bên màu trắng với các điểm nhấn màu đen tương phản trên cổ giày cắt cao, lớp phủ bàn chân trước và dấu Swoosh đặc trưng. Green Glow bao phủ phần ngón chân, gót chân và mắt cá chân, được đánh dấu bằng logo Wings màu đen ở mặt bên. Thẻ Nike Air dệt tô điểm cho lưỡi nylon màu đen. Hỗ trợ đôi giày thể thao này là một đế cốc bền bỉ, có thành bên màu trắng và đế ngoài bằng cao su màu xanh mòng két sáng màu.', '2024-06-07', N'Giay-Air-Jordan-1-Retro-High-OG-Green-Glow-DZ5485-130.jpg', 100, 2),
(N'Giày Air Jordan 1 Low ‘Jade Smoke’ (WMNS) DC0774-001', 3390000, N'Sở hữu tông màu trắng thanh lịch làm chủ đạo, đôi giày này khéo léo hòa quyện những chi tiết màu xanh ngọc bích nhạt (Jade Smoke) độc đáo. Từ logo Swoosh biểu tượng, đường chỉ khâu đến lớp lót cổ chân – tất cả đều sử dụng sắc xanh “hút hồn” này. Không chỉ vậy, sự kết hợp giữa da mịn và da lộn cao cấp càng làm tôn lên vẻ tinh tế và sang trọng của đôi giày.', '2024-06-07', N'Air-Jordan-1-Low-Jade-Smoke-WMNS-DC0774-001.jpg', 25, 2),
(N'Giày nam adidas Runfalcon ‘Dark Blue’ F36201', 1990000, N'Giày Air Jordan 4 Retro ‘Military Blue’ 2024 FV5029-141 là phiên bản tái phát hành đầy ấn tượng của mẫu giày bóng rổ huyền thoại được ra mắt lần đầu vào năm 1989. Mang trong mình thiết kế nguyên bản kết hợp với những cải tiến hiện đại, đôi giày này hứa hẹn sẽ khuấy đảo cộng đồng sneakerheads vào mùa hè năm 2024.', '2024-06-07', N'adidas-Runfalcon-‘Dark-Blue-F36201.jpg', 20, 1),
(N'Giày Nike Ace Summerlite DC0101-108', 2790000, N'Nike Ace Summerlite hiện đã có sẵn Shop, đừng bỏ lỡ cơ hội của mình nhé!', '2024-06-07', N'Nike-Ace-Summerlite-DC0101-108-2.jpg', 28, 1),
(N'Giày adidas Adizero Boston 11 M GX6650', 3890000, N'Giày adidas Adizero Boston 11 M GX6650 hiện đã có sẵn tại Shop, đừng bỏ lỡ cơ hội của mình nhé!', '2024-06-07', N'adidas-adizero-boston-11-m-gx-6650.jpg', 30, 1),
(N'Giày adidas UltraBoost 4.0 ‘Triple White’ BB6168', 3890000, N'adidas Ultra Boost 4.0 White đã được đồn đại trong một thời gian khá dài với bản phát hành dự kiến vào tháng 12 hoặc đầu năm 2018. Rất may vì ở thời điểm hiện tại, bạn không cần không cần phải chờ đợi lâu cho phiên bản sneaker êm ái này.', '2024-06-07', N'adidas-ultra-boost-4-0-white-bb3929.jpg', 50, 1),
(N'Giày Nike Downshifter 11 M ‘Black’ CW3411-002', 1890000, N'Nike Downshifter 11 M ‘Black’hiện đã có sẵn tại Shop với mức giá hấp dẫn, đừng bỏ lỡ cơ hội của mình nhé!', '2024-06-07', N'Nike-Downshifter-11-M-‘Black-CW3411-002.jpg', 28, 1),
(N'Giày Golf Nike Vapor Golf Wide ‘White’ AQ2301-100', 1720000, N'Nike Vapor Golf Wide ‘White’ hiện đã có sẵn tại Shop, đừng bỏ lỡ cơ hội của mình nhé!.', '2024-06-07', N'Golf-Nike-Vapor-Golf-Wide-White-AQ2301-100.jpg', 15, 3),
(N'Giày Golf Nike Air Zoom Victory Pro 3 ‘Wide’ DX9028-103', 4290000, N'Giày golf Nike Air Zoom Victory Pro 3 ‘Wide’ DX9028-103 là phiên bản dành cho người có bàn chân rộng của dòng giày golf Air Zoom Victory Pro 3, được ra mắt vào năm 2023. Đôi giày này mang đến sự kết hợp hoàn hảo giữa sự thoải mái, ổn định và hiệu suất chơi golf đỉnh cao, hứa hẹn sẽ là người bạn đồng hành đáng tin cậy trên sân golf của bạn.', '2024-06-07', N'Golf-Nike-Air-Zoom-Victory-Pro-3-Wide-DX9028-103.jpg', 18, 3),
(N'Giày Golf Nam Nike Vapor AQ2301-103', 2390000, N'Golf Nam Nike Vapor hiện đã có sẵn tại Shop, đừng bỏ lỡ cơ hội của mình nhé!', '2024-06-07', N'Golf-Nam-Nike-Vapor-AQ2301-103-5.jpg', 18, 3);


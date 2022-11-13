CREATE DATABASE QLBH_
USE QLBH_
--DROP DATABASE QLBH_

CREATE TABLE KHACHHANG (
	MAKH varchar(50) primary key,
	HOTEN nvarchar(50) NOT NULL,
	GIOITINH nvarchar(5),
	DCHI nvarchar(50),
	SDT varchar(50) NOT NULL
)

CREATE TABLE NGUOIDUNG (
	MAND varchar(50) primary key,
	TENND nvarchar(50) NOT NULL ,
	NGSINH smalldatetime,
	GIOITINH nvarchar(5),
	SDT char(50) NOT NULL ,
	DIACHI nvarchar(50),
	USERNAME char(50),
	PASS nvarchar(max),
	QTV bit NOT NULL DEFAULT (0),
	TTND bit NOT NULL DEFAULT(1),
	AVA varchar(max),
	MAIL varchar(100)
)

CREATE TABLE SANPHAM (
	MASP varchar(50) primary key,
	TENSP nvarchar(50) NOT NULL,
	GIA int NOT NULL,
	MOTA nvarchar(max),
	HINHSP nvarchar(max),
	SL int NOT NULL,
	LOAISP nvarchar(50),
	SIZE nvarchar(50)
)

CREATE TABLE HOADON (
	SOHD int primary key,
	MAND varchar(50),
	MAKH varchar(50),
	NGHD smalldatetime NOT NULL,
	TRIGIA int  NOT NULL,
	KHUYENMAI int	
)

CREATE TABLE PHIEUNHAP (
	MAPN int primary key,
	MAND varchar(50),
	NGAYNHAP smalldatetime NOT NULL 
)

CREATE TABLE CTHD (
	SOHD int,
	MASP varchar(50),
	SL int NOT NULL,
	primary key(SOHD, MASP)
)

CREATE TABLE CTPN (
	MAPN int,
	MASP varchar(50),
	SL int NOT NULL,
	primary key(MAPN, MASP)
)

ALTER TABLE HOADON
ADD CONSTRAINT FK_KH_HD
FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE HOADON
ADD CONSTRAINT FK_HD_ND
FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND)

ALTER TABLE CTHD
ADD CONSTRAINT FK_CT_HD
FOREIGN KEY (SOHD) REFERENCES HOADON(SOHD)

ALTER TABLE CTHD
ADD CONSTRAINT FK_CT_SP
FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE CTPN 
ADD CONSTRAINT FK_CN_SP
FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE CTPN
ADD CONSTRAINT FK_CN_PN
FOREIGN KEY (MAPN) REFERENCES PHIEUNHAP(MAPN)

ALTER TABLE PHIEUNHAP
ADD CONSTRAINT FK_PN_ND
FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND)
GO

INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH01',N'Nguyễn Văn A',N'731 Trần Hưng Đạo, Q5, TPHCM','0908823451',N'Nam')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH02',N'Trần Thị B',N'23/5 Nguyễn Trãi, Q5, TPHCM','0908256478',N'Nữ')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH03',N'Trần Văn C',N'45 Nguyễn Du, Q1, TPHCM','0938776266',N'Nam')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH04',N'Trần D',N'50/34 Lê Đại Hành, Q10, TPHCM','0917325476',N'Nam')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH05',N'Lê Thị E',N'34 Trương Định, Q3, TPHCM','0908246108',N'Nữ')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH06',N'Nguyễn Văn F',N'227 Nguyễn Văn Cừ, Q5, TPHCM','0908631738',N'Nam')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH07',N'Nguyễn Văn G',N'32/3 Trần Bình Trọng, Q5, TPHCM','0916783565',N'Nam')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH08',N'Phan Thị H',N'45/2 An Dương Vương, Q5, TPHCM','0938435756',N'Nữ')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH09',N'Đào Thị I',N'873 Lê Hồng Phong, Q5, TPHCM','0908654763',N'Nữ')
INSERT INTO KHACHHANG(MAKH,HOTEN,DCHI, SDT,GIOITINH) VALUES('KH10',N'Lê K',N'34/34B Nguyễn Trãi, Q1, TPHCM','0908768904',N'Nam')
GO
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('QL01',N'Tô Thế Kiệt','2003-10-08',N'Nam','0922222222',N'ĐH CNTT, ĐHQG TPHCM','admin1','6fd742a61bd034804c00c49b18045020','1',N'1','/Resource/Ava/kiet.jpg',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV01',N'Đào Anh Tú','2002-09-15',N'Nam','0933333333',N'ĐH CNTT, ĐHQG TPHCM','user1','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Ava/tu.jpg',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV02',N'Nguyễn A','2002-02-17',N'Nam','0944444444',N'Kp6, Linh Trung, Thủ Đức','user2','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV03',N'Nguyễn B','2002-02-18',N'Nữ','0955555555',N'Kp6, Linh Trung, Thủ Đức','user3','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV04',N'Nguyễn C','2002-02-19',N'Nam','0966666666',N'Kp6, Linh Trung, Thủ Đức','user4','6fd742a61bd034804c00c49b18045021','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV05',N'Nguyễn D','2002-02-20',N'Nữ','0977777777',N'Kp6, Linh Trung, Thủ Đức','user5','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV06',N'Nguyễn E','2002-02-21',N'Nam','0988888888',N'Kp6, Linh Trung, Thủ Đức','user6','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV07',N'Nguyễn F','2002-02-22',N'Nữ','0999999999',N'Kp6, Linh Trung, Thủ Đức','user7','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV08',N'Nguyễn G','2002-02-23',N'Nam','0911111111',N'Kp6, Linh Trung, Thủ Đức','user8','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
INSERT INTO NGUOIDUNG(MAND,TENND,NGSINH,GIOITINH,SDT,DIACHI,USERNAME,PASS,QTV,TTND,AVA,MAIL) VALUES('NV09',N'Nguyễn H','2002-02-24',N'Nữ','0900000000',N'Kp6, Linh Trung, Thủ Đức','user9','6fd742a61bd034804c00c49b18045020','0',N'1','/Resource/Image/addava.png',N'thekiet.contact@gmail.com')
GO
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AK01',N'Suy Sweater','750000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/suy_sweater.jpg','50',N'Áo tay dài','Freesize') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AK02',N'Chaotic Jacket Jean','900000',N'98% COTTON, 2% ELASTANE
 XỬ LÝ DISSTRESSED','/Resource/ImgProduct/chaotic_jacket.jpg','50',N'Áo khoác','Freesize') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AK03',N'Rabbit Gile','650000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HOẠT TIẾT HÌNH IN KÉO LỤA','/Resource/ImgProduct/rabbit_gile.jpg','30',N'Áo khoác','Freesize') 
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AK04',N'Cross Jacket','680000',N'100% COTTON PHỐI LÓT VẢI BÊN TRONG','/Resource/ImgProduct/cross_jacket.png','35',N'Áo khoác','Freesize')
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AK05',N'Rabbit Cardigan','900000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN BO CỔ: 100% COTTON

PHẦN BO TAY: 100% COTTON

HOẠT TIẾT HÌNH BANH NỈ GAI IN KÉO LỤA','/Resource/ImgProduct/rabbit_cardigan.jpg','30',N'Áo khoác','Freesize') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT01',N'Good Student','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_student.jpg','100',N'Áo thun','S') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT02',N'Good Student','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_student.jpg','50',N'Áo thun','M') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT03',N'Good Student','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_student.jpg','70',N'Áo thun','L') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT04',N'Good Student','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_student.jpg','30',N'Áo thun','XL') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT05',N'Sample','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/sample.jpg','80',N'Áo thun','L') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT06',N'Sample','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/sample.jpg','70',N'Áo thun','M') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT07',N'Sample','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/sample.jpg','60',N'Áo thun','S') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT08',N'Sample','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/sample.jpg','100',N'Áo thun','XL') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT09',N'Pagoda','420000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/pagoda.jpg','50',N'Áo thun','S') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT10',N'Pagoda','420000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/pagoda.jpg','40',N'Áo thun','M') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT11',N'Pagoda','420000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/pagoda.jpg','60',N'Áo thun','L') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT12',N'Pagoda','420000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/pagoda.jpg','30',N'Áo thun','XL') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT13',N'Over Print Tee','350000',N'PHẦN VẢI CHÍNH: 100% COTTON

 PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/over_print.jpg','30',N'Áo thun','S') 
 INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT14',N'Over Print Tee','350000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/over_print.jpg','50',N'Áo thun','M') 
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT15',N'Over Print Tee','350000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/over_print.jpg','40',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT16',N'Over Print Tee','350000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/over_print.jpg','20',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT17',N'Blessing','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/blessing.jpg','30',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT18',N'Blessing','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/blessing.jpg','40',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT19',N'Blessing','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/blessing.jpg','30',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT20',N'Blessing','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/blessing.jpg','30',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT21',N'Mechabit Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/mechabit.jpg','30',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT22',N'Mechabit Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/mechabit.jpg','40',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT23',N'Mechabit Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/mechabit.jpg','20',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT24',N'Mechabit Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/mechabit.jpg','5',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT25',N'Painful','450000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/mechabit.jpg','5',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT26',N'Painful','450000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/painful.jpg','10',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT27',N'Painful','450000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/painful.jpg','10',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT28',N'Painful','450000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/painful.jpg','15',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT29',N'Full Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/full_rabbit.jpg','50',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT30',N'Full Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/full_rabbit.jpg','50',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT31',N'Full Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/full_rabbit.jpg','30',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT32',N'Full Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/full_rabbit.jpg','30',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT33',N'Rabbit Cyber','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/rabbit_cyber.jpg','50',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT34',N'Rabbit Cyber','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/rabbit_cyber.jpg','30',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT35',N'Rabbit Cyber','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/rabbit_cyber.jpg','30',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT36',N'Rabbit Cyber','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/rabbit_cyber.jpg','30',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT37',N'Lucky You Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/lucky_you.jpg','20',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT38',N'Lucky You Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/lucky_you.jpg','15',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT39',N'Lucky You Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/lucky_you.jpg','35',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT40',N'Lucky You Tee','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/lucky_you.jpg','25',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT41',N'Good Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_rabbit.jpg','30',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT42',N'Good Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_rabbit.jpg','40',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT43',N'Good Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_rabbit.jpg','20',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT44',N'Good Rabbit','350000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/good_rabbit.jpg','15',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT45',N'Ruby Tie Dye Tee','420000',N'VẢI CHÍNH: 100% COTTON

BO CỔ: 100% COTTON

MÀU: KỸ THUẬT NHUỘM THỦ CÔNG','/Resource/ImgProduct/ruby_tie_dye.jpg','20',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT46',N'Ruby Tie Dye Tee','420000',N'VẢI CHÍNH: 100% COTTON

BO CỔ: 100% COTTON

MÀU: KỸ THUẬT NHUỘM THỦ CÔNG','/Resource/ImgProduct/ruby_tie_dye.jpg','30',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT47',N'Ruby Tie Dye Tee','420000',N'VẢI CHÍNH: 100% COTTON

BO CỔ: 100% COTTON

MÀU: KỸ THUẬT NHUỘM THỦ CÔNG','/Resource/ImgProduct/ruby_tie_dye.jpg','40',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT48',N'Ruby Tie Dye Tee','420000',N'VẢI CHÍNH: 100% COTTON

BO CỔ: 100% COTTON

MÀU: KỸ THUẬT NHUỘM THỦ CÔNG','/Resource/ImgProduct/ruby_tie_dye.jpg','20',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT49',N'Excited','450000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/excited.jpg','20',N'Áo thun','S')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT50',N'Excited','450000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/excited.jpg','15',N'Áo thun','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT51',N'Excited','450000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/excited.jpg','20',N'Áo thun','L')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('AT52',N'Excited','450000',N'PHẦN  VẢI: 100% COTTON

PHẦN BO CỔ: 100% COTTON

HỌA TIẾT IN KÉO LỤA THỦ CÔNG','/Resource/ImgProduct/excited.jpg','30',N'Áo thun','XL')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('SM01',N'Striped Shirt','480000',N'PHẦN VẢI CHÍNH: 65% POLYESTER 35% COTTON

HỌA TIẾT IN CHUYỂN NHIỆT','/Resource/ImgProduct/striped_shirt.jpg','50',N'Áo sơ mi','Freesize')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('SM02',N'Pattern Shirt','520000',N'PHẦN VẢI CHÍNH: 100% COTTON

PHẦN CỔ BO: 100% COTTON

HỌA TIẾT TRÀN IN KTS','/Resource/ImgProduct/pattern_shirt.jpg','45',N'Áo sơ mi','Freesize')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('SM03',N'Comic Shirt','520000',N'PHẦN VẢI CHÍNH: 65% POLYESTER 35% COTTON

HỌA TIẾT IN CHUYỂN NHIỆT','/Resource/ImgProduct/comic_shirt.jpg','30',N'Áo sơ mi','Freesize')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK01',N'Mascot Tattooss Hoodie','520000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Hoodie1.jpg','30',N'Áo trùm đầu','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK02',N'Flower Hoodie','520000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Hoodie2.jpg','50',N'Áo trùm đầu','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK03',N'Paint Mascot Hoodie','520000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Hoodie3.jpg','50',N'Áo trùm đầu','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK04',N'Time-Stop Hoodie','490000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Hoodie4.jpg','50',N'Áo trùm đầu','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK05',N'Sweater Tiedye','490000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Sweater1.jpg','50',N'Áo tay dài','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK06',N'Basic Sweater','490000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Sweater2.jpg','50',N'Áo tay dài','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK07',N'Mascot Sweater','470000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Sweater3.jpg','50',N'Áo tay dài','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK08',N'I''m Sick Sweater','470000',N'- Chất Liệu: Vải nỉ bông

- Chất liệu in: in lụa','/Resource/ImgProduct/Sweater4.jpg','50',N'Áo tay dài','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK09',N'OutDoor Jacket','520000',N'- Chất liệu : Dù 2 lớp

- Phối màu: Xanh Đen - Vàng

- Chi tiết : Thêu nổi 3d 100 cotton

- Phối tay : Phản quang','/Resource/ImgProduct/Jacket1.jpg','50',N'Áo khoác','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK10',N'Clownz Jacket','850000',N'- Chất liệu: vải dạ (lót 2 lớp)

- Màu sắc: Đen, xanh

- Dáng xuông rộng

- Sử dụng khuy dập

- Mặt sau: Hình thêu logo sử dụng chất liệu bông xù','/Resource/ImgProduct/Jacket2.jpg','50',N'Áo khoác','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK11',N'EMGO VARSITY ','890000',N'MATERIAL: CORDUROY (COTTON + POLY)','/Resource/ImgProduct/Jacket3.jpg','50',N'Áo khoác','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK12',N'Basic Sweapant - Black','420000',N'Chất liệu: Vải dù.

Họa tiết thêu

Form quần ống suông','/Resource/ImgProduct/quan1.jpg','50',N'Quần','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK13',N'Line Pants - Black','420000',N'Chất liệu: Vải dù.

Họa tiết thêu

Form quần ống suông','/Resource/ImgProduct/quan2.jpg','50',N'Quần','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK14',N'Black/ White Pants','420000',N'Chất liệu: Vải dù.

Họa tiết thêu

Form quần ống suông','/Resource/ImgProduct/quan3.jpg','50',N'Quần','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK15',N'Mascot Short - Black','350000',N'Chất liệu: Vải chân cua

Chất liệu in: kéo lụa','/Resource/ImgProduct/quan4.jpg','50',N'Quần','M')
INSERT INTO SANPHAM(MASP,TENSP,GIA,MOTA,HINHSP,SL,LOAISP,SIZE) VALUES('TK16',N'Terry Short - Pink','350000',N'Chất liệu vải : Chân Cua (Vải thun dày)

Họa tiết :  Thêu

','/Resource/ImgProduct/quan5.jpg','50',N'Quần','M')
create database BTL_LTTQ
use BTL_LTTQ

create table Loai (
	MaLoai nvarchar(30) not null primary key,
	TenLoai nvarchar(30)
);
create table NuocSX (
	MaNuocSX nvarchar(30) not null primary key,
	TenNuocSX nvarchar(30)
);
create table UserName (
	Username nvarchar(50) not null primary key,
	Password nvarchar(50) not null,
);
create table Nha_Cung_Cap (
	MaNCC nvarchar(30) not null primary key,
	TenNCC nvarchar(30),
	DiaChi nvarchar(30),
	DienThoai nvarchar(30)
);
create table Khach_Hang (
	MaKH nvarchar(30) not null primary key, 
	TenKH nvarchar(30),
	DiaChi nvarchar(30),
	SDT nvarchar(30),
	Username nvarchar(50),
	foreign key (Username) references UserName(Username)
	on delete no action
	on update no action
);
create table Nhan_Vien (
	MaNV nvarchar(30) not null primary key,
	TenNV nvarchar(30),
	GioiTinh bit,
	NgaySinh datetime,
	SDT nvarchar(10),
	DiaChi nvarchar(30),
	Username nvarchar(50),
	foreign key (Username) references UserName(Username)
	on delete no action
);
create table Hang_Hoa (
	MaHang nvarchar(30) not null primary key,
	TenHang nvarchar(30),
	DungTich nvarchar(30),
	MaLoai nvarchar(30),
	MaNuocSX nvarchar(30),
	DoRuou nvarchar(30),
	SoLuong int,
	DonGiaNhap int,
	DonGiaBan int,
	foreign key (MaLoai) references Loai(MaLoai)
	on delete no action
	on update no action,
	foreign key (MaNuocSX) references NuocSX(MaNuocSX)
	on delete no action
	on update no action,

);
create table Hoa_Don_Ban (
	SoHDB nvarchar(30) not null primary key,
	MaNV nvarchar(30),
	MaKH nvarchar(30),
	NgayBan datetime,
	TongTien int,
	Username nvarchar(50),
	foreign key (Username) references UserName(Username)
	on delete no action
	on update no action,
	foreign key(MaKH) references Khach_Hang(MaKH)
	on delete no action
	on update no action,
	foreign key(MaNV) references Nhan_Vien(MaNV)
	on delete no action
	on update no action,
);
create table ChiTietHDB (
	SoHDB nvarchar(30),
	MaHang nvarchar(30),
	SoLuong int,
	GiamGia int,
	ThanhTien int,
	foreign key(SoHDB) references Hoa_Don_Ban(SoHDB)
	on delete no action
	on update no action,
	foreign key(MaHang) references Hang_Hoa(MaHang)
	on delete no action
	on update no action,
);
create table Hoa_Don_Nhap (
	SoHDN nvarchar(30) not null primary key,
	MaNV nvarchar(30),
	NgayNhap datetime,
	MaNCC nvarchar(30),
	TongTien int,
	foreign key (MaNV) references Nhan_Vien(MaNV)
	on delete no action
	on update no action,
	foreign key (MaNCC) references Nha_Cung_Cap(MaNCC)
	on delete no action
	on update no action
);
create table ChiTietHDN (
	SoHDN nvarchar(30),
	MaHang nvarchar(30),
	SoLuong int,
	GiamGia int,
	ThanhTien int
	foreign key(SoHDN) references Hoa_Don_Nhap(SoHDN)
	on delete no action
	on update no action,
	foreign key(MaHang) references Hang_Hoa(MaHang)
	on delete no action
	on update no action,
);

--UserName
go
insert [dbo].[UserName] ([Username],[Password]) values ('NVdonghieu123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('NVducluan123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('NVviethoang123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('NVnguyenhoai123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('manhhung123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('chihieu123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('thuytrang123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('anhduc123','12345')
insert [dbo].[UserName] ([Username],[Password]) values ('tuantran123','12345')
go
--Nha_Cung_Cap
go
insert [dbo].[Nha_Cung_Cap] ([MaNCC],[TenNCC],[DiaChi],[DienThoai]) values ('NCC01',N'Rượu Song Long',N'117 Trần Duy Hưng','0376999986')
insert [dbo].[Nha_Cung_Cap] ([MaNCC],[TenNCC],[DiaChi],[DienThoai]) values ('NCC02',N'Rượu Ngoại 68',N'30A Đoàn Thị Điểm','0978406415')
insert [dbo].[Nha_Cung_Cap] ([MaNCC],[TenNCC],[DiaChi],[DienThoai]) values ('NCC03',N'TNHH Thiên Linh',N'Ngõ 183, Đường Hoàng Văn Thái','0912009916')
insert [dbo].[Nha_Cung_Cap] ([MaNCC],[TenNCC],[DiaChi],[DienThoai]) values ('NCC04',N'VINCROP',N'21 Ngõ Huế, P. Ngô Thì Nhậm','(024) 39766167')
insert [dbo].[Nha_Cung_Cap] ([MaNCC],[TenNCC],[DiaChi],[DienThoai]) values ('NCC05',N'Malthop VN',N'72 Trung Hòa','(024) 37833147')
go
--Loai
go
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L001',N'Rượu nhẹ')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L002',N'Rượu mạnh')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L003',N'Vodka rượu mạnh')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L004',N'Vodka rượu nhẹ')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L005',N'Vang đỏ')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L006',N'Vang hồng')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L007',N'Vang trắng')
insert [dbo].[Loai] ([MaLoai],[TenLoai]) values ('L008',N'Vang nổ')
go
--NuocSX
go
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX01',N'Việt Nam')
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX02',N'Chile')
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX03',N'Mỹ')
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX04',N'Tây ban nha')
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX05',N'Ý')
insert [dbo].[NuocSX] ([MaNuocSX],[TenNuocSX]) values('NSX06',N'Pháp')
go
--KhachHang
go
insert [dbo].[Khach_Hang] ([MaKH],[TenKH],[DiaChi],[SDT],[username]) values (N'KH001',N'Mạnh Hùng',N'Đại học giao thông','0978112456','manhhung123')
insert [dbo].[Khach_Hang] ([MaKH],[TenKH],[DiaChi],[SDT],[username]) values (N'KH002',N'Chí Hiếu',N'Số 1 chùa Láng ','0978112221','chihieu123')
insert [dbo].[Khach_Hang] ([MaKH],[TenKH],[DiaChi],[SDT],[username]) values (N'KH003',N'Thùy Trang',N'Số 3 Nguyễn Trí Thanh','0978112332','thuytrang123')
insert [dbo].[Khach_Hang] ([MaKH],[TenKH],[DiaChi],[SDT],[username]) values (N'KH004',N'Đức Anh',N'20 Phố Nhổn','0978112112','anhduc123')
insert [dbo].[Khach_Hang] ([MaKH],[TenKH],[DiaChi],[SDT],[username]) values (N'KH005',N'Trần Tuấn',N'Số 10 Ô Chợ Dừa','0978112333','tuantran123')
go
--NhanVien
go
insert [dbo].[Nhan_Vien] ([MaNV],[TenNV],[GioiTinh],[NgaySinh],[SDT],[DiaChi],[username]) values (N'NV001',N'Đinh Hiếu',0,'2001/03/24','0353172554',N'ngõ 898 đường láng','NVdonghieu123')
insert [dbo].[Nhan_Vien] ([MaNV],[TenNV],[GioiTinh],[NgaySinh],[SDT],[DiaChi],[username]) values (N'NV002',N'Đức Luận',0,'2001/12/11','0353162334',N'số 2 Hồ tùng mậu','NVducluan123')
insert [dbo].[Nhan_Vien] ([MaNV],[TenNV],[GioiTinh],[NgaySinh],[SDT],[DiaChi],[username]) values (N'NV003',N'Việt Hoàng',0,'2001/1/11','0353122345',N'số 8 lĩnh nam','NVviethoang123')
insert [dbo].[Nhan_Vien] ([MaNV],[TenNV],[GioiTinh],[NgaySinh],[SDT],[DiaChi],[username]) values (N'NV004',N'Nguyễn Hoài',1,'2001/11/22','0353122333',N'202 Xuân thủy','NVnguyenhoai123')
go
--Hang_Hoa
go
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH0',N'Rượu mơ hà nội 1898','L001',43,0.5,14.5,'NSX03',130000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH001',N'Rượu mơ hà nội 1898','L001',43,0.5,14.5,'NSX03',130000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH002',N'Vodka Hà Nội S120','L003',23,1.75,40,'NSX04',135000,105000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH003',N'Vodka Hà Nội  major','L003',40,0.5,35,'NSX06',75000,65000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH004',N'Rượu chanh','L001',17,0.5,25,'NSX04',60000,50000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH005',N'Vina vodka','L003',32,0.5,33,'NSX05',100000,90000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH006',N'Rượu táo mèo','L001',45,0.5,30,'NSX05',85000,75000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH007',N'Rượu thanh mai','L001',43,0.5,25,'NSX01',75000,65000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH008',N'Rượu nếp cẩm','L001',22,0.5,29.5,'NSX02',65000,50000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH009',N'Lúa mới','L002',20,0.5,45,'NSX04',130000,110000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH010',N'Lúa mới','L001',43,0.7,40,'NSX05',130000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH011',N'Rượu nếp mới','L001',43,0.5,30,'NSX04',60000,50000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH012',N'Rượu nếp mới','L002',43,0.5,40,'NSX02',111000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH013',N'Rượu nếp mới','L002',43,0.5,50,'NSX01',130000,110000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH014',N'Vodka 94 Lò Đúc','L003',11,0.5,35,'NSX03',135000,101000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH015',N'Ba kích Sealion','L002',15,0.5,33,'NSX05',110000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH016',N'Vodka 94 Lò Đúc','L004',39,0.5,25,'NSX02',120000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH017',N'Rượu Vang 20 Barrels ','L005',20,0.75,14.5,'NSX06',140000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH018',N'Rượu vang J.Lohr ','L005',43,0.75,13.5,'NSX01',110000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH019',N'Rượu vang Valenciso ','L005',12,0.75,14,'NSX02',160000,140000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH020',N'Rượu Vang Domaine ','L006',11,0.75,14,'NSX03',160000,140000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH021',N'Rượu vang Freixenet','L006',43,0.5,11,'NSX06',140000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH022',N'Rượu Vang Desiderio ','L006',43,0.5,13,'NSX01',160000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH023',N'Rượu Vang Albert','L007',12,0.75,14.5,'NSX06',180000,160000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH024',N'Rượu Vang Tribaut ','L007',11,0.75,14.5,'NSX05',110000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH025',N'Rượu Vang Freixenet ','L008',10,0.75,14.5,'NSX03',115000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH026',N'Rượu vang Valdo','L008',43,0.75,14.5,'NSX03',112000,100000)
insert [dbo].[Hang_Hoa] ([MaHang],[TenHang],[MaLoai],[SoLuong],[DungTich],[DoRuou],[MaNuocSX],[DonGiaBan],[DonGiaNhap]) values (N'HH027',N'Rượu Vang Bel Star ','L008',43,0.5,14.5,'NSX04',160000,100000)
go
--HDB
go
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD001','NV001','KH001','2021/11/21','manhhung123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD002','NV002','KH002','2021/11/20','chihieu123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD003','NV003','KH003','2021/11/19','thuytrang123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD004','NV004','KH004','2021/11/18','anhduc123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD005','NV001','KH005','2021/11/17','tuantran123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD006','NV002','KH001','2021/11/16','manhhung123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD007','NV003','KH002','2021/11/15','chihieu123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD008','NV004','KH003','2021/11/14','thuytrang123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD009','NV001','KH001','2021/11/13','manhhung123')
insert [dbo].[Hoa_Don_Ban] ([SoHDB],[MaNV],[MaKH],[NgayBan],[Username]) values (N'HD010','NV002','KH002','2021/11/12','chihieu123')
go
--Chi tiet HDB
go
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD001','HH001',10,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD001','HH002',20,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD002','HH027',15,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD003','HH026',1,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD004','HH021',3,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD005','HH011',11,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD006','HH015',12,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD007','HH016',10,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD008','HH017',33,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD009','HH018',111,50)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD010','HH019',120,20)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD002','HH013',12,15)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD003','HH012',18,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD004','HH009',10,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD005','HH008',10,10)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD006','HH005',30,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD007','HH003',32,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD008','HH002',10,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD009','HH001',31,0)
insert [dbo].[ChiTietHDB] ([SoHDB],[MaHang],[SoLuong],[GiamGia]) values (N'HD010','HH006',10,0)
go
--hoa don nhap
go
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN001','NV001','NCC01','2021/10/21')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN002','NV002','NCC02','2021/10/20')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN003','NV003','NCC03','2021/10/19')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN004','NV004','NCC04','2021/10/18')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN005','NV001','NCC05','2021/10/17')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN006','NV002','NCC01','2021/10/16')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN007','NV003','NCC02','2021/10/15')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN008','NV004','NCC03','2021/10/14')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN009','NV001','NCC04','2021/10/13')
insert [dbo].[Hoa_Don_Nhap] ([SoHDN],[MaNV],[MaNCC],[NgayNhap]) values (N'HDN010','NV002','NCC05','2021/10/12')
go
--chitiethdn
go
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN001','HH001',100,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN002','HH002',111,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN003','HH018',121,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN004','HH023',100,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN005','HH012',100,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN006','HH011',105,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN007','HH018',100,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN008','HH019',110,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN009','HH020',100,0)
insert [dbo].[ChiTietHDN] ([SoHDN],[MaHang],[SoLuong],[GiamGia]) values (N'HDN010','HH021',100,0)
go

SELECT*FROM Loai
SELECT*FROM Nha_Cung_Cap
SELECT*FROM Khach_Hang
SELECT*FROM Nhan_Vien
SELECT*FROM NuocSX
SELECT*FROM Hang_Hoa
SELECT*FROM Hoa_Don_Ban
SELECT*FROM Hoa_Don_Nhap
SELECT*FROM ChiTietHDB
SELECT*FROM ChiTietHDN
SELECT*FROM UserName
CREATE TABLE ##HDBExcel(
	mahang nvarchar(30),
	tenhang nvarchar(30),
	soluong int,
	thanhtien money
);


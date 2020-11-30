----------STORE PROCEDURE VERSION 1------------------
-----------
use HMS
go
--insert benhnhan proc
create PROC proc_BenhNhan_insert
	@hoten nvarchar(50),
	@ngaysinh datetime,
	@gt bit,
	@diachi nvarchar(MAX),
	@sdt nvarchar(20),
	@cmnd nvarchar(20),
	@email nvarchar(50)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'BN'
		select @max = COUNT(*) from BENHNHAN
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into BENHNHAN values (@id, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, 0)
		select @id
	END;
	go

--test command

--select * from BENHNHAN
--exec proc_BenhNhan_insert 'Trương Tam Phong', '2020-2-2', 0, 'Huế', '12345', 'cmnd 1', null
--exec proc_BenhNhan_insert '2020-2-200', 1, 'dia chi 2', '22222', 'proc test 200', 'cmnd 22', null 

--insert nhanvien proc
create PROC proc_NhanVien_insert
	@hoten nvarchar(50),
	@ngaysinh datetime,
	@gt bit,
	@diachi nvarchar(MAX),
	@sdt nvarchar(20),
	@cmnd nvarchar(20),
	@email nvarchar(50),
	@manhom nvarchar(128),
	@maphong nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'NV'
		select @max = COUNT(*) from NHANVIEN
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into NHANVIEN values (@id, 0, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, @maphong, @manhom)
		select @id
	END;
	go

----insert benh proc
create Proc proc_Benh_insert
	@tenbenh nvarchar(50)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'BE'
		select @max = COUNT(*) from BENH
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into BENH values (@id, 0, @tenbenh)
		select @id
	END;
	go
--select * from BENH
--exec proc_Benh_insert 'HIV'

----insert cachdung proc
create Proc proc_CachDung_insert
	@tencachdung nvarchar(50)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'CD'
		select @max = COUNT(*) from CACHDUNG
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into CACHDUNG values (@id, 0, @tencachdung)
		select @id
	END;
	go
--select * from CACHDUNG
--exec proc_CachDung_insert 'Ngay 3 lan'


----insert Thuoc proc
create Proc proc_Thuoc_insert
	@donvi nvarchar(50),
	@tenthuoc nvarchar(50),
	@congdung nvarchar(max),
	@dongia float,
	@soluong int
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'TH'
		select @max = COUNT(*) from THUOC
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into THUOC values (@id, 0, @donvi, @tenthuoc, @congdung, @dongia, @soluong)
		select @id
	END;
	go
--select * from THUOC
--exec proc_Thuoc_insert 'Chai', 'Trĩ', 'Chữa trĩ', 200000, 100 


----insert PKDK proc
create Proc proc_PKDK_insert
	@ngaykham datetime,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128),
	@mabacsi nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKDK'
		select @max = COUNT(*) from PKDAKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKDAKHOA values (@id, 0, @ngaykham, null, null, @mabenhnhan, null, @manhanvien, @mabacsi)
		select @id
	END;
	go
--select * from PKDAKHOA
--exec proc_PKDK_insert '2020-2-2', 'BN00001', 'BE00001', 'NV00001'

--insert PKCK proc
create Proc proc_PKCK_insert
	@ngaykham datetime,
	@yeucau nvarchar(max),
	@manhanvien nvarchar(128),
	@mabenhnhan nvarchar(128),
	@mabacsi nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKCK'
		select @max = COUNT(*) from PKCHUYENKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKCHUYENKHOA values (@id, 0, @ngaykham, @yeucau, '', @manhanvien, @mabenhnhan, @mabacsi)
		select @id
	END;
	go
--select * from PKCHUYENKHOA
--exec proc_PKCK_insert '2020-2-2', 'Noi soi tim', 'NV00001'

--insert Phong proc
create Proc proc_Phong_insert
	@tenphong nvarchar(max)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'PH'
		select @max = COUNT(*) from PHONG
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PHONG values (@id, 0, @tenphong)
		select @id
	END;
	go
--select * from PHONG
--exec proc_Phong_insert 'Phong noi soi'

--insert PhieuNhapThuoc proc
create Proc proc_PNhapThuoc_insert
	@ngaynhap datetime,
	@maduocsi nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(3) = 'PNT'
		select @max = COUNT(*) from PHIEUNHAPTHUOC
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PHIEUNHAPTHUOC values (@id, 0, @ngaynhap, 0, @maduocsi)
		select @id
	END;
	go
--select * from PHIEUNHAPTHUOC
--exec proc_PNhapThuoc_insert '2020-3-2'

--insert HoaDon proc
create Proc proc_HoaDon_insert
	@chitiet nvarchar(max),
	@thanhtien float,
	@ngaylap datetime,
	@loaihoadon int,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'HD'
		select @max = COUNT(*) from HOADON
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		if @loaihoadon = 1
			set @thanhtien = 0
		insert into HOADON values (@id, 0, @chitiet, @thanhtien, @ngaylap, @loaihoadon, @mabenhnhan, @manhanvien)
		select @id
	END;
	go
--select * from HOADON
--exec proc_HoaDon_insert 'Tien thuoc', '3000000', '2020-2-2', 1, 'BN00001', 'NV00001'



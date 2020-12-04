use HMS
go
------------TRIGER VERSION 1-----------------
create trigger Tr_CTPhieuNhapThuoc_insert on CT_PHIEUNHAPTHUOC
for insert
as
begin
	declare @id nvarchar(128), @tien float, @soLuong int, @dongia float, @mathuoc nvarchar(128)
	select @id = MaPNT, @tien = ThanhTien, @mathuoc = MaThuoc, @dongia = DonGiaNhap, @soLuong = SoLuongNhap from inserted
	update PHIEUNHAPTHUOC set TongTien = TongTien + @tien where MaPNT = @id
	update THUOC set DonGia = @dongia, SoLuong = SoLuong + @soLuong where MaThuoc = @mathuoc
end

--select * from PHIEUNHAPTHUOC
--select * from CT_PHIEUNHAPTHUOC
--insert into CT_PHIEUNHAPTHUOC values ('PNT00001', 'TH00002', 0, 1000, 10000, 10000000)

go
create trigger Tr_CTHoaDonThuoc_insert on CT_HOADONTHUOC
for insert
as
begin
	declare @id nvarchar(128), @tien float
	select @id = MaHoaDon, @tien = ThanhTien from inserted
	update HOADON set ThanhTien = ThanhTien + @tien where MaHoaDon = @id and LoaiHoaDon = 1
end
go
--select * from HOADON
--select * from CT_HOADONTHUOC
--select * from THUOC
--insert into CT_HOADONTHUOC values (0, 'TH00002', 'HD00003', 10, 1000, 10000)

----------------TRIGGER ALter V1 --------
alter trigger Tr_CTPhieuNhapThuoc_insert on CT_PHIEUNHAPTHUOC
for insert
as
begin
	declare @id nvarchar(128), @tien float, @soLuong int, @dongia float, @mathuoc nvarchar(128)
	select @id = MaPNT, @tien = ThanhTien, @mathuoc = MaThuoc, @dongia = DonGiaNhap, @soLuong = SoLuongNhap from inserted
	update PHIEUNHAPTHUOC set TongTien = TongTien + @tien where MaPNT = @id
	update THUOC set DonGia = @dongia, SoLuong = SoLuong + @soLuong where MaThuoc = @mathuoc
end
go
----------------Trigger v1.1--------------
create trigger Tr_CTBCDoanhThu_insert on CT_BCDOANHTHU
for insert
as
begin
	declare @ngay int, @thang int, @nam int, @doanhThu float, @soBN int, @tongDT float
	select @ngay = Ngay, @thang = Thang, @nam = Nam, @soBN = SoBenhNhan, @doanhThu = DoanhThu from inserted
	update BC_DOANHTHU set TongBenhNhan = TongBenhNhan + @soBN, TongDoanhThu = TongDoanhThu + @doanhThu where Thang = @thang and Nam = @nam
	select @tongDT = TongDoanhThu from BC_DOANHTHU where Thang = @thang and Nam = @nam
	update CT_BCDOANHTHU set TyLe = @doanhThu / @tongDT * 100 where Thang = @thang and Nam = @nam and Ngay = @ngay
end
go
create trigger Tr_CTBCDoanhThu_update on CT_BCDOANHTHU
for update
as
begin
	declare @ngay int, @thang int, @nam int, @doanhThu float, @soBN int, @tongDT float, @doanhThuDel float, @soBNDel int
	select @ngay = Ngay, @thang = Thang, @nam = Nam, @soBN = SoBenhNhan, @doanhThu = DoanhThu from inserted
	select @doanhThuDel = DoanhThu, @soBNDel = SoBenhNhan from deleted
	update BC_DOANHTHU set TongBenhNhan = TongBenhNhan + @soBN - @soBNDel, TongDoanhThu = TongDoanhThu + @doanhThu - @doanhThuDel 
		where Thang = @thang and Nam = @nam
	select @tongDT = TongDoanhThu from BC_DOANHTHU where Thang = @thang and Nam = @nam
	update CT_BCDOANHTHU set TyLe = @doanhThu / @tongDT * 100 where Thang = @thang and Nam = @nam
end
go
------------TRIGER VERSION 1-----------------
create trigger Tr_CTPhieuNhapThuoc_insert on CT_PHIEUNHAPTHUOC
for insert
as
begin
	declare @id nvarchar(128), @tien float
	select @id = MaPNT, @tien = ThanhTien from inserted
	update PHIEUNHAPTHUOC set TongTien = TongTien + @tien where MaPNT = @id
end

--select * from PHIEUNHAPTHUOC
--select * from CT_PHIEUNHAPTHUOC
--insert into CT_PHIEUNHAPTHUOC values ('PNT00001', 'TH00001', 0, 1000, 1000, 1000000)

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

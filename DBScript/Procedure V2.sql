use HMS
GO
ALTER PROC [dbo].[proc_BenhNhan_insert]
    @hoten nvarchar(50),
    @ngaysinh datetime,
    @gt bit,
    @diachi nvarchar(MAX),
    @sdt nvarchar(20),
    @cmnd nvarchar(20),
    @email nvarchar(50)
AS
BEGIN
    BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(2) = 'BN'
        select @max = COUNT(*) from BENHNHAN
        set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
        insert into BENHNHAN values (@id, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, 0)
        select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        select @code
        return ERROR_STATE()
    END CATCH;
END;
go
ALTER PROC [dbo].[proc_NhanVien_insert]
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
		BEGIN TRY
			declare @id nvarchar(128), @max int, @prefix varchar(2) = 'NV'
			select @max = COUNT(*) from NHANVIEN
			set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
			insert into NHANVIEN values (@id, 0, @hoten, @ngaysinh, @gt, @diachi, @sdt, @cmnd, @email, @maphong, @manhom)
			select @id
			return -9999
		END TRY
		BEGIN CATCH
			declare @code varchar(10)
			set @code = ERROR_NUMBER()
			select @code
			return ERROR_STATE()
		END CATCH;
	END;
	go
--select * from BENHNHAN
--exec proc_BenhNhan_insert N'32132', '2020-11-3', 0, N'1', '1', '1', '1'
-----------------V2.1-------------------------------------
ALTER Proc [dbo].[proc_PKDK_insert]
	@ngaykham datetime,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKDK'
		select @max = COUNT(*) from PKDAKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKDAKHOA values (@id, 0, @ngaykham, null, null, @mabenhnhan, null, @manhanvien, null)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
go
ALTER Proc [dbo].[proc_HoaDon_insert]
	@chitiet nvarchar(max),
	@thanhtien float,
	@ngaylap datetime,
	@loaihoadon int,
	@mabenhnhan nvarchar(128),
	@manhanvien nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(2) = 'HD'
		select @max = COUNT(*) from HOADON
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		if @loaihoadon = 2
			set @thanhtien = 0
		insert into HOADON values (@id, 0, @chitiet, @thanhtien, @ngaylap, @loaihoadon, @mabenhnhan, @manhanvien)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        --declare @code varchar(10)
        --set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
go
insert into THAMSO values (N'Số bệnh nhân tối đa 1 ngày', 100)
insert into THAMSO values (N'Tiền Chụp X-Quang', 200000)
insert into THAMSO values (N'Tiền khám', 100000)
insert into THAMSO values (N'Tiền xét nghiệm', 200000)
go


-------------------------------V2.2-----------------------------------
ALTER Proc [dbo].[proc_PKCK_insert]
	@ngaykham datetime,
	@yeucau nvarchar(max),
	@manhanvien nvarchar(128),
	@maphieukhamdakhoa nvarchar(128)
AS
BEGIN
	BEGIN TRY
        declare @id nvarchar(128), @max int, @prefix varchar(4) = 'PKCK'
		select @max = COUNT(*) from PKCHUYENKHOA
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PKCHUYENKHOA values (@id, 0, @ngaykham, @yeucau, '', @manhanvien, @maphieukhamdakhoa, null)
		select @id
        return -9999
    END TRY
    BEGIN CATCH
        declare @code varchar(10)
        set @code = ERROR_NUMBER()
        --select @code
		select ERROR_MESSAGE()
        return ERROR_STATE()
    END CATCH;
END;
go

---------------------------------------V2.3----------------
--insert Phong proc
create Proc proc_DonThuoc_insert
	@loidan nvarchar(max)
AS
	BEGIN
		declare @id nvarchar(128), @max int, @prefix varchar(2) = 'DT'
		select @max = COUNT(*) from DONTHUOC
		set @id = @prefix + RIGHT('00000'+CAST((@max + 1) AS VARCHAR(5)),5)
		insert into PHONG values (@id, 0, @loidan)
		select @id
	END;
	go
--select * from DONTHUOC
--exec proc_Phong_insert 'uong thuoc ngay 3 lan'
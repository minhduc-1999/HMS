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
use HMS
go
create PROCEDURE hms_GetErrorInfo  
AS  
SELECT  
	0 AS Code,
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_MESSAGE() AS ErrorMessage;
GO
alter PROC proc_BenhNhan_insert
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
		select 1 , @id
	END TRY
	BEGIN CATCH
		EXECUTE hms_GetErrorInfo
	END CATCH;
END;
go
select * from BENHNHAN
exec proc_BenhNhan_insert N'32132', '2020-11-3', 0, N'1', '1', '1', '1'
use HMS
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
--test command

--select * from BENHNHAN
--exec proc_BenhNhan_insert 'Trương Tam Phong', '2020-2-2', 0, 'Huế', '12345', 'cmnd 1', null
--exec proc_BenhNhan_insert '2020-2-200', 1, 'dia chi 2', '22222', 'proc test 200', 'cmnd 22', null 
----



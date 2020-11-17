create trigger Tr_BenhNhan_delete on BENHNHAN
instead of delete
as
begin
	declare @id varchar(45)
	select @id = MaBenhNhan from deleted
	update BENHNHAN set IsDeleted = 1 where MaBenhNhan = @id
end

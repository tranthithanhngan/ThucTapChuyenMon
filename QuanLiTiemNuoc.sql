create database QuanLiTiemNuoc
go
use QuanLiTiemNuoc
go

-- Món ăn Kèm
-- Bàn 
-- Nước
--Tên đăng nhập
-- Hóa đơn
-- thông tin hóa đơn

create table Ban
(
id int identity primary key,
ten nvarchar(100) not null default N'Chưa có tên',
hientrang nvarchar(100) not null default N'Trống'

)

create table Dangnhap
(
tendangnhap nvarchar(100) primary key,
tenhienthi nvarchar(100) not null default N'Admin',
password nvarchar(1000) not null default 0,
loaitaikhoan int not null default 0 
)

create table Nuoc
(
id int identity primary key,
ten nvarchar(100) not null default N'Chưa đặt tên'
)

create table Monankem
(
id int identity primary key,
ten nvarchar(100) not null default N'Chưa đăt tên',
idNuoc int not null, 
gia float not null default 0

foreign key (idNuoc) references dbo.Nuoc(id)
)

select n.ten, m.id, n.ten, m.gia
from Nuoc n, Monankem m
where n.id = m.idNuoc

select * from Monankem

create table Hoadon
(
id int identity primary key,
NgaycheckInt Date not null default getdate(),
Ngaycheckout Date,
idBan int not null,
thanhtoan int not null default 0
foreign key (idBan) references dbo.ban(id)
)

create table Infohoadon
(id int identity primary key,
idHoadon int not null,
idMonankem int not null,
soluong int not null default 0

foreign key (idHoadon) references dbo.Hoadon(id),
foreign key (idMonankem) references dbo.Monankem (id)
)

insert into dbo.Dangnhap
(
tendangnhap,
tenhienthi,
password,
loaitaikhoan
)
values ( N'Thu Ngân',
N'Ngân Huệ',
N'01',
0
)


insert into dbo.Dangnhap
(
tendangnhap,
tenhienthi,
password,
loaitaikhoan
)
values ( N'Quản Lí',
N'Ngọc Luân',
N'01',
0
)

create proc USP_GetAccountByUserName
@tendangnhap nvarchar(100)
as
begin
select * from dbo.Dangnhap where tendangnhap = @tendangnhap
end 

exec dbo.USP_GetAccountByUserName @tendangnhap = N'Quản Lí' 

create proc USP_Login
@tendangnhap nvarchar(100), @password nvarchar(100)
as
begin
	select * from dbo.Dangnhap where tendangnhap = @tendangnhap and password = @password
end
--Thêm bàn
declare @i int =0
while @i <=10
begin 
insert dbo.Ban (ten) values (N'Bàn '+ cast(@i as nvarchar(100)))
set @i =@i+1
end 
create proc USP_GetTableList
as
select * from dbo.Ban

update dbo.Ban set hientrang = N' Có người' where id = 9 
exec dbo.USP_GetTableList




--Thêm hóa đơn
insert dbo.Hoadon( NgaycheckInt,Ngaycheckout,idBan,thanhtoan) values (GETDATE(),null,1,0)
insert dbo.Hoadon( NgaycheckInt,Ngaycheckout,idBan,thanhtoan) values (GETDATE(),GETDATE(),2,1)
insert dbo.Hoadon( NgaycheckInt,Ngaycheckout,idBan,thanhtoan) values (GETDATE(),null,2,0)
select * from dbo.Hoadon where idBan = 2 and thanhtoan=1

-- thêm infohoadon
select f.ten, bi.soluong, f.gia, f.gia*bi.soluong  as thanhtien from dbo.Infohoadon as bi, dbo.Hoadon as b, dbo.Monankem as f
 where bi.idHoadon = b.id and bi.idMonankem = f.id and b.thanhtoan =0 and b.idBan=4


 alter proc USP_InsertBillInfo
 @idHoadon int, @idMonan int, @soluong int
 as
 begin
	declare @isExitsBillInfo int
	declare @soluognmonan int =1

	select @isExitsBillInfo = id , @soluognmonan = soluong from dbo.Infohoadon where idHoadon =@idHoadon and idMonankem = @idMonan
	if(@isExitsBillInfo >0)
	begin
	declare @newsoluong int = @soluognmonan + @soluong
	if(@newsoluong >0)
	update dbo.Infohoadon set soluong = @soluognmonan +@soluong where idMonankem = @idMonan
	else
	delete dbo.Infohoadon where idHoadon = @idHoadon and idMonankem = @idMonan
	end
else
begin
insert dbo.Infohoadon(idHoadon,idMonankem,soluong) 
values (@idHoadon,@idMonan,@soluong)
end
end
go

update dbo.Hoadon set thanhtoan=1 where id = 1
alter trigger UTG_UpdateBillInfo
ON dbo.Infohoadon for insert, update
as
begin
declare @idBill int

select @idBill = idHoadon from inserted
declare @idban int
select @idban = idBan from dbo.Hoadon where id = @idBill and thanhtoan =0

DECLARE @count INT
SELECT @count = COUNT(*) FROM dbo.Infohoadon WHERE idHoadon = @idBill
	
	IF (@count > 0)
	BEGIN
	
		PRINT @idBan
		PRINT @idBill
		PRINT @count
		
		UPDATE dbo.Ban SET hientrang = N'Có người' WHERE id = @idban		
		
	END		
	ELSE
	BEGIN
	PRINT @idBan
		PRINT @idBill
		PRINT @count
	UPDATE dbo.Ban SET hientrang = N'Trống' WHERE id = @idban	
	end
end

alter trigger UTG_UpdateBill
ON dbo.Hoadon for update
as
begin

declare @idBill int
select @idBill = id from inserted

declare @idban int
select @idban = idBan from dbo.Hoadon where id = @idBill

declare @soluong int = 0
select @soluong = count(*) from dbo.Hoadon where idBan =@idban and thanhtoan = 0
iF(@soluong =0)
update dbo.Ban set hientrang = N'Trống' where id =@idban
end

alter table dbo.Hoadon
ADD giamgia int

update dbo.Hoadon set giamgia = 0

create proc USP_InsertBill
@idBan int 
as
begin
	insert dbo.Hoadon
	(NgaycheckInt,
	Ngaycheckout,
	idBan,
	thanhtoan,
	giamgia)
	values (GETDATE(),
	null,
	@idBan,
	0,
	0)

end
go





alter proc USP_SwitchTable
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Hoadon WHERE idBan = @idTable2 AND thanhtoan = 0
	SELECT @idFirstBill = id FROM dbo.Hoadon WHERE idBan = @idTable1 AND thanhtoan = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill is NULL)
	BEGIN
		PRINT '0000001'
		insert dbo.Hoadon
	(NgaycheckInt,
	Ngaycheckout,
	idBan,
	thanhtoan
	)
	values (GETDATE(),
	null,
	@idTable1,
	0)
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Hoadon WHERE idBan = @idTable1 AND thanhtoan = 0
		
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.Infohoadon WHERE idHoadon = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill is NULL)
	BEGIN
		PRINT '0000002'
		insert dbo.Hoadon
	(NgaycheckInt,
	Ngaycheckout,
	idBan,
	thanhtoan
	)
	values (GETDATE(),
	null,
	@idTable2,
	0)
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Hoadon WHERE idBan = @idTable2 AND thanhtoan = 0
		update dbo.Ban set hientrang = N'Trống' where id =@idTable1
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.Infohoadon WHERE idHoadon = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.Infohoadon WHERE idHoadon = @idSeconrdBill
	
	UPDATE dbo.Infohoadon SET idHoadon = @idSeconrdBill WHERE idHoadon = @idFirstBill
	
	UPDATE dbo.Infohoadon SET idHoadon = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.Ban SET hientrang = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty = 0)
		UPDATE dbo.Ban SET hientrang = N'Trống' WHERE id = @idTable1
END
GO

exec dbo.USP_SwitchTable @idTable1 = 4 , @idTable2  = 9

alter trigger UTG_UpdateTable
ON dbo.Ban for update 
as
begin 
declare @idBan int
declare  @hientrang nvarchar(100)
select @idBan = id, @hientrang =inserted.hientrang from inserted

declare @idHoadon int

select @idHoadon = id from dbo.Hoadon where idBan = @idBan and thanhtoan = 0
declare @soluongBillInfo int
select @soluongBillInfo = COUNT(*) from dbo.Infohoadon where idHoadon =@idHoadon

if(@soluongBillInfo > 0 and @hientrang<> N'Có nguoi')
update dbo.Ban set hientrang = N' Có người' where id = @idBan
else if(@soluongBillInfo < 0 and @hientrang<> N'Trống')
update dbo.Ban set hientrang = N'Trống' where id = @idBan

end
go
update  dbo.Ban set hientrang = N'Trống'


delete dbo.Infohoadon
delete dbo.Hoadon

alter table dbo.Hoadon add tongtien float

alter proc USP_GetListBillByDate
@checkint date, @checkout date
as
begin
select b.ten as [Tên Bàn], NgaycheckInt as [Ngày vào], Ngaycheckout [Ngày ra], giamgia as [Giảm giá], h.tongtien as [Tổng tiền]
from dbo.Hoadon as h, dbo.Ban as b
 where NgaycheckInt >= @checkint and Ngaycheckout <= @checkout and h.thanhtoan = 1 and b.id = h.idBan 
  
 end

 create proc USP_UpdateAccount
 @tendangnhap nvarchar(100),
 @tenhienthi nvarchar(100),
 @password nvarchar(100),
 @newpassword nvarchar(100)
 as
 begin
 declare @isRightPass int =0 
 select @isRightPass = COUNT(*) from dbo.Dangnhap where tendangnhap = @tendangnhap and password =@password
 if(@isRightPass =1)
 begin
 if(@newpassword = null or @newpassword = '')
 begin
 update dbo.Dangnhap set tenhienthi = @tenhienthi where tendangnhap = @tendangnhap
 end
 else
 begin
 update dbo.Dangnhap set tenhienthi = @tenhienthi, password = @newpassword where tendangnhap = @tenhienthi
 end
 end
 end

 insert dbo.Monankem (ten,idNuoc, gia) values (N'', 0 , 0.0)
 update dbo.Monankem set ten = N'', idNuoc = 5 , gia =0 where id = 4

 create trigger UTG_DeleteBillInfo
 ON dbo.Infohoadon for delete
 as
 begin
 declare @idBillInfo int
 declare @idBill int
 select @idBillInfo = id, @idBill = deleted.idHoadon from deleted

 declare @idBan int
 select @idBan = idBan from dbo.Hoadon where id = @idBill

 declare @soluong int = 0

 select @soluong =  COUNT(*) from dbo.Infohoadon, dbo.Hoadon where Hoadon.id = Infohoadon.idHoadon and Hoadon.id = @idBill and thanhtoan = 0
 if(@soluong =0)
 update dbo.Ban set hientrang = N'Trống' where id =@idBan

 end

 select *from dbo.Monankem

 CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) 
 AS 
 BEGIN 
 IF @strInput IS NULL 
 RETURN @strInput IF @strInput = '' 
 RETURN @strInput 
 DECLARE @RT NVARCHAR(4000) 
 DECLARE @SIGN_CHARS NCHAR(136) 
 DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
 select * from dbo.Monankem where dbo.fuConvertToUnsign1(ten) LIKE N'%' + dbo.fuConvertToUnsign1(N'ca') +'%'

 select * from Dangnhap

alter PROC USP_GetListBillByDateAndPage

AS 
BEGIN
	select distinct Hoadon.id, ten, NgaycheckInt, Ngaycheckout, giamgia, Hoadon.tongtien from Hoadon, Ban  
END
exec USP_GetListBillByDateAndPage

select  distinct Hoadon.id, ten, NgaycheckInt, Ngaycheckout, giamgia, Hoadon.tongtien from Hoadon, Ban
create proc USP_Sum
as
begin
select sum(tongtien) from Hoadon
end
 
select distinct * from 
alter proc USP_InHoaDon(@idBan int)
as
begin
	select Ban.ten, Hoadon.NgaycheckInt, A.ten,A.soluong,A.gia, Hoadon.giamgia,A.thanhtien
	from Ban, Hoadon,(
						select Infohoadon.idHoadon, Monankem.ten, Infohoadon.soluong, Monankem.gia ,(Monankem.gia * Infohoadon.soluong) as thanhtien 
						from Monankem, Infohoadon
						where Monankem.id = Infohoadon.idMonankem
						group by Monankem.ten,Infohoadon.soluong, Monankem.gia,Infohoadon.idHoadon) as A
	where Ban.id = Hoadon.idBan
	and Hoadon.id = A.idHoadon
	and Ban.id = @idBan
	and Hoadon.thanhtoan = 0
end
exec USP_InHoaDon 4




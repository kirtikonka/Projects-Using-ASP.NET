create proc AddToPRoduct
@pname varchar(100),
@pcatagory varchar(100),
@price decimal(9,2),
@pimg varchar(100)
as
begin
	insert into Product_Table(pname,pcatagory,pimg,price) values(@pname,@pcatagory,@price,@pimg)
end
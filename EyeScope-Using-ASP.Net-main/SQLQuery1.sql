create database eyescope;

/*User Account*/
create table user_account
( 
	id int primary key identity,
	acc_user varchar(100),
	acc_pass varchar(100),
	acc_email varchar(100),
	acc_role varchar(100)
);

truncate table user_account;

select * from user_account;

/*User Account Procedure*/
alter proc NewUserAccountProc
@acc_user varchar(100),
@acc_pass varchar(100),
@acc_email varchar(100),
@acc_role varchar(100),
@acc_profile varchar(100)
As
Begin
	insert into user_account values(@acc_user,@acc_pass,@acc_email,@acc_role, @acc_profile);
end

/*Adding Admin*/
insert into user_account values('Admin','Admin@123','admin@gmail.com','Admin','Profiles/admin.png');

/*User Login Procedure*/
create proc UserLoginProc
@acc_email varchar(100),
@acc_pass varchar(100)
as
begin
	select * from user_account where acc_email=@acc_email and acc_pass=@acc_pass;
end

alter table user_account add acc_profile varchar(100);

/*Check if User Exist Procedure */
create proc UserExistProc
@acc_user varchar(100),
@acc_email varchar(100)
as
begin
	select * from user_account where acc_user=@acc_user or acc_email=@acc_email;
end

/*Fetching Profile to delete by user Procedure*/
create proc FindProfileByID
@acc_email varchar(100)
as
begin
	select * from user_account where acc_email=@acc_email;
end

/*Deleting account Procedure*/
create proc DeleteAccountByID
@id int
as
begin
	delete from user_account where id=@id;
end

/*Change Profile Picture Procedure*/
create proc ChangeProfileProc
@acc_profile varchar(100),
@acc_email varchar(100)
as
begin
	update user_account set acc_profile=@acc_profile where acc_email=@acc_email;
end

/*User List For Admin*/
create proc UserListProc
as
begin
	select * from user_account where acc_role = 'User';
end

/*Product List Table*/
create table product
(
	pid int primary key identity,
	pname varchar(100),
	pcat varchar(100),
	price varchar(100),
	pic varchar(100)
);

alter table product add pdesc varchar(100);
alter table product drop column price;
alter table product add price decimal(9,2);

select * from product;

/*Adding Products*/
create proc AddProductProc
@pname varchar(100),
@pcat varchar(100),
@pic varchar(100),
@price decimal(9,2),
@pdesc varchar(100)
as
begin
	insert into product values(@pname, @pcat, @pic, @pdesc, @price);
end

/*Cart Table*/
create table cart
(
	pid int primary key identity,
	pname varchar(100),
	pcat varchar(100),
	price decimal(9,2),
	qty int,
	pic varchar(100),
	dt varchar(100),
	suser varchar(100)
);

select * from cart;

/*Add to Cart Procedure*/
alter proc AddToCartProc
@pname varchar(100),
@pcat varchar(100),
@price decimal(9,2),
@qty int,
@pic varchar(100),
@dt varchar(100),
@suser varchar(100),
@perprice decimal(9,2)
as
begin
	insert into cart values(@pname, @pcat, @price, @qty, @pic, @dt, @suser, @perprice);
end

/*Cart Finding products by id Procedure*/
create proc FindProductDetailsByID
@pid int
as
begin
	select * from product where pid=@pid;
end

/*Cart Details Procedure*/
create proc FindCartDetailsBySession
@suser varchar(100)
as
begin
	select * from cart where suser=@suser;
end

alter table cart add perprice decimal(9,2);

select * from cart;

/*Deleting Product from Cart Procedure*/
create proc DeleteCartProductProc
@pid int
as
begin
	delete from cart where pid =@pid;
end

create table placeorder
(
	pid int primary key identity,
	pname varchar(100),
	pcat varchar(100),
	price decimal(9,2),
	qty int,
	pic varchar(100),
	dt varchar(100),
	suser varchar(100),
	perprice decimal(9,2)
);
drop table placeorder;

/*copy table*/
select * into placeorder from cart;
select * from placeorder;

alter table placeorder add address varchar(100);
alter table placeorder add contact varchar(100);

alter table placeorder drop column contact;

alter table placeorder add pstatus varchar(100)
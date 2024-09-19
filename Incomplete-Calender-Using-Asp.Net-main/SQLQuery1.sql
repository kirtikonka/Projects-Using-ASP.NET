create table User_account
(
Id int primary key identity,
user_Fname varchar (100),
user_Lname varchar (100),
user_mobile bigint,
user_email varchar(100),
user_pass varchar (100),
user_role varchar (100)
)
alter table User_account add user_profile varchar(100);

/*Else section of code behind login*/
create proc New_User_accountproc
@user_Fname varchar (100),
@user_Lname varchar (100),
@user_mobile bigint,
@user_email varchar(100),
@user_pass varchar (100),
@user_role varchar (100),
@user_profile varchar(100)
as
begin
insert into User_account values (@user_Fname,@user_Lname,@user_mobile,@user_email,@user_pass,@user_role,@user_profile);
end

/*Login*/
create proc UserLoginproc
@user_email varchar(100),
@user_pass varchar (100)
as
begin
 select * from User_account where user_email=@user_email AND user_pass=@user_pass;
end

select * from User_account;
truncate table User_account;

insert into User_account values('Admin','Admin','1234567890','admin@gmail.com','Admin','Admin','profile' );
insert into User_account values('Kirti','Konka','1234567890','kirti@gmail.com','kirti@123','User','profile' );

/*Login cs*/
create proc UserExistproc
@user_Fname varchar (100),@user_email varchar(100)
as 
begin
select * from User_account where User_fname=@user_Fname OR user_email=@user_email;
end

create proc FindProfileId
@user_email varchar(100)
as
begin
select * from User_account where user_email=@user_email;
end

CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY,
    EventName VARCHAR(100),
    EventDate DATE NOT NULL,
    Description VARCHAR(500)
)

SELECT * FROM Events;

truncate table events
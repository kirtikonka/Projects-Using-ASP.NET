create table Leave
(
id int primary key identity,
sitem varchar(50),
pl int,
cl int,
sl int,
EmpId int,
fromdate varchar(50),
todate varchar(50),

reason varchar(1000)
);

alter table leave add Extra int;

select * from leave

create proc LeaveProc
@sitem varchar(50),
@pl int,
@cl int,
@sl int,
@EmpId int,
@fromdate varchar(50),
@todate varchar(50),
@reason varchar(1000),
@Remaining int
as
begin
	insert into Leave values(@sitem,@pl,@cl,@sl,@EmpId,@fromdate,@todate,@reason,@Remaining)
end

exec LeaveProc 'pl',12,8,4,1,'10','20','s',2;



create table Leaveclone
(
id int primary key identity,
sitem varchar(50),
pl int,
cl int,
sl int,
EmpId int,
fromdate varchar(50),
todate varchar(50),

reason varchar(1000)
);

drop table Leaveclone

select * into Leaveclone from Leave;

select * from Leaveclone

select * from leave
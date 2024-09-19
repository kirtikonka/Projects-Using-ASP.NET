create database TaskSystem

use TaskSystem

--users table
create table users
(
id int primary key identity,
fname varchar(50),
lname varchar(50),
email varchar(50),
password varchar(50),
profile varchar(50)
);

alter table users 
add batch varchar(50);

/*registeration*/
alter proc usersproc
@fname varchar(50),
@lname varchar(50),
@email varchar(50),
@password varchar(50),
@profile varchar(50),
@batch varchar(50)
as
begin
insert into users values(@fname,@lname,@email,@password,@profile,@batch)
end

/*user login page*/
create proc userloginproc
@email varchar(50),
@password varchar(50)
as
begin
select * from users where email=@email and password=@password
end

/*Adding admin*/
insert into users values('Admin','Admin','admin@gmail.com','admin','admin','')

select * from users

truncate table users

drop table Assigntask

--assign task
CREATE TABLE AssignTask (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    TaskName VARCHAR(100) NOT NULL,
    Attachment VARCHAR(255),
    Batch VARCHAR(50) NOT NULL,
    UserEmail VARCHAR(100) NOT NULL,
    CreatedDateTime DATETIME NOT NULL
);

alter table assigntask ALTER COLUMN CreatedDateTime as Assigneddate DATETIME;

--procedure assign task
CREATE PROCEDURE assigntaskproc
    @taskName VARCHAR(100),
    @attachment VARCHAR(255),
    @batch VARCHAR(50),
    @userEmail VARCHAR(100),
    @createdDateTime DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO AssignTask (TaskName,Attachment,Batch,UserEmail,CreatedDateTime)
    VALUES (@taskName,@attachment,@batch,@userEmail,@createdDateTime);
    SELECT SCOPE_IDENTITY() AS NewTaskID;
END

alter table 

--mytask
CREATE TABLE MyTask (
    TaskID INT PRIMARY KEY,
    TaskName VARCHAR(100) NOT NULL,
    AssignedDate DATETIME NOT NULL,
    Attachment VARCHAR(255),
    Solution VARCHAR(255),
    Status VARCHAR(20),
    UserEmail VARCHAR(100) NOT NULL,
    Batch VARCHAR(50) NOT NULL
);

select * from mytask

EXEC sp_help 'MyTask';


ALTER TABLE MyTask ADD UserID INT NOT NULL;
ALTER TABLE MyTask ADD CONSTRAINT FK_MyTask_Users FOREIGN KEY (UserID) REFERENCES Users(ID);
alter table mytask add finisheddate DATETIME NOT NULL
select * from mytask
ALTER TABLE MyTask ALTER COLUMN finisheddate DATETIME;

ALTER TABLE AssignTask ALTER COLUMN UserEmail VARCHAR(255) null;
ALTER TABLE AssignTask ALTER COLUMN taskname VARCHAR(255) null;
ALTER TABLE MyTask ALTER COLUMN UserEmail VARCHAR(255) null;

ALTER TABLE MyTask ALTER COLUMN batch VARCHAR(255) null;
ALTER TABLE MyTask ADD Score INT;

--mytask procedure
CREATE proc mytaskproc
    @UserEmail VARCHAR(100),
    @Batch VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        t.TaskID,
        t.TaskName,
        t.AssignedDate,
        t.Attachment,
        t.Solution,
        t.Status
    FROM 
        MyTask t
    WHERE 
        t.UserEmail = @UserEmail
        AND t.Batch = @Batch
    ORDER BY 
        t.AssignedDate DESC;
END

--Task Review
CREATE TABLE TaskReview (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT NOT NULL,
    UserID INT NOT NULL,
    UserName NVARCHAR(100) NOT NULL,
    SubmittedOn DATETIME NOT NULL,
    Attachment NVARCHAR(255),
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (TaskID) REFERENCES MyTask(TaskID),
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);

--taskreview procedure
CREATE PROCEDURE taskreviewproc
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        t.TaskID,
        u.fname,
        t.AssignedDate,
        t.Solution AS Attachment,
        t.Status
    FROM 
        MyTask t
    INNER JOIN 
        Users u ON t.UserID = u.ID
    WHERE 
        t.Status NOT IN ('Approved', 'Rejected')
    ORDER BY 
        t.AssignedDate DESC;
END

--Assign Score
CREATE TABLE AssignScore (
    ScoreID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT NOT NULL,
    UserID INT NOT NULL,
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    TaskName VARCHAR(100) NOT NULL,
    SubmittedOn DATETIME NOT NULL,
    Attachment VARCHAR(255),
    Status VARCHAR(20) NOT NULL,
    Score FLOAT,
    FOREIGN KEY (TaskID) REFERENCES MyTask(TaskID),
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);

--assignscore procedure
alter PROCEDURE assignscoreproc
    @UserID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ScoreID,
        TaskID,
        UserID,
        UserName,
        Email,
        TaskName,
        SubmittedOn,
        Attachment,
        Status,
        Score
    FROM 
        AssignScore
    WHERE 
        Score IS NULL
        AND (@UserID IS NULL OR UserID = @UserID)
    ORDER BY 
        SubmittedOn DESC;
END

--insertsassignscore procedure
CREATE PROCEDURE InsertAssignScore
    @TaskID INT,
    @Score INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM AssignScore WHERE TaskID = @TaskID)
    BEGIN
        INSERT INTO AssignScore (TaskID, Score)
        VALUES (@TaskID, @Score);
    END
    ELSE
    BEGIN
        UPDATE AssignScore
        SET Score = @Score
        WHERE TaskID = @TaskID;
    END
END;

-- Create table for approved tasks
CREATE TABLE ApprovedTasks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT,
    UserID INT,
    TaskName NVARCHAR(255),
    SubmittedOn DATETIME,
    Attachment VARBINARY(MAX),
    Status NVARCHAR(50)
);

-- Create table for rejected tasks
CREATE TABLE RejectedTasks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT,
    UserID INT,
    TaskName NVARCHAR(255),
    SubmittedOn DATETIME,
    Status NVARCHAR(50)
);

-- Create stored procedure for approved tasks
CREATE PROCEDURE approvedtaskproc
AS
BEGIN
    SELECT TaskID, UserID, TaskName, SubmittedOn, Attachment, Status
    FROM ApprovedTasks
    ORDER BY SubmittedOn DESC;
END;

-- Create stored procedure for rejected tasks
CREATE PROCEDURE rejectedtaskproc
AS
BEGIN
    SELECT TaskID, UserID, TaskName, SubmittedOn, Status
    FROM RejectedTasks
    ORDER BY SubmittedOn DESC;
END;

--retask
CREATE TABLE ReTask (
    ReTaskID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT NOT NULL,
    UserID INT NOT NULL,
    TaskName NVARCHAR(100) NOT NULL,
    Batch NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    RejectedOn DATETIME NOT NULL,
    FOREIGN KEY (TaskID) REFERENCES MyTask(TaskID),
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);

--retask procedure
CREATE PROCEDURE retaskproc
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        m.TaskID,
        m.TaskName,
        u.fname,
        m.Batch,
        m.Status
    FROM 
        MyTask m
    INNER JOIN
        Users u ON m.UserID = u.ID
    WHERE 
        m.Status = 'Rejected'
    ORDER BY 
        m.AssignedDate DESC;
END

--retaskuser
CREATE TABLE ReTaskUser (ṁ.
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT,
    UserID INT,
    BatchID INT,
    TaskName NVARCHAR(255),
    OriginalSubmission DATETIME,
    RejectedOn DATETIME,
    ReSolution VARBINARY(MAX),
    ReSubmittedOn DATETIME,
    Status NVARCHAR(50)
);

--retaskuser procedure
CREATE PROCEDURE retaskuserproc
    @UserID INT,
    @BatchID INT
AS
BEGIN
    SELECT r.ID, r.TaskID, r.TaskName, r.OriginalSubmission, r.RejectedOn, r.Status
    FROM ReTaskUser r
    WHERE r.UserID = @UserID AND r.BatchID = @BatchID AND r.Status = 'Rejected'
    ORDER BY r.RejectedOn DESC;
END;

--history
CREATE TABLE History (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT,
    UserID INT,
    TaskName NVARCHAR(255),
    SubmittedOn DATETIME,
    ApprovedOn DATETIME,
    Score INT,
    Attachment VARBINARY(MAX),
    Status NVARCHAR(50)
);

--history procedure
CREATE PROCEDURE historyproc
    @UserID INT
AS
BEGIN
    SELECT 
        ID,
        TaskID,
        TaskName,
        SubmittedOn,
        ApprovedOn,
        Score,
        Status
    FROM History
    WHERE UserID = @UserID AND Status = 'Approved'
    ORDER BY ApprovedOn DESC;
END;



select * from users
select * from ApprovedTasks
select * from AssignScore
select * from AssignTask
select * from history
select * from mytask
select * from rejectedtasks
select * from retask
select * from retaskuser
select * from taskreview



truncate table ApprovedTasks
truncate table AssignScore
truncate table AssignTask
truncate table history
truncate table mytask
truncate table rejectedtasks
truncate table retask
truncate table retaskuser
truncate table taskreview

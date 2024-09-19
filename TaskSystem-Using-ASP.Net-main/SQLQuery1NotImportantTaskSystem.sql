/*Junction table between tasks and users*/
--CREATE TABLE TaskUser (
--    TaskID INT,
--    UserID INT,
--    CONSTRAINT PK_TaskUser PRIMARY KEY (TaskID, UserID),
--    CONSTRAINT FK_TaskUser_AssignTask FOREIGN KEY (TaskID) REFERENCES AssignTask(TaskID),
--    CONSTRAINT FK_TaskUser_Users FOREIGN KEY (UserID) REFERENCES users(id)
--);

--CREATE PROCEDURE sp_InsertAssignTask
--    @TaskName NVARCHAR(100),
--    @AttachmentPath NVARCHAR(255),
--    @BatchID INT,
--    @UserIDs NVARCHAR(MAX)
--AS
--BEGIN
--    SET NOCOUNT ON;
--    DECLARE @TaskID INT;
--    -- Insert the task
--    INSERT INTO AssignTask (TaskName, AttachmentPath, BatchID)
--    VALUES (@TaskName, @AttachmentPath, @BatchID);
--    -- Get the inserted TaskID
--    SET @TaskID = SCOPE_IDENTITY();
--    -- Insert task-user relationships
--    INSERT INTO TaskUser (TaskID, UserID)
--    SELECT @TaskID, value
--    FROM STRING_SPLIT(@UserIDs, ',');
--    -- Return the inserted task details along with assigned users
--    SELECT 
--        t.TaskID, 
--        t.TaskName, 
--        t.AttachmentPath, 
--        t.BatchID, 
--        t.CreatedDate,
--        u.id AS UserID,
--        u.fname AS FirstName
--    FROM AssignTask t
--    JOIN TaskUser tu ON t.TaskID = tu.TaskID
--    JOIN users u ON tu.UserID = u.id
--    WHERE t.TaskID = @TaskID;
--END





-- Create TaskReview table
CREATE TABLE TaskSubmissions (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    SubmittedOn DATETIME DEFAULT GETDATE(),
    AttachmentPath NVARCHAR(255),
    AttachmentFileName NVARCHAR(100),
    Status NVARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (UserID) REFERENCES Users(ID)
)

-- Stored Procedure to insert a task submission
CREATE PROCEDURE sp_InsertTaskSubmission
    @UserID INT,
    @AttachmentPath NVARCHAR(255),
    @AttachmentFileName NVARCHAR(100)
AS
BEGIN
    INSERT INTO TaskSubmissions (UserID, AttachmentPath, AttachmentFileName)
    VALUES (@UserID, @AttachmentPath, @AttachmentFileName)
END

-- Stored Procedure to get task submissions
CREATE PROCEDURE sp_GetTaskSubmissions
AS
BEGIN
    SELECT 
        ts.ID,
        u.fname + ' ' + u.lname AS Name,
        ts.SubmittedOn,
        ts.AttachmentPath,
        ts.AttachmentFileName,
        CASE 
            WHEN DATEDIFF(HOUR, ts.SubmittedOn, GETDATE()) <= 48 THEN 'On Time'
            ELSE 'Late'
        END AS Status
    FROM TaskSubmissions ts
    INNER JOIN Users u ON ts.UserID = u.ID
    ORDER BY ts.SubmittedOn DESC
END

-- Stored Procedure to update task status
CREATE PROCEDURE sp_UpdateTaskStatus
    @TaskID INT,
    @Status NVARCHAR(20)
AS
BEGIN
    UPDATE TaskSubmissions
    SET Status = @Status
    WHERE ID = @TaskID
END

-- Stored Procedure to get task details for scoring - assign score
CREATE PROCEDURE sp_GetTaskDetails
    @TaskID INT
AS
BEGIN
    SELECT 
        ts.ID,
        u.fname + ' ' + u.lname AS Name,
        u.email AS Email,
        ts.SubmittedOn,
        CASE 
            WHEN DATEDIFF(HOUR, ts.SubmittedOn, GETDATE()) <= 48 THEN 'On Time'
            ELSE 'Late'
        END AS Status
    FROM TaskSubmissions ts
    INNER JOIN Users u ON ts.UserID = u.ID
    WHERE ts.ID = @TaskID
END

-- Stored Procedure to update task score
CREATE PROCEDURE sp_UpdateTaskScore
    @TaskID INT,
    @Score INT
AS
BEGIN
    UPDATE TaskSubmissions
    SET Score = @Score
    WHERE ID = @TaskID
END

ALTER TABLE TaskSubmissions
ADD Score INT NULL

-- re task - admin
CREATE TABLE RejectedTasks (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OriginalTaskID INT,
    UserID INT,
    RejectedOn DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (OriginalTaskID) REFERENCES TaskSubmissions(ID),
    FOREIGN KEY (UserID) REFERENCES Users(ID)
)

-- Stored Procedure to get rejected users
CREATE PROCEDURE sp_GetRejectedUsers
AS
BEGIN
    SELECT DISTINCT
        u.ID,
        u.fname + ' ' + u.lname AS Name
    FROM RejectedTasks r
    INNER JOIN Users u ON r.UserID = u.ID
    WHERE r.Status = 'Pending'
    ORDER BY u.fname, u.lname
END

-- Stored Procedure to assign a new task
CREATE PROCEDURE sp_AssignNewTask
    @TaskName NVARCHAR(100),
    @UserID INT,
    @AttachmentPath NVARCHAR(255),
    @AttachmentFileName NVARCHAR(100)
AS
BEGIN
    INSERT INTO TaskSubmissions (UserID, TaskName, AttachmentPath, AttachmentFileName, Status)
    VALUES (@UserID, @TaskName, @AttachmentPath, @AttachmentFileName, 'Pending')

    -- Update the status of all rejected tasks for this user
    UPDATE RejectedTasks
    SET Status = 'Reassigned'
    WHERE UserID = @UserID AND Status = 'Pending'
END

/*Mytask*/
ALTER TABLE TaskSubmissions
ADD AssignedDate DATETIME DEFAULT GETDATE(),
    SolutionPath NVARCHAR(255),
    SolutionFileName NVARCHAR(100),
    SubmittedOn DATETIME,
    IsOnTime BIT;

-- Stored Procedure to get tasks for a specific user
CREATE PROCEDURE sp_GetMyTasks
    @UserID INT
AS
BEGIN
    SELECT 
        ID,
        TaskName,
        AssignedDate,
        AttachmentPath,
        AttachmentFileName,
        Status,
        IsOnTime
    FROM TaskSubmissions
    WHERE UserID = @UserID AND Status != 'Submitted'
    ORDER BY AssignedDate DESC
END

-- Stored Procedure to mark a task as on time
CREATE PROCEDURE sp_MarkTaskOnTime
    @TaskID INT
AS
BEGIN
    UPDATE TaskSubmissions
    SET IsOnTime = 1
    WHERE ID = @TaskID
END

-- Stored Procedure to submit a task
CREATE PROCEDURE sp_SubmitTask
    @TaskID INT,
    @SolutionPath NVARCHAR(255),
    @SolutionFileName NVARCHAR(100)
AS
BEGIN
    UPDATE TaskSubmissions
    SET 
        SolutionPath = @SolutionPath,
        SolutionFileName = @SolutionFileName,
        SubmittedOn = GETDATE(),
        Status = 'Submitted',
        IsOnTime = CASE 
                      WHEN DATEDIFF(HOUR, AssignedDate, GETDATE()) <= 48 THEN 1
                      ELSE 0
                   END
    WHERE ID = @TaskID
END

CREATE PROCEDURE sp_GetSubmittedTasks
AS
BEGIN
    SELECT 
        ts.ID,
        u.fname + ' ' + u.lname AS UserName,
        ts.TaskName,
        ts.AssignedDate,
        ts.SubmittedOn,
        ts.IsOnTime,
        ts.SolutionFileName
    FROM TaskSubmissions ts
    INNER JOIN Users u ON ts.UserID = u.ID
    WHERE ts.Status = 'Submitted'
    ORDER BY ts.SubmittedOn DESC
END

-- retaskuser
-- Stored Procedure to get rejected tasks for a user
CREATE PROCEDURE GetRejectedTasksForUser
    @UserID INT
AS
BEGIN
    SELECT 
        t.TaskID,
        t.TaskName,
        t.Status,
        t.RejectReason
    FROM 
        Tasks t
    WHERE 
        t.UserID = @UserID
        AND t.Status = 'Rejected'
END
GO

-- Stored Procedure to update task resolution
CREATE PROCEDURE UpdateTaskResolution
    @TaskID INT,
    @ResolutionPath NVARCHAR(MAX)
AS
BEGIN
    UPDATE Tasks
    SET 
        ResolutionPath = @ResolutionPath,
        Status = 'Pending'
    WHERE 
        TaskID = @TaskID
END
GO

--history
--task table - already above
CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    TaskName NVARCHAR(255),
    Status NVARCHAR(50),
    AssignedDate DATETIME,
    FinishedDate DATETIME,
    Score INT,
    -- other existing columns...
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

CREATE PROCEDURE GetUserTaskHistory
    @UserID INT,
    @Timeframe NVARCHAR(10)
AS
BEGIN
    DECLARE @StartDate DATETIME
    
    SET @StartDate = 
        CASE @Timeframe
            WHEN 'daily' THEN DATEADD(DAY, -1, GETDATE())
            WHEN 'weekly' THEN DATEADD(WEEK, -1, GETDATE())
            WHEN 'monthly' THEN DATEADD(MONTH, -1, GETDATE())
            WHEN 'yearly' THEN DATEADD(YEAR, -1, GETDATE())
            ELSE GETDATE()
        END

    SELECT 
        TaskID,
        TaskName,
        Status,
        AssignedDate,
        FinishedDate,
        Score
    FROM 
        Tasks
    WHERE 
        UserID = @UserID
        AND Status = 'Accepted'
        AND FinishedDate >= @StartDate
    ORDER BY 
        FinishedDate DESC
END
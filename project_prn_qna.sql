USE [master]
GO
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Project_QNA')
BEGIN
	ALTER DATABASE Project_QNA SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE Project_QNA SET ONLINE;
	DROP DATABASE Project_QNA;
END

GO

CREATE DATABASE Project_QNA

GO
USE Project_QNA
GO


CREATE TABLE Roles (
  Id INT PRIMARY KEY,
  NameRole NVARCHAR(40) NOT NULL 
);

CREATE TABLE Accounts (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  Username NVARCHAR(30) UNIQUE,
  Password NVARCHAR(30) NOT NULL,  
  RoleId INT DEFAULT NULL REFERENCES Roles(Id)
);

CREATE TABLE Classroomes (
  Id INT PRIMARY KEY,
  ClassName NVARCHAR(30) NOT NULL
);

CREATE TABLE Mojors(
	Id int IDENTITY(1,1) primary key,
	Name Nvarchar(30)
);

CREATE TABLE Students(
  Id INT primary key,
  [Name] NVARCHAR(30),
  Dob Date ,
  Email Nvarchar(40),
  Phone Nvarchar(15),
  Adress Nvarchar(100),
  Gender bit,
  MojorId INT REFERENCES Mojors(Id),
  IdAccount INT REFERENCES Accounts(Id)
);

CREATE TABLE Teachers(
  Id INT primary key,
  [Name] NVARCHAR(30),
  Dob Date ,
  NumberExp Int,
  Email Nvarchar(40),
  Phone Nvarchar(15),
  Adress Nvarchar(100),
  Gender bit,
  IdAccount INT REFERENCES Accounts(Id)
);

CREATE TABLE [Subjects](
  Id int primary key,
  [Name] nvarchar(40)
);

CREATE TABLE StudentClass (
  StudentId INT NOT NULL REFERENCES Students(Id),
  ClassId INT NOT NULL REFERENCES Classroomes(Id),
  TeacherId INT NOT NULL REFERENCES Teachers(Id),
  SubjectId INT NOT NULL  REFERENCES [Subjects](Id),
  PRIMARY KEY (StudentId, ClassId, TeacherId)
);

CREATE TABLE Frequency(
  Id int primary key,
  fre nvarchar(30)
);

CREATE TABLE FeedbacksCurent(
  Id int IDENTITY(1,1) primary key,
  StudentId INT NOT NULL REFERENCES Students(Id),
  TeacherId INT NOT NULL REFERENCES Teachers(Id),
  SubjectId INT NOT NULL  REFERENCES [Subjects](Id),
  ClassId INT NOT NULL REFERENCES Classroomes(Id),
  FreOnTime INT NOT NULL REFERENCES Frequency(Id),
  FreAns INT NOT NULL REFERENCES Frequency(Id),
  FreFullLession INT NOT NULL REFERENCES Frequency(Id),
  Comment Nvarchar(max)
);

CREATE TABLE Marks(
  StudentId INT NOT NULL REFERENCES Students(Id),
  ClassId INT NOT NULL REFERENCES Classroomes(Id),
  SubjectId INT NOT NULL  REFERENCES [Subjects](Id),
  Assignment1 float,
  Assignment2 float,
  ProgressTest1 float,
  ProgressTest2 float,
  GroupProject float, 
  PE float,
  FE float,
  FER float,
  PRIMARY KEY (StudentId, ClassId, SubjectId)
);

CREATE TABLE MessagesChat(
  Id int IDENTITY(1,1) primary key,
  StudentId INT NOT NULL REFERENCES Students(Id),
  TeacherId INT NOT NULL REFERENCES Teachers(Id),
  MessageContent NVARCHAR(500),
  Timestamp DATETIME DEFAULT GETDATE(),
  Sender Nvarchar(15),
  Isread bit
);

-- Chèn dữ liệu mẫu với thời gian cụ thể
INSERT INTO MessagesChat (StudentId, TeacherId, MessageContent, Timestamp, Sender)
VALUES (1, 1, N'Em chào thầy ạ', CAST('2024-07-11 14:30:00' AS DATETIME),'student'),
       (1, 1, N'Chào bạn, có thể giúp gì cho bạn không?', CAST('2024-07-11 15:00:00' AS DATETIME),'teacher'),
       (1, 1, N'Thầy có thể giải thích lại phần này được không?', CAST('2024-07-11 15:30:00' AS DATETIME),'student'),
       (1, 1, N'KHông :>!', CAST('2024-07-11 16:00:00' AS DATETIME),'teacher');

	   select * from MessagesChat

INSERT INTO Roles Values (1, 'Student'),(2, 'Teacher'),(3, 'Admin');

INSERT INTO Accounts (Username, Password, RoleId)
VALUES ('viet', '123', 1),  
       ('thao', '12345678', 1),
	   ('A', '12345678', 1), 
	   ('B', '12345678', 1), 
	   ('C', '12345678', 1), 
	   ('D', '12345678', 1), 
	   ('E', '12345678', 1), 
	   ('F', '12345678', 1), 
	   ('G', '12345678', 1), 
       ('tien', '123', 2),  
       ('tuan', '12345678', 2),
	   ('giaolang', '12345678', 2),
	   ('cau', '12345678', 2),
	   ('itachi', '12345678', 2),
	   ('admin', '12345678', 2);

INSERT INTO Classroomes VALUES (1, 'se1801'),(2, 'se1802'),(3, 'MKT1801');

Insert into Mojors values 
('Software engineering'),
('Multimedia communications'),
('Digital Marketing'),
('International bussiness');

INSERT INTO Students Values 
(1, 'Hoang Dang Quoc Viet', '2003-06-24','quocviet242003@gmail.com', '0915580369', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',0,1, 1),
(2, 'Dam Thi Phuong Thao', '2003-05-24','phuongthao2003@gmail.com', '0987654321', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',1,2, 2),
(3, 'Nguyen Tram Anh', '2003-01-12','hello1234@gmail.com', '0123456789', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',1,1, 3),
(4, 'Hoang Minh Duc', '2003-12-06','minhducll@gmail.com', '0099887766', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',0,1, 4),
(5, 'Nguyen Vu Quoc Khanh', '2003-11-11','quockhanh1120@gmail.com', '0918273645', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',0,4, 5),
(6, 'Nguyen Thi Hiep', '2003-11-11','hiepnguyen@gmail.com', '1234567890', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',1,3, 6),
(7, 'Ngo Duc Tai', '2003-11-11','ductai22@gmail.com', '5432167890', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',0,1, 7),
(8, 'Nghiem Thi Hong Ngoc', '2003-11-11','ngocnthhe12345@gmail.com', '8888888888', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',1,1, 8),
(9, 'Phung Tuan Anh', '2003-11-11','joker1111@gmail.com', '1111111111', 'Thôn 2, Kim Bông, Tân Xã, Thạch Thất, Hà Nội',0,4, 9);

select * from Teachers where Teachers.Id = 1;

INSERT INTO Teachers Values 
(1, 'Tien Dinh Ta', '1999-01-01', 10, 'tiendinhta@gmail.com', '0912547234', 'Tân Trường, Cẩm Giàng, Hải Dương', 0, 10),
(2, 'Vuong Minh Tuan', '1998-02-02', 10, 'vuongminhtuan@gmail.com', '0912547234', 'Tân Trường, Cẩm Giàng, Hải Dương', 0, 11),
(3, 'Giao Lang', '1995-03-03', 12, 'giaolang@gmail.com', '0912547234', 'Tân Trường, Cẩm Giàng, Hải Dương', 0, 12),
(4, 'Phan Dang Cau', '1975-04-04', 20, 'phandangcau@gmail.com', '0912547234', 'Tân Trường, Cẩm Giàng, Hải Dương', 0, 13),
(5, 'Uchiha Itachi', '2000-06-09', 15, 'uchihaitachi@gmail.com', '0912547234', 'Tân Trường, Cẩm Giàng, Hải Dương', 0, 14);


INSERT INTO [Subjects] VALUES 
(1, 'PRJ'),
(2, 'PRO'),
(3, 'LAB'),
(4, 'DBI'),
(5, 'PRF'),
(6, 'SWP'),
(7, 'PRN');


INSERT INTO StudentClass VALUES
(1, 1, 1, 1),
(2, 1, 1, 1),
(3, 1, 1, 1),
(4, 1, 1, 1),
(5, 1, 1, 1),
(6, 1, 1, 1),
(1, 1, 2, 2),
(2, 1, 2, 2),
(3, 1, 2, 2),
(4, 1, 2, 2),
(5, 1, 2, 2),
(6, 1, 2, 2),
(1, 2, 1, 7),
(2, 2, 1, 7),
(3, 2, 1, 7),
(4, 2, 1, 7),
(5, 2, 1, 7),
(6, 2, 1, 7),
(9, 3, 1, 1),
(8, 3, 1, 1),
(7, 3, 1, 1),
(6, 3, 1, 1),
(5, 3, 1, 1),
(4, 3, 1, 1);

Insert into Frequency Values 
(1, 'Always'),
(2, 'Sometimes'),
(3, 'Never');

SELECT 
  s.Name AS StudentName,
  c.ClassName,
  t.Name AS TeacherName,
  su.Name AS SubjectName
FROM StudentClass sc
INNER JOIN Students s ON sc.StudentId = s.Id
INNER JOIN Classroomes c ON sc.ClassId = c.Id
INNER JOIN Teachers t ON sc.TeacherId = t.Id
INNER JOIN Subjects su ON sc.SubjectId = su.Id;

INSERT INTO Marks(StudentId, ClassId, SubjectId) Values 
(1, 1, 1),
(2, 1, 1),
(3, 1, 1),
(4, 1, 1),
(5, 1, 1),
(6, 1, 1),
(1, 1, 2),
(2, 1, 2),
(3, 1, 2),
(4, 1, 2),
(5, 1, 2),
(6, 1, 2),
(1, 2, 7),
(2, 2, 7),
(3, 2, 7),
(4, 2, 7),
(5, 2, 7),
(6, 2, 7),
(9, 3, 1),
(8, 3, 1),
(7, 3, 1),
(6, 3, 1),
(5, 3, 1),
(4, 3, 1);
select * from Marks;
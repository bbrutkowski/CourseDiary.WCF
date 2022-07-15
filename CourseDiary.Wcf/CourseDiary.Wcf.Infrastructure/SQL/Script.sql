--1
CREATE DATABASE [CourseDiaryDB];
--2
CREATE TABLE [Users](
[Login] VARCHAR(255),
[Password] VARCHAR(255),
[Role] VARCHAR(255),
);
--3
CREATE TABLE [Trainers](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(255) NOT NULL,
	[Surname] VARCHAR(255) NOT NULL,
	[Email] VARCHAR(255) UNIQUE,
	[Password] VARCHAR(255) CHECK (LEN(Password)>=6),
	[DateOfBirth] DATE NOT NULL
);
--4
CREATE TABLE [Students] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(255) NOT NULL,
	[Surname] VARCHAR(255) NOT NULL,
	[Email] VARCHAR(255) UNIQUE,
	[Password] VARCHAR(255) CHECK (LEN(Password)>=6),
	[Date] DATE NOT NULL,
);
--5
CREATE TABLE [Courses](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(255) NOT NULL,
	[BeginDate] DATE NOT NULL,
	[TrainerId] INT FOREIGN KEY ([TrainerId]) REFERENCES [Trainers]([Id]),
	[PresenceTreshold] FLOAT(8) NOT NULL,
	[HomeworkTreshold] FLOAT(8) NOT NULL,
	[TestTreshold] FLOAT(8) NOT NULL,
	[State] VARCHAR(255),
);
--6
CREATE TABLE [CourseStudents](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[CourseId] INT FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
	[StudentId] INT FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id])
)
--7
CREATE TABLE [StudentPresence](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[LessonDate] DATE NOT NULL,
	[StudentId] INT FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id]),
	[CourseId] INT FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
	[Presence] VARCHAR(255) NOT NULL
);






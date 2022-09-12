

CREATE TABLE Person
(
	IDPerson int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Age int not null,
	Email nvarchar(30) not null,
	Picture varbinary(max) null
)
GO

CREATE PROC GetPeople
AS
SELECT * FROM Person
GO

CREATE PROC GetPerson
	@idPerson int
AS
SELECT * FROM Person WHERE IDPerson = @idPerson
GO

CREATE PROC DeletePerson
	@idPerson int
AS
DELETE FROM Person WHERE IDPerson = @idPerson
GO

CREATE PROC AddPerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson INT OUTPUT
AS 
BEGIN
INSERT INTO Person VALUES (@firstname, @lastname, @age, @email, @picture)
	SET @idPerson = SCOPE_IDENTITY()
END
GO

CREATE PROC UpdatePerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson int
AS
UPDATE Person SET 
		FirstName = @firstname,
		LastName = @lastname,
		Age = @age,
		Email = @email,
		Picture = @picture
	WHERE 
		IDPerson = @idPerson
GO

CREATE TABLE TVShow
(
	IDShow int primary key identity,
	[Name] nvarchar(50) not null,
	Rating int not null,
	PersonID int constraint FK_Course_Person foreign key references Person(IDPerson)
)
GO

CREATE PROC GetTVShows
AS
SELECT * FROM TVShow
GO

CREATE PROC GetTVShow
	@idtvshow int
AS
SELECT * FROM TVShow WHERE IDShow = @idtvshow
GO

CREATE PROC DeleteTVShow
	@idtvshow int
AS
DELETE FROM TVShow WHERE IDShow = @idtvshow
GO

CREATE PROC AddTVShow
	@name nvarchar(50),
	@rating int,
	@personid int,
	@idtvshow INT OUTPUT
AS 
BEGIN
INSERT INTO TVShow VALUES (@name, @rating, @personid)
	SET @idtvshow = SCOPE_IDENTITY()
END
GO

CREATE PROC UpdateTVShow
	@name nvarchar(50),
	@rating int,
	@personid int,
	@idtvshow int
AS
UPDATE TVShow SET 
		[Name] = @name,
		Rating = @rating,
		PersonID = @personid
	WHERE 
		IDShow = @idtvshow










insert into Person values('Ivan', 'Žuvi?', 18, 'iz@gmail.com', null)




CREATE DATABASE HomeWork2DB;
GO

USE HomeWork2DB;
GO


CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Age DATETIME NOT NULL,
    Natinolity NVARCHAR(100) NOT NULL
);


CREATE TABLE MemberUsers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Age DATETIME NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);


CREATE TABLE Publishers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Contry NVARCHAR(100) NOT NULL
);


CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    PublicationYear DATETIME NOT NULL,
    NumberPage SMALLINT NOT NULL,
    Category INT NOT NULL, 
    Publisher NVARCHAR(100) NOT NULL,
    Status INT NOT NULL,   
    IsActive BIT NOT NULL DEFAULT 1,
    WriterId INT NULL,     
    CONSTRAINT FK_Books_Authors FOREIGN KEY (WriterId) REFERENCES Authors(Id)
);


CREATE TABLE Loans (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,       
    BookId INT NOT NULL,       
    LoanDate DATETIME NOT NULL,
    DueDate DATETIME NOT NULL,
    ReturnDate DATETIME NULL,
    RentalPrice DECIMAL(18,2) NOT NULL,
    ReturnLate DECIMAL(18,2) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status INT NOT NULL,       
    CONSTRAINT FK_Loans_Users FOREIGN KEY (UserId) REFERENCES MemberUsers(Id),
    CONSTRAINT FK_Loans_Books FOREIGN KEY (BookId) REFERENCES Books(Id)
);
GO

-- 1. Insertar un Autor (Necesario para la tabla Books)
INSERT INTO Authors (Name, LastName, Age, Natinolity)
VALUES ('Gabriel', 'García Márquez', '1927-03-06', 'Colombiana');

-- 2. Insertar un Miembro (Necesario para la tabla Loans)
INSERT INTO MemberUsers (Name, LastName, Age, PhoneNumber, Email, Location, IsActive)
VALUES ('Juan', 'Pérez', '1995-10-15', '809-555-0123', 'juan.perez@email.com', 'Santo Domingo', 1);

-- 3. Insertar una Editorial
INSERT INTO Publishers (Name, Contry)
VALUES ('Editorial Sudamericana', 'Argentina');

-- 4. Insertar un Libro
-- Nota: Category 1 = Fiction, Status 1 = New, WriterId 1 = Gabriel García Márquez
INSERT INTO Books (Title, PublicationYear, NumberPage, Category, Publisher, Status, IsActive, WriterId)
VALUES ('Cien años de soledad', '1967-05-30', 471, 1, 'Editorial Sudamericana', 1, 1, 1);

-- 5. Insertar un Préstamo (Loan)
-- Nota: UserId 1, BookId 1, Status 1 = Pending
INSERT INTO Loans (UserId, BookId, LoanDate, DueDate, ReturnDate, RentalPrice, ReturnLate, TotalAmount, Status)
VALUES (1, 1, GETDATE(), DATEADD(day, 7, GETDATE()), NULL, 50.00, 0.00, 50.00, 1);
GO
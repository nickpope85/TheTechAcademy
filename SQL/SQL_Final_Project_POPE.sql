/* Switch to Master dB */
USE master
GO

/*----------------------------------------------------
            MOVE TO LIBRARY MANAGER DB
----------------------------------------------------*/


/* Run this ONLY if dbLibraryManager aleady exists */
IF EXISTS (SELECT * FROM sys.databases WHERE [name] = 'dbLibraryManager')
DROP DATABASE dbLibraryManager
GO

/* Create dbLibraryManager database */
CREATE DATABASE dbLibraryManager
GO

/* Use dbLibraryManager */
USE dbLibraryManager
GO

/*----------------------------------------------------
                    CREATE TABLES
----------------------------------------------------*/

/* Create BOOK table */
CREATE TABLE tbl_BOOK (
		book_ID int PRIMARY KEY,
		title varchar(200) NOT NULL,
		publisherName varchar(50) NOT NULL
);

/* Create BOOK_AUTHORS table */
CREATE TABLE tbl_BOOK_AUTHORS (
		book_ID int PRIMARY KEY,
		authorName varchar(50) NOT NULL
);

/* Create PUBLISHER table */
CREATE TABLE tbl_PUBLISHER (
		name varchar(50) PRIMARY KEY,
		[address] varchar(50),
		phone varchar(20)
);

/* Create BOOK_COPIES table */
CREATE TABLE tbl_BOOK_COPIES (
		book_ID int NOT NULL,
		branch_ID int NOT NULL,
		noOfCopies int NOT NULL
);

/* Create BOOK_LOANS table */
CREATE TABLE tbl_BOOK_LOANS (
		book_ID int NOT NULL,
		branch_ID int NOT NULL,
		cardNo int NOT NULL,
		dateOut date NOT NULL,
		dueDate date NOT NULL
);

/* Create LIBRARY_BRANCH table */
CREATE TABLE tbl_LIBRARY_BRANCH (
		branch_ID int PRIMARY KEY,
		branchName varchar(50) NOT NULL,
		[address] varchar(50)
);

/* Create BORROWER table */
CREATE TABLE tbl_BORROWER (
		cardNo int PRIMARY KEY,
		name varchar(50) NOT NULL,
		[address] varchar(80) NOT NULL,
		phone varchar(20) NULL
);

/*----------------------------------------------------
                POPULATE TABLE CONTENT
----------------------------------------------------*/

/* Populate BOOK table */
INSERT INTO tbl_BOOK (book_ID, title, publisherName)
	VALUES
		(1001,'The Lost Tribe','CreateSpace'),
		(1002,'Rita Hayworth and Shawshank Redemption','Viking Press'),
		(1003,'The Geen Mile','Signet Books'),
		(1004,'Catch-22','Simon and Schuster'),
		(1005,'The Hitchhiker'+ char(39) + 's Guide to the Galaxy','Pan Books'),
		(1006,'The Salmon of Doubt','Pocket Books'),
		(1007,'A Peace to End All Peace','Owl Books'),
		(1008,'Ready Player One','Random House'),
		(1009,'The Prince and the Pauper','James R. Osgood & Co.'),
		(1010,'A Connecticut Yankee in King Arthur' + char(39) + 's Court','Charles L. Webster & Co.'),
		(1011,'The Hunt for Red October','Naval Institute Press'),
		(1012,'Clear and Present Danger','Putnam'),
		(1013,'Red Storm Rising','Putnam'),
		(1014,'On the Road','Viking Press'),
		(1015,'All Quiet on the Western Front','"	Propyläen Verlag"'),
		(1016,'The Road','Alfred A. Knopf'),
		(1017,'No Country for Old Men','Alfred A. Knopf'),
		(1018,'The Call of the Wild','Macmillan'),
		(1019,'Into the Wild','Villard'),
		(1020,'Into Thin Air','Villard'),
		(1021,'Under the Banner of Heaven','Anchor')
;

/* Populate BOOK_AUTHORS table */
INSERT INTO tbl_BOOK_AUTHORS (book_ID, authorName)
	VALUES
		(1001,'Mark Lee'),
		(1002,'Stephen King'),
		(1003,'Stephen King'),
		(1004,'Joseph Heller'),
		(1005,'Douglas Adams'),
		(1006,'Douglas Adams'),
		(1007,'David Fromkin'),
		(1008,'Ernest Cline'),
		(1009,'Mark Twain'),
		(1010,'Mark Twain'),
		(1011,'Tom Clancy'),
		(1012,'Tom Clancy'),
		(1013,'Tom Clancy'),
		(1014,'Jack Kerouac'),
		(1015,'Erich Maria Remarque'),
		(1016,'Cormac McCarthy'),
		(1017,'Cormac McCarthy'),
		(1018,'Jack London'),
		(1019,'Jon Krakauer'),
		(1020,'Jon Krakauer'),
		(1021,'Jon Krakauer')
;

/* Populate PUBLISHER table */
INSERT INTO tbl_PUBLISHER (name, [address], phone)
	VALUES
		('CreateSpace',NULL,NULL),
		('Viking Press',NULL,NULL),
		('Signet Books',NULL,NULL),
		('Simon and Schuster',NULL,NULL),
		('Pan Books',NULL,NULL),
		('Pocket Books',NULL,NULL),
		('Owl Books',NULL,NULL),
		('Jove',NULL,NULL),
		('Random House',NULL,NULL),
		('James R. Osgood & Co.',NULL,NULL),
		('Charles L. Webster & Co.',NULL,NULL),
		('Naval Institute Press',NULL,NULL),
		('Putnam',NULL,NULL),
		('Propyläen Verlag',NULL,NULL),
		('Alfred A. Knopf',NULL,NULL),
		('Macmillan',NULL,NULL),
		('Villard',NULL,NULL),
		('Anchor',NULL,NULL)
;

/* Populate LIBRARY_BRANCH table */
INSERT INTO tbl_LIBRARY_BRANCH (branch_ID, branchName, [address])
	VALUES
		(1,'Central',NULL),
		(2,'Sharpstown',NULL),
		(3,'Mill Creek',NULL),
		(4,'Snohomish',NULL)

/* Populate BOOK_COPIES table */
INSERT INTO tbl_BOOK_COPIES (book_ID, branch_ID, noOfCopies)
	VALUES
		(1001, 1, 5),
        (1002, 1, 5),
        (1003, 1, 5),
        (1004, 1, 5),
        (1005, 1, 5),
        (1006, 1, 5),
        (1007, 1, 5),
        (1008, 1, 5),
        (1009, 1, 5),
        (1010, 1, 5),
        (1011, 1, 5),
        (1012, 1, 5),
        (1013, 1, 5),
        (1014, 1, 5),
        (1015, 1, 5),
        (1016, 1, 5),
        (1017, 1, 5),
        (1018, 1, 5),
        (1019, 1, 5),
        (1020, 1, 5),
        (1021, 1, 5),
        (1001, 2, 5),
        (1002, 2, 5),
        (1003, 2, 5),
        (1004, 2, 5),
        (1005, 2, 5),
        (1006, 2, 5),
        (1007, 2, 5),
        (1008, 2, 5),
        (1009, 2, 5),
        (1010, 2, 5),
        (1011, 2, 5),
        (1012, 2, 5),
        (1013, 2, 5),
        (1014, 2, 5),
        (1015, 2, 5),
        (1016, 2, 5),
        (1017, 2, 5),
        (1018, 2, 5),
        (1019, 2, 5),
        (1020, 2, 5),
        (1021, 2, 5),
        (1001, 3, 5),
        (1002, 3, 5),
        (1003, 3, 5),
        (1004, 3, 5),
        (1005, 3, 5),
        (1006, 3, 5),
        (1007, 3, 5),
        (1008, 3, 5),
        (1009, 3, 5),
        (1010, 3, 5),
        (1011, 3, 5),
        (1012, 3, 5),
        (1013, 3, 5),
        (1014, 3, 5),
        (1015, 3, 5),
        (1016, 3, 5),
        (1017, 3, 5),
        (1018, 3, 5),
        (1019, 3, 5),
        (1020, 3, 5),
        (1021, 3, 5),
        (1001, 4, 5),
        (1002, 4, 5),
        (1003, 4, 5),
        (1004, 4, 5),
        (1005, 4, 5),
        (1006, 4, 5),
        (1007, 4, 5),
        (1008, 4, 5),
        (1009, 4, 5),
        (1010, 4, 5),
        (1011, 4, 5),
        (1012, 4, 5),
        (1013, 4, 5),
        (1014, 4, 5),
        (1015, 4, 5),
        (1016, 4, 5),
        (1017, 4, 5),
        (1018, 4, 5),
        (1019, 4, 5),
        (1020, 4, 5),
        (1021, 4, 5)
;

/* Populate BORROWER table */
INSERT INTO tbl_BORROWER (cardNo, name, [address], phone)
	VALUES
		(101,'William Fitchner','1250 First Ave S',NULL),
		(102,'Allison Hannigan','520 Pike St',NULL),
		(103,'Idris Elba','11630 Roseberg Ave S',NULL),
		(104,'Olivia Wilde','13604 51st DR SE',NULL),
		(105,'Evan Rachel Wood','500 E Pine St',NULL),
		(106,'James Marsden','3701 S Peoria DR',NULL),
		(107,'Thandie Newton','403 Jackson St',NULL),
		(108,'Anthony Hopkins','1684 Cambridge Ave',NULL),
		(109,'Ed Harris','1400 Pennsylvania',NULL)
;



/* Populate BOOK_LOANS table */
INSERT INTO tbl_BOOK_LOANS (book_ID, branch_ID, cardNo, dateOut, dueDate)
	VALUES
		(1001,2,105,'2018-03-18','2018-04-02'),
		(1002,2,105,'2018-03-18','2018-04-02'),
		(1003,2,105,'2018-03-18','2018-04-02'),
		(1004,2,105,'2018-03-18','2018-04-02'),
		(1005,2,105,'2018-03-18','2018-04-02'),
		(1006,2,105,'2018-03-18','2018-04-02'),
		(1007,4,109,'2018-03-11','2018-03-25'),
		(1008,4,109,'2018-03-11','2018-03-25'),
		(1009,4,109,'2018-03-11','2018-03-25'),
		(1010,4,109,'2018-03-11','2018-03-25'),
		(1011,4,109,'2018-03-11','2018-03-25'),
		(1012,4,109,'2018-03-11','2018-03-25'),
		(1013,3,101,'2018-03-11','2018-03-25'),
		(1014,3,101,'2018-03-11','2018-03-25'),
		(1015,1,102,'2018-03-10','2018-03-24'),
		(1016,1,102,'2018-03-10','2018-03-24'),
		(1017,1,102,'2018-03-10','2018-03-24'),
		(1018,1,102,'2018-03-10','2018-03-24'),
		(1019,4,104,'2018-03-09','2018-03-23'),
		(1020,4,104,'2018-03-09','2018-03-23'),
		(1021,4,104,'2018-03-09','2018-03-23'),
		(1001,4,104,'2018-03-09','2018-03-23'),
		(1002,2,105,'2018-03-09','2018-03-23'),
		(1003,2,106,'2018-03-09','2018-03-23'),
		(1004,1,104,'2018-03-22','2018-04-06'),
		(1005,1,104,'2018-03-22','2018-04-06'),
		(1006,1,104,'2018-03-22','2018-04-06'),
		(1007,1,104,'2018-03-22','2018-04-06'),
		(1008,1,104,'2018-03-22','2018-04-06'),
		(1009,3,106,'2018-03-09','2018-03-23'),
		(1010,3,106,'2018-03-09','2018-03-23'),
		(1011,3,106,'2018-03-09','2018-03-23'),
		(1012,3,106,'2018-03-09','2018-03-23'),
		(1013,3,106,'2018-03-09','2018-03-23'),
		(1014,3,106,'2018-03-09','2018-03-23'),
		(1015,2,107,'2018-03-13','2018-03-27'),
		(1016,2,107,'2018-03-13','2018-03-27'),
		(1018,2,107,'2018-03-13','2018-03-27'),
		(1019,2,107,'2018-03-13','2018-03-27'),
		(1020,2,107,'2018-03-13','2018-03-27'),
		(1021,2,108,'2018-03-10','2018-03-24'),
		(1001,2,108,'2018-03-10','2018-03-24'),
		(1002,2,108,'2018-03-10','2018-03-24'),
		(1003,3,108,'2018-03-10','2018-03-24'),
		(1004,3,108,'2018-03-10','2018-03-24'),
		(1005,4,102,'2018-03-17','2018-04-01'),
		(1006,4,104,'2018-03-17','2018-04-01'),
		(1007,4,105,'2018-03-17','2018-04-01'),
		(1008,4,106,'2018-03-17','2018-04-01'),
		(1009,2,107,'2018-03-17','2018-04-30')
;
GO
		
/*----------------------------------------------------
                STORED PREOCEDURES
----------------------------------------------------*/

/* How many copies of the book titled "The Lost Tribe" are owned by the library branch whose name is "Sharpstown"? */
CREATE PROCEDURE uspGetLostTribeSharps
AS
	SELECT b.book_ID, b.title, lb.branch_ID, lb.branchName, bc.noOfCopies
		FROM tbl_BOOK_COPIES bc INNER JOIN tbl_LIBRARY_BRANCH lb ON bc.branch_ID = lb.branch_ID
		INNER JOIN tbl_BOOK b ON bc.book_ID = b.book_ID
		WHERE b.title = 'The Lost Tribe' AND lb.branchName = 'Sharpstown'
;
GO
		
/* How many copies of the book titled "The Lost Tribe" are owned by each library branch? */
CREATE PROCEDURE uspGetLostTribeCopies
AS
	SELECT b.book_ID, b.title, lb.branch_ID, lb.branchName, bc.noOfCopies
		FROM tbl_BOOK_COPIES bc INNER JOIN tbl_LIBRARY_BRANCH lb ON bc.branch_ID = lb.branch_ID
		INNER JOIN tbl_BOOK b ON bc.book_ID = b.book_ID
		WHERE b.title = 'The Lost Tribe'
;
GO

/* Retrieve the names of all borrowers who do not have any books checked out */
CREATE PROCEDURE uspGetNoBorrows	
AS	
	SELECT b.cardNo, b.name, b.[address]
		FROM tbl_BORROWER b LEFT JOIN tbl_BOOK_LOANS bl ON b.cardNo = bl.cardNo
		WHERE bl.cardNo IS NULL
;
GO

/*----------------------------------------------------
                ADDITIONAL QUERIES
----------------------------------------------------*/

/* For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, retrieve the book title, the borrower's name, and the borrower's address. */
DECLARE @today DATE = CONVERT(date,SYSDATETIME())
SELECT tbl_BOOK.title, b.name, b.[address]
	FROM tbl_LIBRARY_BRANCH lb INNER JOIN tbl_BOOK_LOANS bl ON lb.branch_ID = bl.branch_ID
	INNER JOIN tbl_BOOK ON bl.book_ID = tbl_BOOK.book_ID
	INNER JOIN tbl_BORROWER b ON bl.cardNo = b.cardNo
	WHERE lb.branchName = 'Sharpstown' AND bl.dueDate = @today
;


/* For each library branch, retrieve the branch name and the total number of books loaned out from that branch. */
SELECT lb.branchName, COUNT(*) AS BookCount
	FROM tbl_BOOK_LOANS bl INNER JOIN tbl_LIBRARY_BRANCH lb ON bl.branch_ID = lb.branch_ID
	GROUP BY lb.branchName
;


/* Retrieve the names, addresses, and number of books checked out for all borrowers who have more than five books checked out. */
SELECT b.name, b.[address], COUNT(b.name) AS BooksCheckedOut
	FROM tbl_BORROWER b INNER JOIN tbl_BOOK_LOANS bl ON b.cardNo = bl.cardno
	GROUP BY b.name, b.[address]
	HAVING COUNT(bl.cardNo) > 5
;


/* For each book authored (or co-authored) by "Stephen King", retrieve the title and the number of copies owned by the library branch whose name is "Central". */
SELECT tbl_book.title, lb.branchName, bc.noOfCopies
	FROM tbl_BOOK INNER JOIN tbl_BOOK_AUTHORS ba ON tbl_BOOK.book_ID = ba.book_ID
	INNER JOIN tbl_BOOK_COPIES bc ON bc.book_ID = ba.book_ID
	INNER JOIN tbl_LIBRARY_BRANCH lb ON bc.branch_ID = lb.branch_ID
    WHERE ba.authorName LIKE '%Stephen King%' AND lb.branchName = 'Central'
;
Create database CS486_Team12_DB
Go

USE CS486_Team12_DB
GO

CREATE TABLE Singers
(
	singerID INT PRIMARY KEY,
	name NVARCHAR(50),
	principles BIT CHECK(principles = 0 OR principles = 1) --0: reserved; 1: official
);

CREATE TABLE Songs
(
	songID INT PRIMARY KEY,
	songName NVARCHAR(100),
);

CREATE TABLE SingerPairSongsTrial
(	singer1ID int, --fk 
	singer2ID int, --fk
	songID int, --fk
	result BIT check(result  = 0 OR result = 1) --0: lose; 1: win
	primary key(singer1ID,singer2ID)
);

CREATE TABLE SingerPairSongsPreMain
(
	singer1ID int, --fk
	singer2ID int, --fk
	songID int, --fk
	result BIT check(result = 0 OR result = 1) --0: lose; 1: win
	primary key(singer1ID,singer2ID)
);
GO

ALTER TABLE SingerPairSongsTrial ADD
CONSTRAINT FK_SingerPairSongsTrial_singer1ID FOREIGN KEY(singer1ID) REFERENCES Singers(singerID);

ALTER TABLE SingerPairSongsTrial ADD
CONSTRAINT FK_SingerPairSongsTrial_singer2ID FOREIGN KEY(singer2ID) REFERENCES Singers(singerID);

ALTER TABLE SingerPairSongsTrial ADD
CONSTRAINT FK_SingerPairSongsTrial_songID FOREIGN KEY(songID) REFERENCES Songs(songID);

ALTER TABLE SingerPairSongsPreMain ADD
CONSTRAINT FK_SingerPairSongsPremain_singer1ID FOREIGN KEY(singer1ID) REFERENCES Singers(singerID);

ALTER TABLE SingerPairSongsPreMain ADD
CONSTRAINT FK_SingerPairSongsPremain_singer2ID FOREIGN KEY(singer2ID) REFERENCES Singers(singerID);

ALTER TABLE SingerPairSongsPreMain ADD
CONSTRAINT FK_SingerPairSongsPremain_songID FOREIGN KEY(songID) REFERENCES Songs(songID);
go

INSERT INTO Singers (singerID ,name,principles) VALUES
(1, 'Jia Fan',0),
(2, 'Tong Zhuo',0),
(3, 'Huang Zihongfan',0),
(4, 'Li Xiangzhe',0),
(5, 'Ayanga',0),
(6, 'Ding Hui',0),
(7, 'Fang Shujian',0),
(8, 'Liu Binhao',0),
(9, 'Cai Yao',0),
(10, 'Shi Kai',0),
(11, 'Zheng Yunlong',0),
(12, 'Jin Shengquan', 1),
(13, 'Nan Feng',0),
(14, 'Zhang Chao',0),
(15, 'Cai Chengyu',0),
(16, 'Li Wenbao',0),
(17, 'Dai Wei',0),
(18, 'Lu Yupeng',0),
(19, 'Chen Bohao',0),
(20, 'Gong Ziqi',0),
(21, 'Li Yanfeng',0),
(22, 'Zhai Lishuotian',0),
(23, 'Liang Pengjie',0),
(24, 'Gao Tianhe',0),
(25, 'Li Qi', 1),
(26, 'Jian Hongyi',0),
(27, 'Liao Jialin', 1),
(28, 'Xing Yuan',0),
(29, 'Gao Yang',0),
(30, 'Wang Kai', 0),
(31, 'Yu Di', 0),
(32, 'Wang Xi', 1),
(33, 'Gao Tianhe',0),
(34, 'Cai Chengyu', 1),
(35, 'Zheng Yunlong',0),
(36, ' Ayanga', 1);

insert into songs(songID, songName) VALUES
(1, 'I Dreamed a Dream'),
(2, 'A Poets Journey'),
(3, 'Perhaps & Wavering Moon'),
(4, 'Grande Amore'),
(5, 'That Man'),
(6, 'She is So Pretty'),
(7, 'Deer be Free'),
(8, 'Growing Fond of You'),
(9, 'Lost Stars'),
(10, 'Happy Heart'),
(11, 'Quest'),
(12, 'To the Horizon With You'),
(13, 'Libiamo Ne Lieti Calici'),
(14, 'Toreador Song'),
(15, 'My Homeland');
go

-- CREATE OR ALTER procedure sp_selectMoiNhat(@playlistid INT, @genre NVARCHAR(50))
-- AS
-- BEGIN
-- 	SELECT s.songName, sng.singerName, s.streamCount, s.dateAdded, sp.favorites
-- 	FROM playlists p JOIN SongsOfPlaylist sp ON p.playlistID = sp.playlistID
-- 	JOIN Songs s ON sp.songID = s.songID JOIN SingerSongs ss ON s.songID = ss.songID
-- 	JOIN Singers sng ON ss.singerID = sng.singerID
-- 	WHERE p.playlistID = @playlistid AND s.genre = @genre
-- END
-- GO

-- CREATE OR ALTER PROCEDURE sp_updatePlaylist(@playlistid INT, @songid INT, @favorites BIT)
-- AS
-- BEGIN TRY
-- 	BEGIN TRANSACTION
-- 		if not exists(
-- 			select *
-- 			from playlists
-- 			where playlistID = @playlistid
-- 		)
-- 		BEGIN
-- 			--RAISERROR('There is no such playlistid', 16, 1);
-- 			-- ROLLBACK;
-- 			THROW 50001,'There is no such playlistid', 1;
-- 		END

-- 		if not exists(
-- 			select *
-- 			from songs
-- 			where songID = @songid
-- 		)
-- 		BEGIN
-- 			--RAISERROR('There is no such songid', 16, 1);
-- 			-- ROLLBACK;
-- 			THROW 50002,'There is no such songid', 1;
-- 		END

-- 		if exists(
-- 			select *
-- 			from SongsOfPlaylist
-- 			where songID = @songid and playlistID = @playlistid
-- 		)
-- 		BEGIN
-- 			--RAISERROR('Song is already in playlist', 16, 1);
-- 			-- ROLLBACK;
-- 			THROW 50003,'Song is already in playlist', 1;
-- 		END

-- 		insert into SongsOfPlaylist(playlistID, songID, Favorites)
-- 		values (@playlistid, @songid, @favorites);
-- 	COMMIT TRANSACTION
-- 	RETURN 1;
-- END TRY
-- BEGIN CATCH
-- 	ROLLBACK;
-- 	THROW
-- END CATCH
-- GO

-- CREATE OR ALTER FUNCTION fn_count_songs()
-- RETURNS INT
-- AS
-- BEGIN 
-- 	DECLARE @count INT;
-- 	SET @count =
-- 	(SELECT COUNT(*) FROM Songs)
-- 	RETURN @count
-- END
-- GO

-- select dbo.fn_count_songs()

-- Select * from playlists

-- go

-- create or alter procedure sp_count_songs1(@result INT out)
-- AS
-- BEGIN
-- 	SET @result =
-- 	(SELECT COUNT(*) FROM Songs)
-- END
-- GO

-- declare @result INT
-- exec sp_count_songs1 @result out
-- print(@result)


-- -- select * from SongsOfPlaylist where playlistID = 1
-- -- exec sp_updatePlaylist 1, 3, 1

-- -- delete from SongsOfPlaylist where songid = 3

--select pricipal
CREATE OR ALTER procedure sp_selectprincipal
AS
BEGIN
    select * from Singers s
	where s.principles=1
END
GO

--exec sp_selectprincipal

--Randomly select 6 singers from the reserved team
create or alter procedure sp_selectRandomReserved
as
BEGIN
	SELECT TOP 6 * FROM Singers s
	WHERE s.principles=0
	order by NEWID()
END
GO

-- exec sp_selectRandomReserved

-- USE MASTER
-- DROP DATABASE CS486_Team12_DB


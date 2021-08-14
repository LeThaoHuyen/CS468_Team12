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

create or alter trigger tg_singerPairTrial
on SingerPairSongsTrial
for insert, update
as
begin
	if(update(singer1ID) OR update(singer2ID))
	BEGIN
		if(NOT EXISTS(SELECT * FROM INSERTED I INNER JOIN Singers S ON I.singer1ID=S.singerID WHERE S.principles=1)
		  OR (NOT EXISTS(SELECT * FROM INSERTED I INNER JOIN Singers S ON I.singer2ID=S.singerID WHERE S.principles=0))
		  OR (EXISTS(SELECT * FROM INSERTED I INNER JOIN SingerPairSongsTrial SPST ON I.singer1ID=SPST.singer1ID))
		  OR (EXISTS(SELECT * FROM INSERTED I INNER JOIN SingerPairSongsTrial SPST ON I.singer2ID=SPST.singer2ID))
		  )
		begin
			ROLLBACK;
			THROW 50001, 'Trial Round: Singer 1 must be a principal, singer 2 must be a reserve', 1
		end
	end	
END
go


create or alter trigger tg_singerPairPremain_onPair
on SingerPairSongsPreMain
for insert, update
AS
BEGIN
	if(UPDATE(singer1ID) or update(singer2ID))
	BEGIN	
		if(exists(
			select * from SingerPairSongsPreMain p join Singers s on (singer1ID=singerID)
			where principles=1))
		begin
			ROLLBACK;
			THROW 50002, 'PreMain Round: Singer 1 must be a reserved', 1
		end
		
		if(exists(
			select * from SingerPairSongsPreMain p join Singers s on (singer2ID=singerID)
			where principles=1))
		begin
			ROLLBACK;
			THROW 50003, 'PreMain Round: Singer 2 must be a reserved', 1
		end
	end
END

go
create or alter trigger tg_singerPairPremain_singers
on Singers
for insert, update
AS
BEGIN
	if(UPDATE(singerID))
	BEGIN	
		if(exists(
			select * from SingerPairSongsPreMain p join Singers s on (singer1ID=singerID)
			where principles=1))
		begin
			ROLLBACK;
			THROW 50004, 'PreMain Round: Singer 1 must be a reserve', 1
		end
		
		if(exists(
			select * from SingerPairSongsPreMain p join Singers s on (singer2ID=singerID)
			where principles=1))
		begin
			ROLLBACK;
			THROW 50005, 'PreMain Round: Singer 2 must be a reserve', 1
		end
	end
END
go



create or alter procedure sp_select3SongsRandomly
as
begin 
	SELECT TOP 3 * FROM Songs s
	order by NEWID()
end
go

create or alter procedure sp_inserttrial (@singer1Name nvarchar(50), @singer2Name nvarchar(50), @songName nvarchar(50), @result bit)
as
begin TRANSACTION
begin try
	if not exists(
			select *
			from Songs s
			where s.songName = @songName
	)
		BEGIN
			THROW 50006, 'There is no such song', 1
		END
	
	if not exists(
            select *
            from Singers sg
            where sg.name = @singer1Name
        )
        BEGIN
            THROW 50007,'There is no such singer 1', 1;
        END

	
	if not exists(
            select *
            from Singers sg
            where sg.name = @singer2Name
        )
        BEGIN
            THROW 50008,'There is no such singer 2', 1;
        END

	declare @singer1ID int
	set @singer1ID=(select singerID from Singers s where s.name=@singer1Name)

	declare @singer2ID int
	set @singer2ID=(select singerID from Singers s where s.name=@singer2Name)

	
	declare @songID INT
	set @songID = (select songID from Songs where songName = @songName)
	
	insert into SingerPairSongsTrial
        values (@singer1ID, @singer2ID,@songID, @result);
	commit transaction
end TRY
begin CATCH
	rollback transaction;
	throw
end catch
go


create or alter procedure sp_insertpremain (@singer1Name nvarchar(50), @singer2Name nvarchar(50), @songName nvarchar(50), @result bit)
as
begin TRANSACTION
begin try
	if (@songName <> 'Happy Heart' and  @songName <> 'Quest' and @songName <> 'To the Horizon With You')
		BEGIN
			THROW 50010, 'Invalid song for this round', 1
		END
	
	if not exists(
            select *
            from Singers sg
            where sg.name = @singer1Name
        )
        BEGIN
            THROW 50011,'There is no such singer 1', 1;
        END

	
	if not exists(
            select *
            from Singers sg
            where sg.name = @singer2Name
        )
        BEGIN
            THROW 50012,'There is no such singer 2', 1;
        END

	declare @singer1ID int
	set @singer1ID=(select singerID from Singers s where s.name=@singer1Name)

	declare @singer2ID int
	set @singer2ID=(select singerID from Singers s where s.name=@singer2Name)

	
	declare @songID INT
	set @songID = (select songID from Songs where songName = @songName)
	
	insert into SingerPairSongsPreMain
        values (@singer1ID, @singer2ID,@songID, @result);
	commit transaction
end TRY
begin CATCH
	rollback transaction;
	throw
end catch
go

--exec dbo.sp_inserttrial 'abc', 'xyz', 'That Man', 0

--exec dbo.sp_inserttrial 'Jin Shengquan', 'Zhai Lishuotian', 'That Man', 0
go

--//sau trial thì gán lại principles cho những căp thắng? 
create or alter PROCEDURE sp_updatePrinciplesAfterTrial
as
begin 
	update singers 
	set principles = 0;
	
	update Singers
	set principles = 1
	where singerID in
	(
		select singer1ID
		from SingerPairSongsTrial
		where result = 1
		union
		select singer2ID
		from SingerPairSongsTrial
		where result = 1
	)
end
go

exec sp_updatePrinciplesAfterTrial
select * from Singers
select * from Songs
select * from SingerPairSongsTrial
insert into SingerPairSongsTrial (singer1id, singer2ID, songID, result) values
(1, 2, 1, 1),
(3, 4, 1, 0);
go

create or alter procedure sp_viewMainResullt
as
BEGIN
	(SELECT SPST.singer1ID, SPST.singer2ID, S.songName
		FROM SingerPairSongsTrial SPST INNER JOIN Songs S ON SPST.songID=S.songID
		WHERE SPST.result=1)
	UNION
	(SELECT SPST.singer1ID, SPST.singer2ID, S.songName
		FROM SingerPairSongsPreMain SPST INNER JOIN Songs S ON SPST.songID=S.songID
		WHERE SPST.result=1);
end
go

create or alter procedure sp_viewMembersTwoGroups
as
BEGIN
	begin TRANSACTION
	SELECT S.name as PrincipleList FROM Singers S WHERE principles=1;
	
	SELECT S.name as ReservedList FROM Singers S WHERE principles=0;
	commit transaction
end
go


create or alter procedure sp_updateSingerPrinciples(@singerid int, @principles bit)
as
BEGIN TRY
	begin TRANSACTION
	if not exists
	(
		select * from Singers
		where singerID = @singerid
	)
	throw 60000, 'There is no such singerid', 1;

	update Singers
	set principles = @principles
	where singerID = @singerid
	
	commit transaction
end try
begin CATCH
	ROLLBACK;
	throw;
end catch
go
-- exec sp_updateSingerPrinciples 1, 0

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

-- EXEC sp_select3SongsRandomly
-- USE MASTER
-- DROP DATABASE CS486_Team12_DB
use RunTrack
go

begin transaction

DELETE FROM [RunTrack].[dbo].[Trackpoint]
DELETE FROM [RunTrack].[dbo].[Track]
DELETE FROM [RunTrack].[dbo].[Lap]
DELETE FROM [RunTrack].[dbo].[Activity] where ForeignSystemID is not null
 
commit transaction

 
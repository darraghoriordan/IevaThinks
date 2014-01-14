CREATE LOGIN [IIS APPPOOL\ASP.NET v4.0] 
  FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
  DEFAULT_LANGUAGE=[us_english]
GO
CREATE USER [AdventureWorksUser] 
  FOR LOGIN [IIS APPPOOL\ASP.NET v4.0]
GO
EXEC sp_addrolemember 'db_datareader', 'IevaThinksUser'
GO
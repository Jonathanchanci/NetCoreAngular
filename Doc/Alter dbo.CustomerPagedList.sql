USE [Northwind]
GO

/****** Objeto: SqlProcedure [dbo].[CustomerPagedList] Fecha del script: 30/03/2021 9:01:15 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CustomerPagedList]  
@page int,  
@rows int 
AS 
BEGIN  

 
 SELECT [Id]  ,[FirstName] ,[LastName] ,[City],[Country],[Phone],
 COUNT(*) OVER() TotalRecords
 FROM [Customer]
 order by [Id]
 OFFSET (@page - 1) * @rows ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END

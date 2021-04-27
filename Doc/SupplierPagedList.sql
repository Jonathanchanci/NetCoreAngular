
CREATE PROCEDURE [dbo].[SupplierPagedList]  
@page int,  
@rows int 
AS 
BEGIN  
 
 SELECT [Id]  ,CompanyName,ContactName,ContactTitle,
 City,Country,Phone,fax,
 COUNT(*) OVER() TotalRecords
 FROM [Supplier]
 order by [Id]
 OFFSET @rows*(@page - 1) ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END
GO

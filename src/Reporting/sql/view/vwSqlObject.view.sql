if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vwSqlObject]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vwSqlObject]
GO

CREATE VIEW dbo.vwSqlObject

AS

select  o.Name,
        o.Type
from sysobjects o 
GO

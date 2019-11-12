if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vwSqlColumn]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vwSqlColumn]
GO

CREATE VIEW dbo.vwSqlColumn

AS

Select  case when t.collationId>0 then c.length else null end Length, 
        case when t.collationId>0 then null else c.xscale end Scale, 
        case when t.collationId>0 then null else c.xprec end [Precision], 
        c.Name, 
        t.Name Type,
        o.Name SqlObject,
        c.colid OrdinalPosition
from syscolumns c
left join sysobjects o on c.id = o.id
left join systypes t on c.xtype = t.xtype
GO

-- ������ ��� ������ ���� ������ � ������������ ��������

USE [LegacyFinish]
GO
DBCC SHRINKDATABASE(N'LegacyFinish' )
GO
ALTER INDEX PK_tblTransactionFacts ON tblTransactionFacts REORGANIZE 



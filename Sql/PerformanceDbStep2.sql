-- ������ �����
-- 2 ���
SELECT [t].[AccountNumber], [t].[Amount], [t].[Category], [t].[ContractNumber], [t].[CustomerInn], [t].[CustomerNumber], [t].[Period], [t].[TransactionNumber]
FROM [tblTransactionFacts] AS [t]
WHERE ([t].[Period] > '2021-01-01 00:00:00') AND ([t].[Period] <= '2021-01-31 00:00:00')

-- ������� ������ �� ������� Period
Create Index IX_tblTransactionFacts_Period On [dbo].[tblTransactionFacts](Period)

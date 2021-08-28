using LegacyCore.Interfaces;
using LegacyCore.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LegacyTest
{
    [TestClass]
    public class TransactionsTests
    {
        /// <summary>
        /// ��������� ����� IsSuccess
        /// </summary>
        [TestMethod]
        public void Check_Transaction_IsSuccess()
        {
            // ����������
            var transactions = new Transactions();

            // ��������
            var result = transactions.IsSuccess;

            // ��������
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// ��������� ����� GetNextRecords � ���������� ����������
        /// </summary>
        /// <param name="source"></param>
        [TestMethod]
        public void Check_Transaction_GetNextRecords()
        {
            // ����������
            ITransactionsPeriod source = new TransactionsPeriod()
            { StartPeriod = new System.DateTime(2021, 1, 1), StopPeriod = new System.DateTime(2021, 01, 31) };
            var transactions = new Transactions();

            // ��������
            var result = transactions.GetNextRecords(source);

            // ��������
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Any());

            Console.WriteLine($"������� �������:{result.Count()}");
        }


    }
}

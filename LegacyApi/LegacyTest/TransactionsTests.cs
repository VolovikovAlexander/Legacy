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

        /// <summary>
        /// ��������� ������ ��������
        /// </summary>
        [TestMethod]
        public void Check_Transaction_CalsPeriods()
        {
            // ����������
            var startPeriod = new DateTime(2021, 01, 10);
            var stopPeriod = new DateTime(2021, 03, 12);

            // ���������
            var result = TransactionsPeriod.CalcPeriods(startPeriod, stopPeriod);

            // ��������
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(startPeriod, result.First());
            Assert.AreEqual(stopPeriod, result.Last());
        }

        /// <summary>
        /// ��������� ������ �������� ��� ��������� �������
        /// </summary>
        [TestMethod]
        public void Check_Transaction_CalcPeriods_OneMonth()
        {
            // ����������
            var startPeriod = new DateTime(2021, 02, 10);
            var stopPeriod = new DateTime(2021, 02, 28);

            // ���������
            var result = TransactionsPeriod.CalcPeriods(startPeriod, stopPeriod);

            // ��������
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(startPeriod, result.First());
            Assert.AreEqual(stopPeriod, result.Last());
        }

        /// <summary>
        /// ��������� ��������� ��������
        /// </summary>
        [TestMethod]
        public void Check_Transaction_GetPeriods()
        {
            // ����������
            var transactions = new Transactions();

            // ��������
            var result = transactions.GetPeriods();

            // ��������
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Count() > 0);
            Console.WriteLine($"������� {result.Count()}");
        }
    }
}

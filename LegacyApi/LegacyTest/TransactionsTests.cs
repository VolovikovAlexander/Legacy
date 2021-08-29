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
        /// �������� ������������ ���� � ������� refReportPeriods
        /// </summary>
        [TestMethod]
        public void Check_Transaction_LastPeriod()
        {
            // ����������
            var transactions = new Transactions();

            // ��������
            var result = transactions.LastPeriod;

            // ��������
            Assert.IsNotNull(result);
            Console.WriteLine($"��������� ������ � ������� {result}");
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
        [TestCategory("Performance")]
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

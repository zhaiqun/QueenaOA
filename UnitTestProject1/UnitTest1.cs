using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //测试用例
            int num1 = 1;
            int num2=2;
            //引入要测试的对象及方法
            Cal cal = new Cal();
            int result = cal.Add(1,2);

            //自己要实现的逻辑
            int result1 = num1 + num2;
            Assert.AreEqual(result,result1);
        }
    }
    public class Cal
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}

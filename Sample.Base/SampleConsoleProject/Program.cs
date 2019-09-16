using System;
using Sample.Base.Core;


namespace SampleConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Azure Artifacts implementation \"Sample.Base.Core\"");
            string testValue = string.Empty;

            testValue = " ";
            testValue = testValue.TrimToEmpty();
            Console.WriteLine($"TrimToEmpty-{testValue}-");

            testValue = " ";
            testValue = testValue.TrimToNull();
            Console.WriteLine($"TrimToNull-{testValue == null}-");

            testValue = " ";
            var boolV = testValue.IsNullOrEmpty();
            Console.WriteLine($"-{boolV}-");

            Console.WriteLine("End Test");
        }
    }

    public class TestEnum
    {
        public enum Enum1
        {
            test1 = 1,
            test2 = 2
        }
    }
}

using System;
using System.ComponentModel;
using Sample.Base.Core;
using Sample.Base.Core.Extensions;


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

            var enuma = TestEnum.Enum1.test1;

            Console.WriteLine($"-{enuma.ToDescription()}-");

            Console.WriteLine("End Test");
        }
    }

    public class TestEnum
    {
        public enum Enum1
        {
            [Description("haha1")]
            test1 = 1,
            [Description("haha2")]
            test2 = 2
        }
    }
}

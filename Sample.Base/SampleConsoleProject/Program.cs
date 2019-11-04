using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sample.Base.Core;
using Sample.Base.Core.Extensions;
using System.Linq;

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

            Console.WriteLine($"ToStringNum-{enuma.ToStringNum()}-");

            IEnumerable<int?> enumInts = new int?[] { 10, 20, 30, 40, 50, 40 };

            var ev = enumInts.ElementAtOrDefault(6, 100);
            Console.WriteLine("ev (is 100): " + ev);

            var ev1 = enumInts.IndexesWhere(a => a == 40);

            Console.WriteLine("IndexesWhere (is 3,5): " + string.Join(", ", ev1));

            var cl = new TestEnum();
            Console.WriteLine($"-{ ExtensionMethod.GetPropertyName( ()=> cl.ThisIsProperty)}-");

            string firstFromSplitText = "abc,edf,hij";
            Console.WriteLine("FirstFromSplit (abc,edf,hij): " + firstFromSplitText.FirstFromSplit(","));

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

        public string ThisIsProperty { get; set; }
    }
}

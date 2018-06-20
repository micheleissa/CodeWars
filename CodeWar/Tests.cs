using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CodeWar
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestOne()
        {
            int[] days = new int[] { 15, 20, 20, 15, 10, 30, 45 };
            int pages = 100;
            Assert.AreEqual(6, Book.DayIs(pages, days));
        }

        [Test]
        public void Test2()
        {
            int[] days = new int[] { 1, 0, 0, 0, 0, 0, 0 };
            int pages = 2;
            Assert.AreEqual(1, Book.DayIs(pages, days));
        }

        [Test]
        public void Test1()
        {
            var a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            var b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
            var r = AreTheySame.Comp(a, b); // True
            Assert.AreEqual(true, r);
        }

        [Test]
        public void HumanReadableTest()
        {
            Assert.AreEqual(TimeFormat.GetReadableTime(0), "00:00:00");
            Assert.AreEqual(TimeFormat.GetReadableTime(5), "00:00:05");
            Assert.AreEqual(TimeFormat.GetReadableTime(60), "00:01:00");
            Assert.AreEqual(TimeFormat.GetReadableTime(86399), "23:59:59");
            Assert.AreEqual(TimeFormat.GetReadableTime(359999), "99:59:59");
        }

        [TestCase(1002, "00:00:01:002")]
        [TestCase(700011, "00:11:40:011")]
        [TestCase(113879834, "07:37:59:834")]
        [TestCase(359999, "99:59:59")]
        public void ConvertTime_ResturnsCorrectString(double totalMiliSeconds, string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, (TimeFormat.GetReadableTime((int)totalMiliSeconds)));
        }

        [Test]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("579", Book.sumStrings("123", "456"));
            Assert.AreEqual("9984312157800830105371", Book.sumStrings("1234567891112343", "9984310923232938993028"));
            Assert.AreEqual("11111111110", Kata.SumStrings("123456789", "10987654321"));
        }

        [Test]
        public void KataTests()
        {
            Assert.AreEqual("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
            Assert.AreEqual("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
            Assert.AreEqual("", Kata.ToCamelCase(""));
        }



        [Test]
        public void TestTicket1()
        {
            int[] peopleInProgram = new int[] { 25, 25, 50, 50 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void TestTicket2()
        {
            int[] peopleInProgram = new int[] { 25, 100 };
            Assert.AreEqual("NO", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test3()
        {
            int[] peopleInProgram = new int[] { 25, 50 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test4()
        {
            int[] peopleInProgram = new int[] { 50, 25, 100 };
            Assert.AreEqual("NO", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test5()
        {
            int[] peopleInProgram = new int[] { 25, 25 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test6()
        {
            int[] peopleInProgram = new int[] { 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 50, 100, 25 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test7()
        {
            int[] peopleInProgram = new int[] { 25, 25, 25, 100 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }

        [Test]
        public void Test8()
        {
            int[] peopleInProgram = new int[] { 25 };
            Assert.AreEqual("YES", Kata.Tickets(peopleInProgram));
        }
        [Test]
        public void FactorialZerosTest()
        {
            Assert.AreEqual(1, Kata.TrailingZeros(5));
            Assert.AreEqual(6, Kata.TrailingZeros(25));
            Assert.AreEqual(131, Kata.TrailingZeros(531));
            Assert.AreEqual(249, Kata.TrailingZeros(1000));
        }
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("man i need a taxi up to ubud").Returns("taxi");
                yield return new TestCaseData("what time are we climbing up to the volcano").Returns("volcano");
                yield return new TestCaseData("take me to semynak").Returns("semynak");
            }
        }
        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing NbYear");
            testing(Arge.NbYear(1500, 5, 100, 5000), 15);
            testing(Arge.NbYear(1500000, 2.5, 10000, 2000000), 10);
            testing(Arge.NbYear(1500000, 0.25, 1000, 2000000), 94);
        }
        [Test, TestCaseSource("testCases")]
        public string Test(string s) => Kata.High(s);
        private static void Tester(List<int> argument, List<int> expectedResult)
        {
            CollectionAssert.AreEqual(expectedResult, Kata.RemoveSmallest(argument));
        }
        [Test]
        public static void BasicTests()
        {
            Tester(new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 2, 3, 4, 5 });
            Tester(new List<int> { 5, 3, 2, 1, 4 }, new List<int> { 5, 3, 2, 4 });
            Tester(new List<int> { 1, 2, 3, 1, 1 }, new List<int> { 2, 3, 1, 1 });
            Tester(new List<int>(), new List<int>());
        }
        [Test]
        //        [TestCase(451999277, 41177722899, Result = 1)]
        //        [TestCase(1222345, 12345, Result = 0)]
        //        [TestCase(12345, 12345, Result = 0)]
        //        [TestCase(666789, 12345667, Result = 1)]
        //        [TestCase(10560002, 100, Result = 1)]
        public void FixedTest()
        {
            Assert.AreEqual(1, TripleTrouble.TripleDouble(451999277, 41177722899));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(1222345, 12345));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(12345, 12345));
            Assert.AreEqual(1, TripleTrouble.TripleDouble(666789, 12345667));
            Assert.AreEqual(1, TripleTrouble.TripleDouble(10560002, 100));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(348765138, 184696997));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(348765138, 500195392));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(348765138, 147379815));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(348765138, 282704316));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(906490424, 417505649));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(906490424, 827484727));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(977228726, 795972534));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(977228726, 336792713));
            Assert.AreEqual(0, TripleTrouble.TripleDouble(977228726, 827484727));
            /*
             * 977228726 and 827484727
             *  977228726 and 336792713
             * 977228726 and 795972534
             *  906490424 and 827484727
             *  348765138 and 184696997
             *  348765138 and 500195392
             *  348765138 and 147379815
             *  348765138 and 282704316
             *   348765138 and 906057962 => 1
             *   348765138 and 675085616 => 1
             *   49927269 and 760825024 => 1
             *   49927269 and 215346421 => 1
             */
        }

        [Test]
        public void BiggestTest()
        {
            Assert.AreEqual("321", Kata.Biggest(new[] { 1, 2, 3 }));
            Assert.AreEqual("12121", Kata.Biggest(new[] { 121, 12 }));
            Assert.AreEqual("12812", Kata.Biggest(new[] { 12, 128 }));
            Assert.AreEqual("505150", Kata.Biggest(new[] { 5051, 50 }));
            Assert.AreEqual("10110", Kata.Biggest(new[] { 10, 101 }));
            Assert.AreEqual("9534330", Kata.Biggest(new[] { 3, 30, 34, 5, 9 }));
        }

        [Test]
        public static void Test9()
        {
            int[] exampleTest1 = { 2, 6, 8, -10, 3 };
            Assert.IsTrue(3 == Kata.Find(exampleTest1));
        }

        [Test]
        public static void Test10()
        {
            int[] exampleTest2 = { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 };
            Assert.IsTrue(206847684 == Kata.Find(exampleTest2));
        }

        [Test]
        public static void Tes11()
        {
            int[] exampleTest3 = { int.MaxValue, 0, 1 };
            Assert.IsTrue(0 == Kata.Find(exampleTest3));
        }

        [TestCase("()", true)]
        [TestCase("({", false)]
        public void Test12(string input, bool expected)
        {
            Assert.AreEqual(expected, Kata.Check(input));
        }

        [Test]
        public void TestStock()
        {
            string[] art = new string[] { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
            String[] cd = new String[] { "A", "B" };
            Assert.AreEqual("(A : 200) - (B : 1140)", StockList.StockSummary(art, cd));
        }
        [Test]
        public void SumPositives()
        {
            Assert.AreEqual(16, Kata.Sum(new[] { 6, 2, 1, 8, 10 }));
            Assert.AreEqual(27, Kata.Sum(new[] { 6, 2, 1, 8, 10, 10, 1 }));
            Assert.AreEqual(0, Kata.Sum(new[] { 0 }));
            var emptyArr = new int[] { };
            Assert.AreEqual(0, Kata.Sum(emptyArr));
        }

        [Test]
        public void SumNullArray()
        {
            Assert.AreEqual(null, Kata.Sum(null));
        }

        [Test]
        [TestCase("uid12345", ExpectedResult = new string[1] { "12345" })]
        [TestCase("   uidabc  ", ExpectedResult = new string[1] { "abc" })]
        [TestCase("#uidswagger", ExpectedResult = new string[1] { "swagger" })]
        [TestCase("uidone, uidtwo", ExpectedResult = new string[2] { "one", "two" })]
        [TestCase("uidCAPSLOCK", ExpectedResult = new string[1] { "capslock" })]
        [TestCase("multipleuid", ExpectedResult = new string[1] { "multipleuid" })]
        public string[] BasicTest(string s)
        {
            return Kata.GetUserIds(s);
        }


        


        Evaluator Evaluator { get; set; } = new Evaluator();

        [Test]
        [TestCase("1-1", ExpectedResult = 0)]
        [TestCase("1+1", ExpectedResult = 2)]
        [TestCase("1 - 1", ExpectedResult = 0)]
        [TestCase("1* 1", ExpectedResult = 1)]
        [TestCase("1 /1", ExpectedResult = 1)]
        [TestCase("2 / 2 + 3 * 4 - 6", ExpectedResult = 7)]
        public double TestEvaluation(string expression)
        {
            return Evaluator.Evaluate(expression);
        }


        [Test]
        public void HappyPath1()
        {
            Assert.IsTrue(StringMerger.IsMerge("codewars", "code", "wars"), "codewars can be created from code and wars");
        }

        [Test]
        public void HappyPath2()
        {
            Assert.IsTrue(StringMerger.IsMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
        }

        [Test]
        public void SadPath1()
        {
            Assert.IsFalse(StringMerger.IsMerge("codewars", "cod", "wars"), "Codewars are not codwars");
        }
        //code and wasr
        [Test]
        public void SadPath2()
        {
            Assert.IsFalse(StringMerger.IsMerge("codewars", "code", "wasr"), "Codewars are not codwars");
        }


        [Test]
        public void Test()
        {
            //            Assert.AreEqual(23, 23);
            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11",
                Kata.AlphabetPosition("The sunset sets at twelve o' clock."));
            Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20",
                Kata.AlphabetPosition("The narwhal bacons at midnight."));

        }
        [Test]
        public void TestReverseWords()
        {
            Assert.AreEqual("world! hello", Kata.ReverseWords("hello world!"));
            Assert.AreEqual("this like speak doesn't yoda", Kata.ReverseWords("yoda doesn't speak like this"));
            Assert.AreEqual("foobar", Kata.ReverseWords("foobar"));
            Assert.AreEqual("kata editor", Kata.ReverseWords("editor kata"));
            Assert.AreEqual("boat your row row row", Kata.ReverseWords("row row row your boat"));//RMOXXTNMFPJSFF KRAP  
                                                                                                 // Assert.AreEqual(" DKS  YLA D EDP X", Kata.ReverseWords("X EDP D YLA  DKS  "));
            Assert.AreEqual(" KRAP RMOXXTNMFPJSFF ", Kata.ReverseWords("RMOXXTNMFPJSFF KRAP  "));
        }

        private static IEnumerable<TestCaseData> testCasesChange
        {
            get
            {
                yield return new TestCaseData("a **&  bZ")
                                             .Returns("11000000000000000000000001");
                yield return new TestCaseData("!!a$%&RgTT")
                                             .Returns("10000010000000000101000000");
            }
        }
        [Test, TestCaseSource("testCasesChange")]
        public string TestChange(string input) => Kata.Change(input);

        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual("Thi1s is2 3a T4est", Kata.Order("is2 Thi1s T4est 3a"));
            Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", Kata.Order("4of Fo1r pe6ople g3ood th5e the2"));
            Assert.AreEqual("", Kata.Order(""));
        }

    [Test]
    public void ToUnderscoreTests()
        {
        Assert.AreEqual("test_controller", Kata.ToUnderscore("TestController"));
        Assert.AreEqual("this_is_beautiful_day", Kata.ToUnderscore("ThisIsBeautifulDay"));
        Assert.AreEqual("am7_days", Kata.ToUnderscore("Am7Days"));
        Assert.AreEqual("my3_code_is4_times_better", Kata.ToUnderscore("My3CodeIs4TimesBetter"));
        Assert.AreEqual("arbitrarily_sending_different_types_to_functions_makes_katas_cool", Kata.ToUnderscore("ArbitrarilySendingDifferentTypesToFunctionsMakesKatasCool"));
        Assert.AreEqual("1", Kata.ToUnderscore(1), "Numbers should be turned to strings!");
        }
    }
}

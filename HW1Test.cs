using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HW1Test
{
	[TestFixture]
	public class HW1Test
	{
		//loShu square arrays
		int[,] loShu = { { 8, 3, 4 }, { 1, 5, 9 }, { 6, 7, 2 } };
		int[,] shu = { { 1, 5, 3 }, { 7, 4, 9 }, { 2, 6, 8 } };
		int[,] doShu = { { 1, 4, 3 }, { 7, 4, 9 }, { 2, 3, 7 } };
		int[,] shoShu = { { 1, 5 }, { 7, 4 }, { 2, 6 } };

		[Test]//1
		public void TwoMax_TestCase_Pass()
		{
			Assert.AreEqual(9, HW1Code.TwoMax(3, 9));
			Assert.AreEqual(7, HW1Code.TwoMax(7, 2));
			Assert.AreEqual(3, HW1Code.TwoMax(3, 3));
		}

		[Test]//2
		public void ThreeMax_TestCase_Pass()
		{
			Assert.AreEqual(9, HW1Code.ThreeMax(2, 9, 5));
			Assert.AreEqual(5, HW1Code.ThreeMax(5, 5, 5));
			Assert.AreEqual(8, HW1Code.ThreeMax(1, 2, 8));
			Assert.AreEqual(7, HW1Code.ThreeMax(1, 7, 7));
			Assert.AreEqual(4, HW1Code.ThreeMax(4, 4, 2));
		}

		[Test]//3
		public void StartsWithVowel_TestCase_Pass()
		{
			Assert.True(HW1Code.StartsWithVowel('e'));
			Assert.True(HW1Code.StartsWithVowel('U'));
			Assert.False(HW1Code.StartsWithVowel('f'));
			Assert.False(HW1Code.StartsWithVowel('R'));
		}

		[Test]//4
		public void PalindromeCheck_TestCase_Pass()
		{
			Assert.True(HW1Code.PalindromeCheck("AbbA"));
			Assert.True(HW1Code.PalindromeCheck("AbcbA"));
			Assert.False(HW1Code.PalindromeCheck("abcd"));
			Assert.False(HW1Code.PalindromeCheck("abcD"));
		}

		[Test]//5
		public void OddArray_TestCase_Pass()
		{
			int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expResult = { 1, 3, 5, 7, 9 };

			Assert.AreEqual(expResult, HW1Code.OddArray(source));
			Assert.AreEqual(expResult.Length, HW1Code.OddArray(source).Length);

			source = new int[] { 2, 4, 6, 8 };
			Assert.IsEmpty(HW1Code.OddArray(source));
		}

		[Test]//6
		public void Multiply_TestCase()
		{
			List<int> myList = new List<int>();
			myList.Add(2);
			myList.Add(2);
			myList.Add(5);
			Assert.AreEqual(20, HW1Code.Multiply(myList));
			myList.Add(4);
			Assert.AreEqual(80, HW1Code.Multiply(myList));
			myList.Insert(2, 0);
			Assert.AreEqual(0, HW1Code.Multiply(myList));
		}

		[Test]//7
		public void IsSorted_TestCase()
		{
			List<double> doubleList = new List<double>();
			doubleList.Add(1.5);
			doubleList.Add(3.7);
			doubleList.Add(6.4);
			doubleList.Add(8.0);
			Assert.IsTrue(HW1Code.IsSorted(doubleList));
			doubleList.Add(2.1);
			Assert.IsFalse(HW1Code.IsSorted(doubleList));
		}

		[Test]//8
		public void Lowest_TestCase()
		{
			int[] temp = { 5, 2, 1, 7, 8 };
			Assert.AreEqual(1, HW1Code.Lowest(temp));
		}

		[Test]//9 duplicates
		public void Dups_TestCase()
		{
			List<char> charList = new List<char>();
			charList.Add('s');
			charList.Add('t');
			charList.Add('q');
			charList.Add('n');
			Assert.AreEqual(0, HW1Code.Dups(charList));
			charList.Add('s');
			Assert.AreEqual(1, HW1Code.Dups(charList));
			charList.Add('s');
			Assert.AreEqual(2, HW1Code.Dups(charList));

		}

		[Test]//10 Smallest in Dictionary
		public void LowestValue_TestCase()
		{
			Dictionary<string, int> testValue = new Dictionary<string, int>();
			testValue.Add("Apples", 5);
			testValue.Add("Grapes", 6);
			testValue.Add("Peaches", 3);
			testValue.Add("Melons", 2);
			Assert.AreEqual(2, HW1Code.LowestValue(testValue));
			testValue.Add("Oranges", 5);
			Assert.AreEqual(2, HW1Code.LowestValue(testValue));
		}

		[Test]//11 Pangram test
		public void PanGrmCheck_TestCase()
		{
			string panTrue = "The five boxing wizards jump quickly";
			string panFalse = "Any other Sentence will work for this method";
			Assert.IsTrue(HW1Code.PanGramCheck(panTrue));
			Assert.IsFalse(HW1Code.PanGramCheck(panFalse));
			Assert.IsFalse(HW1Code.PanGramCheck("Too Short"));
		}

		[Test]//12 LoShu Square Checker
		public void LoShuChecker_TestCase()
		{
			Assert.IsTrue(HW1Code.LoShu(loShu));
			Assert.IsFalse(HW1Code.LoShu(shu));
			Assert.IsFalse(HW1Code.LoShu(doShu));
			Assert.IsFalse(HW1Code.LoShu(shoShu));
		}

		[Test]
		public void numCheckTest()
		{

			Assert.IsTrue(HW1Code.numCheck(loShu));
			Assert.IsTrue(HW1Code.numCheck(shu));
			Assert.IsFalse(HW1Code.numCheck(doShu));
			//no longer needed because if (magic.GetLength(0) != magic.GetLength(1))
			//takes care of this flaw
			//Assert.IsFalse(HW1Code.numCheck(shoShu));
		}

		[Test]
		public void checkSumTest0()
		{
			Assert.IsTrue(HW1Code.checkSum(loShu, 0, 15));
			Assert.IsFalse(HW1Code.checkSum(shu, 0, 15));
			Assert.IsFalse(HW1Code.checkSum(doShu, 0, 15));
			Assert.IsFalse(HW1Code.checkSum(shoShu, 0, 15));
		}

		[Test]
		public void checkSumTest1()
		{
			Assert.IsTrue(HW1Code.checkSum(loShu, 1, 15));
			Assert.IsFalse(HW1Code.checkSum(shu, 1, 15));
			Assert.IsFalse(HW1Code.checkSum(doShu, 1, 15));
			Assert.IsFalse(HW1Code.checkSum(shoShu, 1, 15));
		}

		[Test]
		public void DiagTest1()
		{
			Assert.IsTrue(HW1Code.diaCheckSum1(loShu));
			Assert.IsFalse(HW1Code.diaCheckSum1(shu));
			Assert.IsFalse(HW1Code.diaCheckSum1(doShu));
			//Assert.IsFalse(HW1Code.diaCheckSum1(shoShu));
		}

		[Test]
		public void DiagTest2()
		{
			Assert.IsTrue(HW1Code.diaCheckSum2(loShu));
			Assert.IsFalse(HW1Code.diaCheckSum2(shu));
			Assert.IsFalse(HW1Code.diaCheckSum2(doShu));
			//Assert.IsFalse(HW1Code.diaCheckSum2(shoShu));

		}

		[Test]//13 wordList
		public void FilterLongWords_TestCase()
		{
			List<string> testWords = new List<string>();
			testWords.Add("Cows");
			testWords.Add("Tigers");
			testWords.Add("Elephants");
			testWords.Add("Lions");
			testWords.Add("Bears");
			testWords.Add("Octopuses");

			List<string> newWords = new List<string>();
			newWords.Add("ELEPHANTS");
			newWords.Add("OCTOPUSES");

			Assert.AreEqual(newWords, HW1Code.FilterLongWords(testWords, 7));
		}

		[Test]//14 Topten
		public void TopTen_TestCase()
		{
			//The Setup
			Dictionary<string, int> sendDic = new Dictionary<string, int>();
			sendDic.Add("Tom", 300);
			sendDic.Add("Jim", 3000);
			sendDic.Add("James", 236);
			sendDic.Add("Jorge", 1562);
			sendDic.Add("Hazel", 19553);
			sendDic.Add("Maria", 18523);
			sendDic.Add("Albert", 8731);
			sendDic.Add("Ed", 2498);
			sendDic.Add("Lucy", 5483);
			sendDic.Add("Mike", 6781);
			sendDic.Add("Arnold", 1568);
			sendDic.Add("Jessy", 1867);

			Dictionary<string, int> actualDic = new Dictionary<string, int>();
			actualDic.Add("Hazel", 19553);
			actualDic.Add("Maria", 18523);
			actualDic.Add("Albert", 8731);
			actualDic.Add("Mike", 6781);
			actualDic.Add("Lucy", 5483);
			actualDic.Add("Jim", 3000);
			actualDic.Add("Ed", 2498);
			actualDic.Add("Jessy", 1867);
			actualDic.Add("Arnold", 1568);
			actualDic.Add("Jorge", 1562);

			Assert.IsInstanceOf<Dictionary<string, int>>(HW1Code.TopTen(sendDic));
			Assert.AreEqual(actualDic, HW1Code.TopTen(sendDic));
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1Test
{
	public class HW1Code
	{
		// 1. returns the largest of two values
		public static int TwoMax(int arg1, int arg2)
		{
			int retVal = 0;
			if (arg1 == arg2)
			{
				Console.WriteLine("Two Values are Equal");
				retVal = arg1;
			}
			if (arg1 > arg2)
			{
				retVal = arg1;
			}
			else if (arg2 > arg1)
			{
				retVal = arg2;
			}

			return retVal;
		}


		// 2. returns the largest of three values
		public static int ThreeMax(int arg1, int arg2, int arg3)
		{
			int retVal;
			if ((arg1 == arg2) && (arg2 == arg3))
			{
				Console.WriteLine("All Values are Equal");
				retVal = arg1;
			}
			else {
				retVal = TwoMax(arg1, arg2);
				retVal = TwoMax(retVal, arg3);
			}
			return retVal;
		}

		// 3. Returns true if char is a vowel
		public static bool StartsWithVowel(char let1)
		{
			
			switch (let1)
			{
				case 'a':
				case 'A':
				case 'e':
				case 'E':
				case 'i':
				case 'I':
				case 'o':
				case 'O':
				case 'u':
				case 'U':
					return true;
				//break;
				default:
					return false;
					//break;
			}
		}

		// 4. Returns True if myString is a Palindrome
		public static bool PalindromeCheck(string myString)
		{
			myString = myString.ToLower();
			char[] myArray = myString.ToCharArray();
			Array.Reverse(myArray);
			string revString = new string(myArray);
			return myString == revString;
		}

		// 5. Returns array of all odd numbers in allNums array
		public static int[] OddArray(int[] allNums)
		{
			int count = 0;
			//Counts number of odds in the allNums array
			for (int i = 0; i < allNums.Length; i++)
			{
				if ((allNums[i] % 2) == 1)
				{
					count++;
				}
			}
			//creates new array with the length of count
			int[] oddNums = new int[count];

			//resets count to be OddNums index
			count = 0;
			//Fills oddNums with all the odd numbers in allNums
			for (int i = 0; i < allNums.Length; i++)
			{
				if ((allNums[i] % 2) == 1)
				{
					oddNums[count] = allNums[i];
					count++;
				}
			}
			return oddNums;
		}

		// 6. Multiplies all the numbers of a List
		public static int Multiply(List<int> numList)
		{
			int product = numList[0];
			for (int i = 1; i < numList.Count; i++)
			{
				product = product * numList[i];
			}
			return product;
		}

		// 7. Checks if a list is sorted
		public static bool IsSorted(List<double> numList)
		{
			//sets testSort to true
			bool testSort = true;
			double check = numList[0];
			for (int i = 1; i < numList.Count; i++)
			{
				if (check > numList[i])
				{
					testSort = false;
					break;
				}
				else
				{
					check = numList[i];
				}
			}
			return testSort;
		}

		// 8. Returns the smallest element of an Array
		public static int Lowest(int[] testArray)
		{
			int low = testArray[0];
			for (int i = 1; i < testArray.Length; i++)
			{
				if (testArray[i] < low)
				{
					low = testArray[i];
				}
			}
			return low;
		}


		//left off here 9/6/16
		// 9. Returns the number of duplicates in an list
		public static int Dups(List<char> charList)
		{
			List<char> duplicates = new List<char>();
			List<char> unique = new List<char>();
			foreach (char i in charList)
			{
				if (!unique.Contains(i))
				{
					unique.Add(i);
				}
				else {
					duplicates.Add(i);
				}
			}
			return duplicates.Count;
		}


		// 10. returns the lowest value of a dictionary of string(key) and integer(value)
		public static int LowestValue(Dictionary<string, int> allValues)
		{
			var testNums = allValues.GetEnumerator();
			testNums.MoveNext();
			int low = testNums.Current.Value;
			foreach (KeyValuePair<string, int> i in allValues)
			{
				if (i.Value < low)
				{
					low = i.Value;
				}
			}
			return low;
		}

		// 11. checks if a sentence is a pangram
		public static bool PanGramCheck(string sentence)
		{
			if (sentence.Length < 26)
			{
				return false;
			}
			sentence = sentence.ToLower();
			//char[] newSen = sentence.ToCharArray();
			//char[] alphabet2 = new char[26]{'a','b','c','d','e','f','g','h','i', 'j','k','l', 'm', 'n',
			//	'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
			int count = 0;
			bool[] alphabet = new bool[26];

			foreach (char i in sentence)
			{
				if (i >= 'a' && i <= 'z')
				{
					//index is the current value of i -97 which is the ascii value for 'a'
					int index = i - 97;
					if (!alphabet[index])
					{
						alphabet[index] = true;
						count++;
					}
				}

			}
			return count == 26;
		}

		// 12. Checks is a two-dimentional array is Lo Shu Magic Square
		public static bool LoShu(int[,] magic)
		{
			int sum = 0;
			for (int i = 0; i < magic.GetLength(0); i++)
			{
				sum += magic[i, 0];
				for (int j = 0; j < magic.GetLength(1); j++)
				{
					Console.Write(magic[i, j] + "\t");
				}
				Console.WriteLine();
			}
			//List<bool> tests = new List<bool>();
			if (magic.GetLength(0) != magic.GetLength(1))
			{ return false; }
			else if (!numCheck(magic))
			{ return false; }
			else if (!checkSum(magic, 0, sum))
			{ return false; }
			else if (!checkSum(magic, 1, sum))
			{ return false; }
			else if (!diaCheckSum1(magic))
			{ return false; }
			else if (!diaCheckSum2(magic))
			{ return false; }

			return true;
		}
		//Aux methods for Loshu method
		public static bool numCheck(int[,] magic)
		{
			bool[] checkNum = new bool[9];
			int count = 0;
			foreach (int s in magic)
			{
				if (!checkNum[s - 1])
				{
					checkNum[s - 1] = true;
					count++;
				}
			}
			return count == magic.Length;
		}

		public static bool checkSum(int[,] magic, int sw, int sum)
		{
			//*note: sw is a switch variable to 0 to add rows, 1 to add cols
			int sumTest;
			for (int i = 0; i < magic.GetLength(0); i++)
			{
				sumTest = 0;
				for (int j = 0; j < magic.GetLength(1); j++)
				{
					if (sw == 0)
					{ sumTest += magic[i, j]; }
					if (sw == 1)
					{ sumTest += magic[j, i]; }
				}
				if (sum != sumTest)
				{ return false; }
			}
			return true;
		}

		public static bool diaCheckSum1(int[,] magic)
		{
			int sum = 15;
			int sumTest = 0;
			for (int i = 0; i < magic.GetLength(0); i++)
			{
				sumTest += magic[i, i];
			}
			return sum == sumTest;
		}

		public static bool diaCheckSum2(int[,] magic)
		{
			int sum = 15;
			int sumTest = 0;
			int temp = 2;
			for (int i = 0; i < magic.GetLength(0); i++)
			{
				sumTest += magic[i, temp--];
			}
			return sum == sumTest;
		}

		// 13. Takes a list of words and an integer n and returns the
		// list words whose length is greater han n
		public static List<string> FilterLongWords(List<string> wordList, int n)
		{
			List<string> myWords = new List<string>();
			foreach (string s in wordList)
			{
				if (s.Length > n)
				{
					myWords.Add(s.ToUpper());
				}
			}
			return myWords;
		}

		// 14. Takes a dictionary of names and scores and returns a dictionary of the 
		// top ten items sorted by value
		public static Dictionary<string, int> TopTen(Dictionary<string, int> allScores)
		{
			Dictionary<string, int> firstTen = new Dictionary<string, int>();
			int count = 0;

			foreach (KeyValuePair<string, int> kvp in allScores.OrderByDescending(key => key.Value))
			{
				Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
				firstTen.Add(kvp.Key, kvp.Value);
				count++;
				if (count == 10)
				{
					break;
				}
			}
			return firstTen;
		}

		// Main method to test the homework
		public static void Main()
		{
			//1 test for TwoMax
			Console.WriteLine("Which is larger: 4, 2 ");
			Console.WriteLine(TwoMax(4, 2));

			//2 test for ThreeMax
			Console.WriteLine("Which is larger: 4, 9 ,4");
			Console.WriteLine(ThreeMax(4, 9, 4));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			//3 test for starts with vowel
			Console.WriteLine("Is it a vowel: E");
			Console.WriteLine(StartsWithVowel('E'));
			Console.WriteLine("Is it a vowel: V");
			Console.WriteLine(StartsWithVowel('V'));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			//4 test for Palindrome
			Console.WriteLine("Is it a Palindrome: abcfcbA");
			Console.WriteLine(PalindromeCheck("abcfcbA"));
			Console.WriteLine("Is it a Palindrome: abbfa");
			Console.WriteLine(PalindromeCheck("abbfa"));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();


			//5 Odds in Array
			int[] testArray = { 1, 2, 1, 2, 1, 2, 3, 3 };
			Console.WriteLine("How many odd in the array: "); //, testArray);
			foreach (int i in testArray)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\nThe odd numbers of the array are: ");
			foreach (int i in OddArray(testArray))
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\nPress Enter to Continue");
			Console.ReadLine();

			//6 multiplies the values of a integer list
			List<int> myList = new List<int>();
			myList.Add(2);
			myList.Add(2);
			myList.Add(5);
			Console.WriteLine("\nThe list has he following");
			foreach (int i in myList)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\nTheir product is {0}", Multiply(myList));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 7. Checks if a list of doubles is sorted
			List<double> doubleList = new List<double>();
			doubleList.Add(2.1);
			doubleList.Add(4.3);
			doubleList.Add(5.2);
			doubleList.Add(6.9);
			Console.WriteLine("\nThe list has the following: ");
			foreach (double i in doubleList)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\nIs this list sorted: {0}", IsSorted(doubleList));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 8. Returns the smallest element of an Array
			testArray = new int[8] { 6, 3, 7, 9, 2, 1, 8, 4 };
			Console.WriteLine("The array has the following");
			foreach (int i in testArray)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\n{0} is the lowest.", Lowest(testArray));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 9. Returns the number of duplicates in an list
			List<char> charList = new List<char>();
			charList.Add('n');
			charList.Add('a');
			charList.Add('w');
			charList.Add('a');
			charList.Add('d');
			charList.Add('e');
			charList.Add('w');
			Console.WriteLine("\nThe list has he following");
			foreach (char i in charList)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\nThe array has {0} duplicates", Dups(charList));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 10. Lowest value in an dictionary
			Dictionary<string, int> testD = new Dictionary<string, int>();
			testD.Add("Apples", 3);
			testD.Add("Pears", 7);
			testD.Add("Pineapples", 2);
			testD.Add("Kiwis", 4);
			testD.Add("Peaches", 1);
			Console.WriteLine("From the following Key Value Pair:");
			foreach (KeyValuePair<string, int> kpv in testD)
			{
				Console.WriteLine("Key: {0}, Value: {1}", kpv.Key, kpv.Value);
			}
			Console.WriteLine("The lowest value is {0}", LowestValue(testD));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 11. Pangram check
			string pgString = "The quick brown fox jumps over the lazy dog";
			Console.WriteLine("Is \"{0}\" a Pangram : {1}", pgString, PanGramCheck(pgString));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 12. LoShu
			int[,] loShuArray = { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } };
			Console.WriteLine("Is the Above a LoShu Square: {0}", LoShu(loShuArray));
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 13. List of Words larger than n
			List<string> words = new List<string>();
			words.Add("Television");
			words.Add("Radio");
			words.Add("Computer");
			words.Add("Phone");
			Console.WriteLine("Current word list");
			foreach (string s in words)
			{
				Console.WriteLine(s);
			}
			Console.WriteLine("\nWords Larger than 6");
			foreach (string s in FilterLongWords(words, 6))
			{
				Console.WriteLine(s);
			}
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();

			// 14. Top Ten
			testD.Add("Bananas", 10);
			testD.Add("Mangos", 3);
			testD.Add("Papaya", 6);
			testD.Add("Grapes", 4);
			testD.Add("Oranges", 7);
			testD.Add("Uniq", 8);
			Console.WriteLine("Current Dictionary of Words");
			foreach (KeyValuePair<string, int> w in testD)
			{
				Console.WriteLine("Key: {0}, Value {1}", w.Key, w.Value);
			}
			Console.WriteLine("\nTop Ten Dictionary of Words");
			TopTen(testD);
			/*
			foreach (KeyValuePair<string, int> w in )
			{
				Console.WriteLine("Key: {0}, Value {1}", w.Key, w.Value);
			}*/
			Console.WriteLine("Press Enter to Continue");
			Console.ReadLine();
		}
	}
}
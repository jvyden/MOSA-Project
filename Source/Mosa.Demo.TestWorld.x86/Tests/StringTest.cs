// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System;

namespace Mosa.Demo.TestWorld.x86.Tests;

public class StringTest : KernelTest
{
	public StringTest()
		: base("String")
	{
		testMethods.Add(ConcatTest1);
		testMethods.Add(ConcatTest2);
		testMethods.Add(ConcatTest3);
		testMethods.Add(ConcatTest4);
		testMethods.Add(IndexOfTest);
		testMethods.Add(LengthTest);
		testMethods.Add(ToUpperTest);
		testMethods.Add(ToLowerTest);
		testMethods.Add(SubStringTest);
		testMethods.Add(SubStringTest2);
		testMethods.Add(SubStringTest3);
		testMethods.Add(SubStringTest4);
	}

	public static bool ConcatTest1()
	{
		string part1 = "abc";
		string part2 = "def";
		string ab = "abcdef";
		string combined = string.Concat(part1, part2);

		return String.Equals(combined, ab);
	}

	public static bool ConcatTest2()
	{
		string part1 = "abc";
		string part2 = "def";
		string part3 = "ghi";
		string abc = "abcdefghi";
		string combined = string.Concat(part1, part2, part3);

		return String.Equals(combined, abc);
	}

	public static bool ConcatTest3()
	{
		string abcde = "abcddddd";
		string combined = "abc";

		for (int i = 0; i < 5; ++i)
			combined = string.Concat(combined, new string('d', 1));

		return String.Equals(combined, abcde);
	}

	public static bool ConcatTest4()
	{
		string abcde = "zzzzzzzzzz";
		string combined = string.Empty;
		char c = 'z';

		for (int i = 0; i < 10; ++i)
			combined = string.Concat(combined, new string(c, 1));

		return String.Equals(combined, abcde);
	}

	public static bool IndexOfTest()
	{
		string main = "abcdefghi";
		return main.IndexOf('c') == 2;
	}

	public static bool LengthTest()
	{
		string main = "123456789";

		return main.Length == 9;
	}

	public static bool ToUpperTest()
	{
		string s1 = "ABC";
		string s2 = "abc".ToUpper();
		return s1.Equals(s2);
	}

	public static bool ToLowerTest()
	{
		string s1 = "abc";
		string s2 = "ABC".ToLower();
		return s1.Equals(s2);
	}

	public static bool SubStringTest()
	{
		string main = "abcdefghi";
		string sub1 = main.Substring(6);
		string sub2 = main.Substring(0, 3);

		return string.Equals("ghi", sub1) && string.Equals("abc", sub2);
	}

	public static bool SubStringTest2()
	{
		string main = "abcdefghi";
		string sub1 = main.Substring(6);

		return sub1.Length == 3;
	}

	public static bool SubStringTest2b()
	{
		string main = "abcdefghi";
		string sub1 = main.Substring(6);

		return string.Equals("ghi", sub1);
	}

	public static bool SubStringTest3()
	{
		string main = "abcdefghi";
		string sub2 = main.Substring(0, 3);

		return string.Equals("abc", sub2);
	}

	public static bool SubStringTest4()
	{
		string main = "abcdefghi";
		string sub2 = main.Substring(0, 1);

		return sub2 == "a";
	}
}

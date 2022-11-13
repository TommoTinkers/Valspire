using static System.Linq.Enumerable;
using static Valspire.Test.Generators.Primitives.Characters;

namespace Valspire.Test.Generators.Primitives;

public static class Strings
{
	public const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
	public const string Letters = $"{UpperCaseLetters}{LowerCaseLetters}";
	public const string Digits = "1234567890";
	public const string Space = " ";
	public const string Whitespace = "\t\n\r ";
	public const string NoneWhitespace = $"{Letters}{Digits}";

	private static readonly Random random = new();
	
	public static string GenerateWhitespace(uint length) => FromCharacters(Whitespace, length);
	public static string GenerateNonWhitespace(uint length) => FromCharacters(NoneWhitespace, length);

	public static string Mix(string left, string right) => $"{left}{right}"
		.OrderBy(v => random.Next()).Select(a => a.ToString())
		.Aggregate((a, b) => $"{a}{b}");
		
	
	private static string FromCharacters(string characters, uint length = 10u) =>
		Range(0, (int)length)
		.Select(_ => OneOf(characters).ToString())
		.Aggregate((a,b) => $"{a}{b}");
}

public static class Characters
{
	private static readonly Random random = new();
	
	public static char OneOf(string characters)
	{
		var len = characters.Length;
		
		var randomIndex = random.Next(0, len);

		return characters[randomIndex];
	}
}
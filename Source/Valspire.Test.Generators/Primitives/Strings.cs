using System.Text;
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
	public const string OtherWhitespace = "\t\n\r";
	public const string AllWhitespace = $"{Space}{OtherWhitespace}";
	public const string NonWhitespace = $"{Letters}{Digits}{Symbols}";
	public const string Symbols = "!\"£$%^&*()_+-=[];'#,./{}:@~<>?\\|";
	public const string All = $"{NonWhitespace}{AllWhitespace}";
	private static readonly Random random = new();


	public static string GenerateSymbol() => FromCharacters(Symbols, 1u);
	public static string GenerateLetter() => GenerateLetters(1u);

	public static string GenerateDigit() => FromCharacters(Digits, 1u);
	public static string GenerateLetterOrSpace() => GenerateLettersAndSpaces(1u);
	public static string GenerateLetters(uint length) => FromCharacters(Letters, length);

	public static string GenerateOtherWhitespace() => FromCharacters(OtherWhitespace, 1u);
	
	public static string GenerateLettersAndSpaces(uint length) => FromCharacters($"{Space}{Letters}", length);
	public static string GenerateWhitespace(uint length) => FromCharacters(AllWhitespace, length);
	public static string GenerateNonWhitespace(uint length) => FromCharacters(NonWhitespace, length);

	public static string Nonsense(uint length) => FromCharacters(All, length);

	public static string MixedCycle(uint length, params Func<string>[] generators) => Mix(Cycle(length, generators));
	public static string Cycle(uint length, params Func<string>[] generators)
	{
		var sb = new StringBuilder();
		for (var x = 0u; x < length; x++)
		{
			var generatorIndex = x % generators.Length;
			sb.Append(generators[generatorIndex]());

			if (sb.Length > length)
			{
				return sb.ToString().Substring(0, (int)length);
			}
		}

		return sb.ToString();
	}
	
	
	public static string Mix(string left, string right) => $"{left}{right}"
		.OrderBy(v => random.Next()).Select(a => a.ToString())
		.Aggregate((a, b) => $"{a}{b}");

	public static string Mix(string value) =>
		value.OrderBy(v => random.Next()).Select(c => c.ToString()).Aggregate((a, b) => $"{a}{b}");
	
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
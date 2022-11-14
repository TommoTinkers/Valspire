using System.Text;
using static System.Linq.Enumerable;
using static Valspire.Test.Generators.Primitives.Characters;

namespace Valspire.Test.Generators.Primitives;

public static class Strings
{
	private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
	private const string LetterSymbols = $"{UpperCaseLetters}{LowerCaseLetters}";
	private const string Digits = "1234567890";
	private const string SpaceSymbol = " ";
	private const string OtherWhitespaceSymbol = "\t\n\r";
	private const string AllWhitespace = $"{SpaceSymbol}{OtherWhitespaceSymbol}";
	private const string NonWhitespaceSymbols = $"{LetterSymbols}{Digits}{Symbols}";
	private const string Symbols = "!\"£$%^&*()_+-=[];'#,./{}:@~<>?\\|";
	private const string All = $"{NonWhitespaceSymbols}{AllWhitespace}";
	private static readonly Random random = new();


	public static string Symbol() => FromCharacters(Symbols, 1u);
	public static string Letter() => Letters(1u);

	public static string Space() => " " ;
	public static Func<string> Spaces(uint amount) => () => new string(' ', (int)amount);
	
	public static string Digit() => FromCharacters(Digits, 1u);
	public static string LetterOrSpace() => LettersAndSpaces(1u);
	public static string Letters(uint length) => FromCharacters(LetterSymbols, length);

	public static string OtherWhiteSpace() => FromCharacters(OtherWhitespaceSymbol, 1u);

	private static string LettersAndSpaces(uint length) => FromCharacters($"{SpaceSymbol}{LetterSymbols}", length);
	public static string Whitespace(uint length) => FromCharacters(AllWhitespace, length);
	public static string NonWhitespace(uint length) => FromCharacters(NonWhitespaceSymbols, length);

	public static string Nonsense(uint length) => FromCharacters(All, length);

	public static string MixOf(uint length, params Func<string>[] generators) => Mix(Cycle(length, generators));

	public static string OneOf(params Func<string>[] generators)
	{
		var index = random.Next(0, generators.Length);
		return generators[index]();
	}

	public static string FollowedByOneOf(this string value, params Func<string>[] generators) =>
		$"{value}{OneOf(generators)}"; 

	public static string FollowedByNonsense(this string value, uint length) => length > 0 ? $"{value}{Nonsense(length)}" : value;
	
	public static string FollowedByMixOf(this string value, uint length, params Func<string>[] generators) => length > 0 ? $"{value}{MixOf(length, generators)}" : value;

	public static string FollowedByCycleOf(this string value, uint length, params Func<string>[] generators) =>
		length > 0 ? $"{value}{Cycle(length, generators)}" : value;

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

	private static string Mix(string value) =>
		value.OrderBy(v => random.Next()).Select(c => c.ToString()).Aggregate((a, b) => $"{a}{b}");
	
	private static string FromCharacters(string characters, uint length = 10u) =>
		Range(0, (int)length)
		.Select(_ => Characters.OneOf(characters).ToString())
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
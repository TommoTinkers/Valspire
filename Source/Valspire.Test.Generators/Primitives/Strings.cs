using static System.Linq.Enumerable;
using static Valspire.Test.Generators.Primitives.Characters;

namespace Valspire.Test.Generators.Primitives;

public static class Strings
{
	public static string FromCharacters(string characters, uint amount = 10u) =>
		Range(0, (int)amount)
		.Select(_ => OneOf(characters).ToString())
		.Aggregate((a,b) => $"{a}{b}");
}

public static class Characters
{
	private static readonly Random random = new Random();
	
	public static char OneOf(string characters)
	{
		var len = characters.Length;
		
		var randomIndex = random.Next(0, len);

		return characters[randomIndex];
	}
}
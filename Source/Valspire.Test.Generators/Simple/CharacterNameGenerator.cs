using Valspire.Core.CharacterCreation;
using Valspire.Func.Primitives.ResultPrimitive;
using Valspire.Test.Generators.Primitives;
using static Valspire.Core.Facts;

namespace Valspire.Test.Generators.Simple;

public static class CharacterNameGenerator
{
	private static readonly Random random = new();
	
	public static CharacterName Generate()
	{
		var length = random.Next((int)MinCharacterNameLength, (int)MaxCharacterNameLength + 1);

		while (true)
		{
			var name = Strings.NonBlankNonsense((uint)length);

			var result = CharacterName.Create(name);

			if (result is Success<CharacterName, CharacterNameValidator.Result> success)
			{
				return success.Value;
			}
		}
	}
}
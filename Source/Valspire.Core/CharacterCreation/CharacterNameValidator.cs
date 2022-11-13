using Valspire.Func.Primitives.TextPrimitive;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;

namespace Valspire.Core.CharacterCreation;

public static class CharacterNameValidator
{
	public enum Result
	{
		TooShort,
		TooLong,
		Ok,
		InvalidSymbol
	}
	
	public static object Validate(Text proposedName)
	{
		return proposedName.Value switch
		{
			{ Length: < 3 } => TooShort,
			{ Length: > 16 } => TooLong,
			_ => proposedName.Value.All(ValidateCharacter) ? Ok : InvalidSymbol
		};
	}

	private static bool ValidateCharacter(char c) => c switch
	{
		' ' => true,
		_ when char.IsLetterOrDigit(c) => true,
		_ => false
	};


}
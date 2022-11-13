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
		InvalidSymbol,
		InvalidLeadingSpaces,
		InvalidTrailingSpaces
	}
	
	public static Result Validate(Text proposedName)
	{
		var name = proposedName.Value;
		return name switch
		{
			{ Length: < 3 } => TooShort,
			{ Length: > 16 } => TooLong,
			_ => name.All(ValidateCharacter) is false ? InvalidSymbol : name.StartsWith(" ") ? InvalidLeadingSpaces : name.EndsWith(" ") ? InvalidTrailingSpaces : Ok
		};
	}

	private static bool ValidateCharacter(char c) => c switch
	{
		' ' => true,
		_ when char.IsLetterOrDigit(c) => true,
		_ => false
	};


}
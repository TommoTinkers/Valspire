using Valspire.Func.Primitives.TextPrimitive;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;
using static Valspire.Core.Facts;

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
		InvalidTrailingSpaces,
		InvalidWhitespace
	}
	
	public static Result Validate(Text proposedName)
	{
		var name = proposedName.Value;
		return name switch
		{
			{ Length: < (int)MinCharacterNameLength } => TooShort,
			{ Length: > (int)MaxCharacterNameLength } => TooLong,
			_ => name.All(ValidateCharacter) is false 
				? InvalidSymbol 
				: name.StartsWith(" ")
					? InvalidLeadingSpaces 
					: name.EndsWith(" ") 
						? InvalidTrailingSpaces
						: name.Contains("  ")
							? InvalidWhitespace 
							: Ok
		};
	}
	
	private static bool ValidateCharacter(char c) => c switch
	{
		' ' => true,
		_ when char.IsLetterOrDigit(c) => true,
		_ => false
	};
}
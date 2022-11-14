using Valspire.Func.Primitives.ResultPrimitive;
using Valspire.Func.Primitives.TextPrimitive;

namespace Valspire.Core.CharacterCreation;

public record CharacterName
{
	public Text Name { get; }

	private CharacterName(Text name)
	{
		Name = name;
	}

	public static Result<CharacterName, CharacterNameValidator.Result> Create(Text name) => CharacterNameValidator.Validate(name) switch
	{
		CharacterNameValidator.Result.Ok => R.Succeed<CharacterName, CharacterNameValidator.Result>(new CharacterName(name)),
		var fail => R.Fail<CharacterName, CharacterNameValidator.Result>(fail)
	};
}
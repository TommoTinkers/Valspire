using Valspire.Core.CharacterCreation;
using Valspire.Core.CharacterCreation.States;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Formatting;

namespace Valspire.TextView.CharacterCreation;

public class ChoosingCharacterNameView
{
	private static readonly Text EnterNamePrompt = "Enter your name";

	public ChoosingCharacterNameView(ChoosingCharacterNameState choosingCharacterNameState, Action<Text> outputter, Func<Text> inputter)
	{
		outputter(EnterNamePrompt.WithPrompt());
		
		while (true)
		{
			var input = inputter();
			if (CharacterNameValidator.Validate(input) == CharacterNameValidator.Result.Ok)
			{
				break;
			}
		}
	}
}
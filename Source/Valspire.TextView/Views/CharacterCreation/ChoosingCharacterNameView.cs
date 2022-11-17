using Valspire.Core.CharacterCreation;
using Valspire.Core.CharacterCreation.Modes;
using Valspire.Func.Primitives.ResultPrimitive;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Formatting;

namespace Valspire.TextView.CharacterCreation;

public class ChoosingCharacterNameView
{
	private static readonly Text EnterNamePrompt = "Enter your name";
	
	private readonly ChoosingCharacterNameMode mode;

	public ChoosingCharacterNameView(ChoosingCharacterNameMode mode)
	{
		this.mode = mode;
	}

	public ChoosingCharacterAttributesMode Start(Action<Text> outputter, Func<Text> inputter)
	{
		outputter(EnterNamePrompt.WithPrompt());
		
		while (true)
		{
			var input = inputter();
			var nameResult = CharacterName.Create(input);

			if (nameResult is Success<CharacterName, CharacterNameValidator.Result> name)
			{
				return mode.ChooseName(name.Value);
			}
		}
	}
}
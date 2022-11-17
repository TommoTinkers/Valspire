using Valspire.Core.CharacterCreation;
using Valspire.Core.CharacterCreation.States;
using Valspire.Func.Primitives.ResultPrimitive;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Formatting;

namespace Valspire.TextView.CharacterCreation;

public class ChoosingCharacterNameView
{
	private static readonly Text EnterNamePrompt = "Enter your name";
	
	private readonly ChoosingCharacterNameState state;

	public ChoosingCharacterNameView(ChoosingCharacterNameState state)
	{
		this.state = state;
	}

	public ChoosingCharacterAttributesState Start(Action<Text> outputter, Func<Text> inputter)
	{
		outputter(EnterNamePrompt.WithPrompt());
		
		while (true)
		{
			var input = inputter();
			var nameResult = CharacterName.Create(input);

			if (nameResult is Success<CharacterName, CharacterNameValidator.Result> name)
			{
				return state.ChooseName(name.Value);
			}
		}
	}
}
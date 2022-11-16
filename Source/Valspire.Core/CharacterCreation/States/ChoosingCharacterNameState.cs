namespace Valspire.Core.CharacterCreation.States;

public sealed record ChoosingCharacterNameState() : CharacterCreationState
{
	public object ChooseName(CharacterName name)
	{
		return new ChoosingCharacterAttributesState();
	}
}
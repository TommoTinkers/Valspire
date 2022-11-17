namespace Valspire.Core.CharacterCreation.States;

public sealed record ChoosingCharacterNameState() : CharacterCreationState
{
	public ChoosingCharacterAttributesState ChooseName(CharacterName name)
	{
		return new ChoosingCharacterAttributesState();
	}
}
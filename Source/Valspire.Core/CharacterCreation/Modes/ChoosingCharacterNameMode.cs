namespace Valspire.Core.CharacterCreation.Modes;

public sealed record ChoosingCharacterNameMode() : CharacterCreationMode
{
	public ChoosingCharacterAttributesMode ChooseName(CharacterName name)
	{
		return new ChoosingCharacterAttributesMode();
	}
}
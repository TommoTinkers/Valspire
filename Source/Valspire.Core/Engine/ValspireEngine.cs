using Valspire.Core.CharacterCreation.Modes;

namespace Valspire.Core.Engine;

public static class ValspireEngine
{
	public static ChoosingCharacterNameMode StartNewGame()
	{
		return new ChoosingCharacterNameMode();
	}
}
using Valspire.Core.CharacterCreation.States;

namespace Valspire.Core.Engine;

public static class ValspireEngine
{
	public static ChoosingCharacterNameState StartNewGame()
	{
		return new ChoosingCharacterNameState();
	}
}
using Valspire.Core.Engine.States;
using Valspire.Core.Engine.States.CharacterCreation;

namespace Valspire.Core.Engine;

public static class ValspireEngine
{
	public static ChoosingCharacterNameState StartNewGame()
	{
		return new ChoosingCharacterNameState();
	}
}
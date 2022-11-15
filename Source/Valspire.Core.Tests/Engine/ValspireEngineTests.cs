using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.Engine;
using Valspire.Core.Engine.States.CharacterCreation;

namespace Valspire.Core.Tests.Engine;

[TestFixture]
public class ValspireEngineTests
{
	[Test]
	public void StartNewGame_Gives_A_Character_Creation_State()
	{
		var state = ValspireEngine.StartNewGame();

		state.Should().BeAssignableTo<ChoosingCharacterNameState>();
	}
}
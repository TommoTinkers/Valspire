using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation.Modes;
using Valspire.Core.Engine;

namespace Valspire.Core.Tests.Engine;

[TestFixture]
public class ValspireEngineTests
{
	[Test]
	public void StartNewGame_Gives_A_Character_Creation_Mode()
	{
		var mode = ValspireEngine.StartNewGame();

		mode.Should().BeAssignableTo<ChoosingCharacterNameMode>();
	}
}
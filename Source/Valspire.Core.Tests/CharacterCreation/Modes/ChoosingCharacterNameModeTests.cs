using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation.Modes;
using Valspire.Test.Generators.Simple;

namespace Valspire.Core.Tests.CharacterCreation.Modes;

[TestFixture]
public class ChoosingCharacterNameModeTests
{
	[Test]
	[Repeat(50)]
	public void Submitting_A_Valid_Name_Gives_Back_A_ChoosingCharacterAttributesMode()
	{
		var mode = new ChoosingCharacterNameMode();

		var name = CharacterNameGenerator.Generate();

		var newMode = mode.ChooseName(name);

		newMode.Should().BeAssignableTo<ChoosingCharacterAttributesMode>();
	}
}
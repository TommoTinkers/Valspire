using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation.States;
using Valspire.Test.Generators.Simple;

namespace Valspire.Core.Tests.CharacterCreation.States;

[TestFixture]
public class ChoosingCharacterNameStateTests
{
	[Test]
	[Repeat(50)]
	public void Submitting_A_Valid_Name_Gives_Back_A_ChoosingCharacterAttributesState()
	{
		var state = new ChoosingCharacterNameState();

		var name = CharacterNameGenerator.Generate();

		var actualState = state.ChooseName(name);

		actualState.Should().BeAssignableTo<ChoosingCharacterAttributesState>();
	}
}
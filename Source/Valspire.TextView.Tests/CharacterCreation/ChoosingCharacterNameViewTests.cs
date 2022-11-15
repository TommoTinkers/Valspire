using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation;
using Valspire.Core.Engine.States.CharacterCreation;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.CharacterCreation;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;
using static Valspire.Test.Generators.Primitives.Strings;


namespace Valspire.TextView.Tests.CharacterCreation;

// ReSharper disable ObjectCreationAsStatement
[TestFixture]
[SuppressMessage("Performance", "CA1806:Do not ignore method results")]
public class ChoosingCharacterNameViewTests
{
	private static void FakeOutputter(Text text) {}

	private static Text FakeInputter() => "Hello World";

	[Test]
	public void Calls_Text_Outputter_At_Least_Once_When_Constructed()
	{
		var wasOutputterCalled = false;
		Action<Text> outputter = _ => wasOutputterCalled = true;

		new ChoosingCharacterNameView(new ChoosingCharacterNameState(), outputter, FakeInputter);

		wasOutputterCalled.Should().BeTrue();
	}

	
	[Test]
	public void Calls_Text_Inputter_When_Constructed()
	{
		var wasInputterCalled = false;
		
		Text TextInputter()
		{
			wasInputterCalled = true;
			return new Text("Hello World");
		}
		
		new ChoosingCharacterNameView(new ChoosingCharacterNameState(), FakeOutputter, TextInputter);

		wasInputterCalled.Should().BeTrue();
	}

	[Test]
	public void Calls_Text_Inputter_Repeatedly_When_It_Returns_A_Name_That_Doesnt_Validate([Range(1u, 50u)] uint nonsenseLength, [Range(1u, 10u)] uint callsToExpect)
	{
		var totalCalls = 0u;
		Text TextInputter()
		{
			totalCalls++;
			while (true)
			{
				if (totalCalls == callsToExpect)
				{
					return "Hello";
				}
				var nonsense = OneOf(Letter, Digit).FollowedByNonsense(nonsenseLength);
				if (CharacterNameValidator.Validate(nonsense) != Ok)
				{
					return nonsense.AsText();
				}
			}
		}
		
		var view = new ChoosingCharacterNameView(new ChoosingCharacterNameState(), FakeOutputter, TextInputter);

		totalCalls.Should().Be(callsToExpect);
	}
}
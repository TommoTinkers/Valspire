using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.TextPrimitive;
using static Valspire.Test.Generators.Primitives.Strings;

namespace Valspire.Func.Tests.Primitives.TextPrimitive;

[TestFixture]
public class TextHelperTests
{
	[Test]
	public void As_Text_Gives_Text_That_Is_Equal_To_Text_Instantiated_With_Constructor([Range(1u, 100u)] uint length)
	{
		var input = GenerateNonWhitespace(length);

		var extensionMethodText = input.AsText();
		var constructedText = new Text(input);

		extensionMethodText.Should().Be(constructedText);
	}


}
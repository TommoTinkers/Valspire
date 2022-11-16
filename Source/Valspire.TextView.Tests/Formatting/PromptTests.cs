using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Formatting;
using static Valspire.Test.Generators.Primitives.Strings;
using static Valspire.TextView.TextViewConcepts;

namespace Valspire.TextView.Tests.Formatting;

[TestFixture]
public class PromptTests
{
	[Test]
	public void With_Prompt_Returns_Different_Text([Range(1u, 300u)] uint sampleLength)
	{
		var sample = NonBlankNonsense(sampleLength).AsText();

		var result = sample.WithPrompt();

		result.Should().NotBe(sample);
	}

	[Test]
	public void With_Prompt_Returns_Text_That_Ends_With_Prompt([Range(1u, 300u)] uint sampleLength)
	{
		var sample = NonBlankNonsense(sampleLength).AsText();

		var result = sample.WithPrompt();

		result.Value.Should().EndWith(Prompt);
	}

	[Test]
	public void With_Prompt_Returns_Text_That_Contains_The_Initial_Text([Range(1u, 300u)] uint sampleLength)
	{
		var sample = NonBlankNonsense(sampleLength).AsText();

		var result = sample.WithPrompt();

		result.Value.Should().Contain(sample);
	}

	[Test]
	public void With_Prompt_Returns_Text_That_Is_The_Length_Of_Initial_Text_Added_To_The_Length_Of_The_Prompt(
		[Range(1u, 300u)] uint sampleLength)
	{
		var sample = NonBlankNonsense(sampleLength).AsText();

		var result = sample.WithPrompt();

		var expectedLength = sample.Value.Length + Prompt.Value.Length;

		result.Value.Length.Should().Be(expectedLength);
	}
}
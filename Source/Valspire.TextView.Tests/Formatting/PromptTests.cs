using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Formatting;
using static Valspire.Test.Generators.Primitives.Strings;

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

		result.Value.Should().EndWith(TextViewConcepts.Prompt);
	}

	[Test]
	public void With_Prompt_Returns_Text_That_Contains_The_Initial_Text([Range(1u, 300u)] uint sampleLength)
	{
		var sample = NonBlankNonsense(sampleLength).AsText();

		var result = sample.WithPrompt();

		result.Value.Should().Contain(sample);
	}
}
using FluentAssertions;
using NUnit.Framework;
using static Valspire.Core.CharacterCreation.CharacterNameValidator;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;
using static Valspire.Test.Generators.Primitives.Strings;

namespace Valspire.Core.Tests.CharacterCreation;

[TestFixture]
public class CharacterNameValidatorTests
{
	[Test]
	[Repeat(50)]
	public void Character_Name_Less_Than_Three_Gives_A_Name_Too_Short_Error([Range(1u,2u)] uint length)
	{
		var input = MixedCycle(length, GenerateLetter, GenerateLetterOrSpace);

		var result = Validate(input);

		result.Should().Be(TooShort);
	}

	[Test]
	public void Character_Name_More_Than_Sixteen_Gives_A_Name_Too_Long_Error([Range(17u, 1000u)] uint length)
	{
		var lettersAndSpaces = MixedCycle(length, GenerateLetter, GenerateLetterOrSpace);

		var result = Validate(lettersAndSpaces);

		result.Should().Be(TooLong);
	}

	[Test]
	public void Character_Name_More_Than_Two_Does_Not_Give_A_Too_Short_Error([Range(3u, 500u)] uint length)
	{
		var input = GenerateNonsense(length);

		var result = Validate(input);

		result.Should().NotBe(TooShort);
	}

	[Test]
	public void Character_Name_Less_Than_Seventeen_Does_Not_Give_A_Too_Long_Error([Range(1u, 16u)] uint length)
	{
		var input = GenerateNonsense(length);

		var result = Validate(input);

		result.Should().NotBe(TooLong);
	}

	[Test]
	public void Character_Name_With_Letters_And_Spaces_That_Is_Not_Too_Long_And_Not_Too_Short_Returns_Ok([Range(3u, 16u)] uint length)
	{
		var letters = GenerateLetters(length);

		var result = Validate(letters);

		result.Should().Be(Ok);
	}

	[Test]
	public void Character_Name_With_Only_Symbols_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixedCycle(length, GenerateSymbol);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Symbols_And_Letters_And_Spaces_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixedCycle(length, GenerateLetter, GenerateSymbol, GenerateLetterOrSpace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Letters_Spaces_And_Numbers_Should_Return_Ok([Range(3u, 16u)] uint length)
	{
		var input = MixedCycle(length, GenerateLetter, GenerateDigit, GenerateSpace);

		var result = Validate(input);

		result.Should().Be(Ok);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Other_Whitespace_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixedCycle(length, GenerateLetter, GenerateOtherWhitespace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}
}
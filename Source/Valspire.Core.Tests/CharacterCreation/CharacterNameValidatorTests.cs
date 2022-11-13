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
		var input = MixOf(length, Letter, LetterOrSpace);

		var result = Validate(input);

		result.Should().Be(TooShort);
	}

	[Test]
	public void Character_Name_More_Than_Sixteen_Gives_A_Name_Too_Long_Error([Range(17u, 1000u)] uint length)
	{
		var lettersAndSpaces = MixOf(length, Letter, LetterOrSpace);

		var result = Validate(lettersAndSpaces);

		result.Should().Be(TooLong);
	}

	[Test]
	public void Character_Name_More_Than_Two_Does_Not_Give_A_Too_Short_Error([Range(3u, 500u)] uint length)
	{
		var input = Nonsense(length);

		var result = Validate(input);

		result.Should().NotBe(TooShort);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_Less_Than_Seventeen_Does_Not_Give_A_Too_Long_Error([Range(1u, 16u)] uint length)
	{
			var input = OneOf(Letter, Digit).FollowedByNonsense(length - 1);

			var result = Validate(input);

			result.Should().NotBe(TooLong);
		
	}

	[Test]
	public void Character_Name_With_Letters_And_Spaces_That_Is_Not_Too_Long_And_Not_Too_Short_Returns_Ok([Range(3u, 16u)] uint length)
	{
		var letters = Letters(length);

		var result = Validate(letters);

		result.Should().Be(Ok);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Only_Symbols_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixOf(length, Symbol);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Symbols_And_Letters_And_Spaces_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixOf(length, Letter, Symbol, LetterOrSpace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Letters_Spaces_And_Numbers_Should_Return_Ok([Range(3u, 16u)] uint length)
	{
		var input = OneOf(Letter, Digit).FollowedByMixOf(length - 1, Letter, Digit, Space);

		var result = Validate(input);

		result.Should().Be(Ok);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Other_Whitespace_Should_Return_Invalid_Symbols([Range(3u, 16u)] uint length)
	{
		var input = MixOf(length, Letter, OtherWhiteSpace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	public void Character_Name_Starting_With_Spaces_Returns_Leading_Whitespace_Error([Range(3u, 15u)] uint lengthOfSpaces)
	{
		var remainingLength = 16u - lengthOfSpaces;
		var input = Spaces(lengthOfSpaces).FollowedByMixOf(remainingLength, Letter, Digit, Space);

		var result = Validate(input);

		result.Should().Be(InvalidLeadingSpaces);
	}
}
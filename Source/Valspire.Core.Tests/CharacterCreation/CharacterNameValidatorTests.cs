using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation;
using static Valspire.Core.CharacterCreation.CharacterNameValidator;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;
using static Valspire.Test.Generators.Primitives.Strings;

namespace Valspire.Core.Tests.CharacterCreation;

[TestFixture]
public class CharacterNameValidatorTests
{
	[Test]
	[Repeat(50)]
	public void Character_Name_Less_Than_Three_Gives_A_Name_Too_Short_Error([Range(1u,MinLength - 1u)] uint length)
	{
		var input = MixOf(length, Letter, LetterOrSpace);

		var result = Validate(input);

		result.Should().Be(TooShort);
	}

	[Test]
	public void Character_Name_More_Than_Sixteen_Gives_A_Name_Too_Long_Error([Range(MaxLength + 1u, 1000u)] uint length)
	{
		var lettersAndSpaces = MixOf(length, Letter, LetterOrSpace);

		var result = Validate(lettersAndSpaces);

		result.Should().Be(TooLong);
	}

	[Test]
	public void Character_Name_More_Than_Two_Does_Not_Give_A_Too_Short_Error([Range(MinLength, 500u)] uint length)
	{
		var input = Nonsense(length);

		var result = Validate(input);

		result.Should().NotBe(TooShort);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_Less_Than_Seventeen_Does_Not_Give_A_Too_Long_Error([Range(1u, MaxLength)] uint length)
	{
			var input = OneOf(Letter, Digit).FollowedByNonsense(length - 1);

			var result = Validate(input);

			result.Should().NotBe(TooLong);
		
	}

	[Test]
	public void Character_Name_With_Letters_And_Spaces_That_Is_Not_Too_Long_And_Not_Too_Short_Returns_Ok([Range(MinLength, MaxLength)] uint length)
	{
		var letters = Letters(length);

		var result = Validate(letters);

		result.Should().Be(Ok);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Only_Symbols_Should_Return_Invalid_Symbols([Range(MinLength, MaxLength)] uint length)
	{
		var input = MixOf(length, Symbol);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Symbols_And_Letters_And_Spaces_Should_Return_Invalid_Symbols([Range(MinLength, MaxLength)] uint length)
	{
		var input = MixOf(length, Letter, Symbol, LetterOrSpace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Letters_Spaces_And_Numbers_Should_Return_Ok([Range(MinLength, MaxLength)] uint length)
	{
		var input = OneOf(Letter, Digit)
			.FollowedByCycleOf(length - 2, Letter, Digit, Space)
			.FollowedByOneOf(Letter, Digit);

		var result = Validate(input);

		result.Should().Be(Ok);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Other_Whitespace_Should_Return_Invalid_Symbols([Range(MinLength, MaxLength)] uint length)
	{
		var input = MixOf(length, Letter, OtherWhiteSpace);

		var result = Validate(input);

		result.Should().Be(InvalidSymbol);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_Starting_With_Spaces_Returns_Leading_Whitespace_Error([Range(MinLength, MaxLength - 1u)] uint lengthOfSpaces)
	{
		var remainingLength = 16u - lengthOfSpaces;
		var input = Spaces(lengthOfSpaces)().FollowedByMixOf(remainingLength, Letter, Digit, Space);

		var result = Validate(input);

		result.Should().Be(InvalidLeadingSpaces);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_Ending_With_Space_Returns_Trailing_Whitespace_Error([Range(MinLength, MaxLength - 1u)] uint lengthOfSpaces)
	{
		var startLength = 16u - lengthOfSpaces;
		var input = MixOf(startLength, Letter, Digit).FollowedByMixOf(lengthOfSpaces, Space);

		var result = Validate(input);

		result.Should().Be(InvalidTrailingSpaces);
	}

	[Test]
	[Repeat(50)]
	public void Character_Name_With_Groups_Of_Spaces_Returns_Invalid_Whitespace_Error([Range(MinLength + 1u, MaxLength)] uint length, [Range(2u, 14u)] uint spaceGroupSize)
	{
		var start = OneOf(Letter, Digit);
		var middle = Cycle(length - 2,  Spaces(spaceGroupSize), Digit, Letter);
		var end = OneOf(Letter, Digit);

		var input = $"{start}{middle}{end}";

		var result = Validate(input);

		result.Should().Be(InvalidWhitespace);
	}
}
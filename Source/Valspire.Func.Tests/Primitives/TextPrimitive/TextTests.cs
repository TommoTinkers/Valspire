using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.TextPrimitive;
using static Valspire.Test.Generators.Primitives.Strings;

namespace Valspire.Func.Tests.Primitives.TextPrimitive;

[TestFixture]
[SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
[SuppressMessage("Performance", "CA1806:Do not ignore method results")]
public class TextTests
{
	[Test]
	public void Text_Created_With_A_Null_Value_Throws_A_Null_Text_Exception()
	{
		var TryAndCreateTextWithNullValue = () =>
		{
			new Text(null!);
		};

		TryAndCreateTextWithNullValue
			.Should()
			.ThrowExactly<NullTextException>()
			.WithMessage("A text cannot be constructed with a null value.");
	}

	[Test]
	public void Text_Created_With_An_Empty_String_Throws_A_Blank_Text_Exception()
	{
		var TryAndCreateTextWithEmptyString = () => new Text(string.Empty);

		TryAndCreateTextWithEmptyString
			.Should()
			.ThrowExactly<BlankTextException>()
			.WithMessage("A text cannot be constructed with an empty or blank string.");
	}

	[Test]
	public void Text_Created_With_Whitepsace_Throws_A_Blank_Text_Exception([Range(1u, 1000u)] uint length)
	{
		var whitespace = GenerateWhitespace(length);
		var TryAndCreateTextWithBlankString = () => new Text(whitespace);

		TryAndCreateTextWithBlankString
			.Should()
			.ThrowExactly<BlankTextException>()
			.WithMessage("A text cannot be constructed with an empty or blank string.");
	}

	[Test]
	public void Text_Created_With_At_Least_One_Non_Whitespace_Character_Does_Not_Throw_An_Exception([Range(1u, 1000u)] uint length)
	{
		var noneWhitespace = GenerateNonWhitespace(length);

		var TryAndCreateText = () => new Text(noneWhitespace);

		TryAndCreateText
			.Should()
			.NotThrow();
	}

	[Test]
	public void Text_With_Mix_Of_Whitespace_And_None_Whitespace_Does_Not_Throw_An_Exception([Range(2u, 1000u)] uint length)
	{
		var nonWhitespace = GenerateNonWhitespace(length / 2);
		var whitespace = GenerateWhitespace(length / 2);
		var mixedInput = Mix(whitespace, nonWhitespace);

		var TryAndCreateText = () => new Text(mixedInput);

		TryAndCreateText
			.Should()
			.NotThrow();
	}

	[Test]
	public void Text_With_Mix_Of_Whitespace_And_None_Whitespace_Has_The_Same_Value_It_Was_Constructed_With([Range(2u, 1000u)] uint length)
	{
		var nonWhitespace = GenerateNonWhitespace(length / 2);
		var whitespace = GenerateWhitespace(length / 2);
		var mixedInput = Mix(whitespace, nonWhitespace);

		var text = new Text(mixedInput);

		text.Value.Should().Be(mixedInput);
	}
}
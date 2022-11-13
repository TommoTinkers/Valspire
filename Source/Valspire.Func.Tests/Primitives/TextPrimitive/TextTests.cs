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
	public void Implicit_Cast_To_String_Gives_Value_That_Text_Was_Constructed_With([Range(1u, 100u)] uint length)
	{
		var input = GenerateNonWhitespace(length).AsText();
		
		void I_Need_A_String(string value)
		{
			value.Should().Be(input.Value);
		}
		
		I_Need_A_String(input);
	}

	[Test]
	public void Implicit_Cast_To_Text_Gives_A_Text_That_Matches_The_String_That_The_Text_Was_Created_With([Range(1u, 100u)] uint length)
	{
		var input = GenerateNonWhitespace(length);

		void I_Need_A_Text(Text value)
		{
			value.Value.Should().Be(input);
		}
		
		I_Need_A_Text(input);
	}
	
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
	public void Text_Created_With_Whitepsace_Throws_A_Blank_Text_Exception([Range(1u, 100u)] uint length)
	{
		var whitespace = GenerateWhitespace(length);
		var TryAndCreateTextWithBlankString = () => new Text(whitespace);

		TryAndCreateTextWithBlankString
			.Should()
			.ThrowExactly<BlankTextException>()
			.WithMessage("A text cannot be constructed with an empty or blank string.");
	}

	[Test]
	public void Text_Created_With_At_Least_One_Non_Whitespace_Character_Does_Not_Throw_An_Exception([Range(1u, 100u)] uint length)
	{
		var noneWhitespace = GenerateNonWhitespace(length);

		var TryAndCreateText = () => new Text(noneWhitespace);

		TryAndCreateText
			.Should()
			.NotThrow();
	}

	[Test]
	public void Text_With_Mix_Of_Whitespace_And_None_Whitespace_Does_Not_Throw_An_Exception([Range(2u, 100u)] uint length)
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
	public void Text_With_Mix_Of_Whitespace_And_None_Whitespace_Has_The_Same_Value_It_Was_Constructed_With([Range(2u, 100u)] uint length)
	{
		var nonWhitespace = GenerateNonWhitespace(length / 2);
		var whitespace = GenerateWhitespace(length / 2);
		var mixedInput = Mix(whitespace, nonWhitespace);

		var text = new Text(mixedInput);

		text.Value.Should().Be(mixedInput);
	}

	[Test]
	public void Text_With_No_Whitespace_Has_Same_Value_It_Was_Constructed_With([Range(2u, 100u)] uint length)
	{
		var nonWhitespace = GenerateNonWhitespace(length);

		var text = new Text(nonWhitespace);

		text.Value.Should().Be(nonWhitespace);
	}

	[Test]
	public void Two_Texts_Constructed_With_Same_Value_Are_Equal_To_Each_Other([Range(1u, 100u)] uint length)
	{
		var nonWhitespace = GenerateNonWhitespace(length);
		var copied = new string(nonWhitespace);
		var text = new Text(nonWhitespace);
		var copiedText = new Text(copied);

		text.Should().Be(copiedText);
	}

	[Test]
	public void Two_Texts_Constructed_With_Different_Values_Are_Not_Equal_To_Each_Other([Range(1u, 100u)] uint length)
	{
		var left = new Text(GenerateNonWhitespace(length));
		var right = new Text(GenerateNonWhitespace(length));

		left.Should().NotBe(right);
	}
}
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.TextPrimitive;

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
	public void Text_Created_With_Whitepsace_Throws_A_Blank_Text_Exception()
	{
		var TryAndCreateTextWithBlankString = () => new Text(" ");

		TryAndCreateTextWithBlankString
			.Should()
			.ThrowExactly<BlankTextException>()
			.WithMessage("A text cannot be constructed with an empty or blank string.");
	}
	
}
using FluentAssertions;
using NUnit.Framework;
using Valspire.Core.CharacterCreation;
using Valspire.Func.Primitives.ResultPrimitive;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.Test.Generators.Primitives;
using static Valspire.Core.Facts;
using static Valspire.Core.CharacterCreation.CharacterNameValidator;
using static Valspire.Core.CharacterCreation.CharacterNameValidator.Result;

namespace Valspire.Core.Tests.CharacterCreation;

[TestFixture]
public class CharacterNameTests
{
	[Test]
	[Repeat(50)]
	public void Create_Returns_A_Failure_For_Texts_That_Do_Not_Pass_Validation_With_Same_Validation_Result([Range(1u, 100u)] uint length)
	{
		while (true)
		{
			try
			{
				var input = Strings.Nonsense(length).AsText();
				var validationResult = Validate(input);
				if (validationResult is Ok)
				{
					continue;
				}

				var result = CharacterName.Create(input);

				result.As<Failure<CharacterName, CharacterNameValidator.Result>>().Reason.Should().Be(validationResult);
				break;
			}
			catch (BlankTextException)
			{
			}
		}
	}
	
	[Test]
	[Repeat(50)]
	public void Create_Returns_A_Failure_For_Texts_That_Do_Not_Pass_Validation([Range(1u, 100u)] uint length)
	{
		while (true)
		{
			try
			{
				var input = Strings.Nonsense(length).AsText();
				var validationResult = Validate(input);
				if (validationResult is Ok)
				{
					continue;
				}

				var result = CharacterName.Create(input);

				result.Should().BeAssignableTo<Failure>();
				break;
			}
			catch (BlankTextException)
			{
			}
		}
	}
	
	[Test]
	[Repeat(50)]
	public void Create_Returns_A_Success_With_Value_For_Texts_That_Pass_Validation([Range(MinCharacterNameLength, MaxCharacterNameLength)] uint length)
	{
		while (true)
		{
			try
			{
				var input = Strings.Nonsense(length).AsText();
				var validationResult = Validate(input);

				if (validationResult is not Ok)
				{
					continue;
				}
				
				var result = CharacterName.Create(input);

				result.As<Success<CharacterName, CharacterNameValidator.Result>>().Value.Name.Should().Be(input);
				break;
				
			} catch (BlankTextException) {}
		}
	}

	[Test]
	[Repeat(50)]
	public void Create_Returns_A_Success_For_Texts_That_Pass_Validation([Range(MinCharacterNameLength, MaxCharacterNameLength)] uint length)
	{
		while (true)
		{
			try
			{
				var input = Strings.Nonsense(length);
				var validationResult = Validate(input);

				if (validationResult is not Ok)
				{
					continue;
				}
				
				var result = CharacterName.Create(input);

				result.Should().BeAssignableTo<Success>();
				break;
				
			} catch (Exception) {}
		}
	}
}
using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.ResultPrimitive;
using static Valspire.Test.Generators.Primitives.Strings;

namespace Valspire.Func.Tests.Primitives.ResultPrimitive;

[TestFixture]
public class ResultTests
{
	[Test]
	public void Result_That_Is_Failure_Contains_Failure_Reason([Range(1u, 100u)] uint reasonLength)
	{
		var reason = Nonsense(reasonLength);
		Result<object, string> Succeed() => new FailureRecord<object,string>(reason);

		Succeed().As<Failure<object,string>>().Reason.Should().Be(reason);
	}
	
	[Test]
	public void Result_That_Is_Success_Contains_Success_Value([Range(1u, 100u)] uint successValue)
	{
		Result<uint, object> Succeed() => new SuccessRecord<uint, object>(successValue);

		Succeed().As<Success<uint, object>>().Value.Should().Be(successValue);
	}
	
	[Test]
	public void Result_TValue_TReason_Can_Match_Failure_TReason()
	{
		Result<object, object> Fail() => new FailureRecord<object, object>(new object());

		switch (Fail())
		{
			case Failure<object, object> failure:
				Assert.Pass();
				break;
			default:
				Assert.Fail();
				break;
		}
	}
	
	[Test]
	public void Result_TValue_TReason_Can_Match_Success_TValue()
	{
		Result<object, object> Succeed() => new SuccessRecord<object, object>(new object());

		switch (Succeed())
		{
			case Success<object,object> success:
				Assert.Pass();
				break;
			default:
				Assert.Fail();
				break;
		}
	}
	
	[Test]
	public void FailureRecord_Is_A_Failure_TReason()
	{
		var failure = new FailureRecord<object, object>(new object());

		failure.Should().BeAssignableTo<Failure<object,object>>();
	}
	
	[Test]
	public void SuccessRecord_Is_A_Success_TValue()
	{
		var result = new SuccessRecord<object, object>(new object());

		result.Should().BeAssignableTo<Success<object,object>>();
	}
	
	[Test]
	public void FailureRecord_Is_A_Result()
	{
		var failure = new FailureRecord<object, object>(new object());

		failure.Should().BeAssignableTo<Result>();
	}
	
	[Test]
	public void SuccessRecord_Is_A_Result()
	{
		var success = new SuccessRecord<object, object>(new object());

		success.Should().BeAssignableTo<Result>();
	}
	
	[Test]
	public void FailureRecord_Is_A_Failure()
	{
		var failure = new FailureRecord<object,object>(new object());

		failure.Should().BeAssignableTo<Failure>();
	}

	[Test]
	public void FailureRecord_Is_Not_A_Success()
	{
		var failure = new FailureRecord<object,object>(new object());

		failure.Should().NotBeAssignableTo<Success>();
	}
	
	[Test]
	public void SuccessRecord_Is_A_Success()
	{
		var success = new SuccessRecord<object, object>(new object());

		success.Should().BeAssignableTo<Success>();
	}

	[Test]
	public void SuccessRecord_Is_Not_A_Failure()
	{
		var success = new SuccessRecord<object, object>(new object());

		success.Should().NotBeAssignableTo<Failure>();
	}
	
	[Test]
	public void Success_Record_Has_A_Value_That_Matches_What_It_Was_Created_With([Range(1u, 100u)] uint valueLength)
	{
		var value = Nonsense(valueLength);

		var success = new SuccessRecord<string, object>(value);

		success.Value.Should().Be(value);
	}

	[Test]
	public void Two_Successes_Created_With_Equal_Values_Are_Considered_Equal([Range(1u, 100u)] uint valueLength)
	{
		var value = Nonsense(valueLength);
		var copiedValue = new string(value);

		var successLeft = new SuccessRecord<string, object>(value);
		var successRight = new SuccessRecord<string, object>(copiedValue);

		successLeft.Should().Be(successRight);
	}

	[Test]
	public void Failure_Record_Has_A_Reason_That_Matches_What_It_Was_Created_With([Range(1u, 100u)] uint reasonLength)
	{
		var reason = Nonsense(reasonLength);

		var failure = new FailureRecord<object,string>(reason);

		failure.Reason.Should().Be(reason);
	}

	[Test]
	public void Failure_Records_Created_With_Equal_Reasons_Are_Considered_Equal([Range(1u, 100u)] uint valueLength)
	{
		var reason = Nonsense(valueLength);
		var copiedReason = new string(reason);

		var failureLeft = new FailureRecord<object,string>(reason);
		var failureRight = new FailureRecord<object, string>(copiedReason);

		failureLeft.Should().Be(failureRight);
	}
	
	
}
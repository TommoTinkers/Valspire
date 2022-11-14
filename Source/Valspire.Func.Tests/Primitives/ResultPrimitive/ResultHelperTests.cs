using FluentAssertions;
using NUnit.Framework;
using Valspire.Func.Primitives.ResultPrimitive;

namespace Valspire.Func.Tests.Primitives.ResultPrimitive;

[TestFixture]
public class ResultHelperTests
{
	[Test]
	public void Succeed_With_Value_Gives_A_Success_With_The_Same_Value([Range(1u, 100u)] uint value)
	{
		var success = R.Succeed<uint, object>(value);

		success.Value.Should().Be(value);
	}

	[Test]
	public void Fail_With_Value_Gives_Failure_With_THe_Same_Value([Range(1u, 100u)] uint reason)
	{
		var failure = R.Fail<object, uint>(reason);
	}
}
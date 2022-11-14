namespace Valspire.Func.Primitives.ResultPrimitive;

public static class R
{
	public static Success<TValue, TReason> Succeed<TValue, TReason>(TValue value)
	{
		return new SuccessRecord<TValue, TReason>(value);
	}

	public static Failure<TValue, TReason> Fail<TValue, TReason>(TReason reason)
	{
		return new FailureRecord<TValue,TReason>(reason);
	}
}
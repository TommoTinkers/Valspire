namespace Valspire.Func.Primitives.ResultPrimitive;

public interface Failure : Result
{
	
}

public interface Failure<out TValue, out TReason> : Failure, Result<TValue, TReason>
{
	TReason Reason { get; }
}
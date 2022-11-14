namespace Valspire.Func.Primitives.ResultPrimitive;

public interface Success : Result
{
	
}

public interface Success<out TValue, out TReason> : Success, Result<TValue, TReason>
{
	TValue Value { get; }
}
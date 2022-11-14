namespace Valspire.Func.Primitives.ResultPrimitive;

public sealed record SuccessRecord<TValue, TReason>(TValue Value) : Success<TValue, TReason>;
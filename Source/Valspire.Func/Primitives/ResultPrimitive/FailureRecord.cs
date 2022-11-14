namespace Valspire.Func.Primitives.ResultPrimitive;

public record FailureRecord<TValue, TReason>(TReason Reason) : Failure<TValue, TReason>;
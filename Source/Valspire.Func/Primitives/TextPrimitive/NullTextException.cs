namespace Valspire.Func.Primitives.TextPrimitive;

public class NullTextException : Exception
{
	public NullTextException() : base("A text cannot be constructed with a null value.")
	{
	}
}
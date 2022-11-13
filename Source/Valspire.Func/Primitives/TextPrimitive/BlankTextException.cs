namespace Valspire.Func.Primitives.TextPrimitive;

public class BlankTextException : Exception
{
	public BlankTextException() : base("A text cannot be constructed with an empty or blank string.")
	{
	}
}
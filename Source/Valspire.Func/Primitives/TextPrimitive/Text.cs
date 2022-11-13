namespace Valspire.Func.Primitives.TextPrimitive;

public record Text
{
	public Text(string Text)
	{
		if (Text is null)
		{
			throw new NullTextException();
		}

		throw new BlankTextException();
	}
}
namespace Valspire.Func.Primitives.TextPrimitive;

public record Text
{
	public Text(string Text)
	{
		if (Text is null)
		{
			throw new NullTextException();
		}

		if (string.IsNullOrWhiteSpace(Text))
		{
			throw new BlankTextException();
		}

		Value = Text;
	}

	public string Value { get; }
	
	public static implicit operator string(Text text) => text.Value;

	public static implicit operator Text(string text) => text.AsText();
}
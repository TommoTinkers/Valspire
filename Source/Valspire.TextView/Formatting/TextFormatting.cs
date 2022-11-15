using Valspire.Func.Primitives.TextPrimitive;

namespace Valspire.TextView.Formatting;

public static class TextFormatting
{
	public static Text WithPrompt(this Text text) => $"{text.Value}{TextViewConcepts.Prompt.Value}";
}
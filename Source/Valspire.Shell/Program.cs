using Valspire.Core.CharacterCreation.States;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.CharacterCreation;

Text ReadLine()
{
	while (true)
	{
		var input = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(input) is false)
		{
			return input.AsText();
		}
	}
}

// ReSharper disable once ObjectCreationAsStatement
#pragma warning disable CA1806
new ChoosingCharacterNameView(new ChoosingCharacterNameState(),t =>  Console.Write(t.Value), ReadLine);
#pragma warning restore CA1806

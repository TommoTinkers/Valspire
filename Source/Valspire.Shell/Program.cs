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

var view = new ChoosingCharacterNameView(new ChoosingCharacterNameState());
view.Start(t  => Console.Write(t.Value), ReadLine);

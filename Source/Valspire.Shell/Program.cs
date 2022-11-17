using Valspire.Core.CharacterCreation.Modes;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Views.CharacterCreation;

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

var view = new ChoosingCharacterNameView(new ChoosingCharacterNameMode());
view.Start(t  => Console.Write(t.Value), ReadLine);

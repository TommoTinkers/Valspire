using Valspire.Core.CharacterCreation.Modes;
using Valspire.Func.Primitives.TextPrimitive;
using Valspire.TextView.Views;
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

View GetViewForMode(Mode m)
{
	return m switch
	{
		ChoosingCharacterNameMode choosingCharacterNameMode => () => new ChoosingCharacterNameView(choosingCharacterNameMode).Start(t => Console.Write(t.Value), ReadLine),
		_ => CreateUnimplementedView(m)
	};

	View CreateUnimplementedView(Mode mode)
	{
		return () =>
		{
			Console.WriteLine(
				$"There is no view for the current game mode. The current Game mode is {mode}");
			Console.ReadKey(true);
			Environment.Exit(-1);
			return mode;
		};
	}
}

Mode mode = new ChoosingCharacterNameMode();

while (true)
{
	var view = GetViewForMode(mode);
	var oldMode = mode;
	mode = view();
	if (mode == oldMode)
	{
		break;
	}
}

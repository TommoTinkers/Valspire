using Valspire.Core.CharacterCreation;
using Valspire.Test.Generators.Primitives;

using var fw = new StreamWriter("D:/Samples.txt");


const uint samplesToGenerate = 1u;
var samplesGenerated = 0u;

while(samplesGenerated < samplesToGenerate)
{
	
		var sample = Strings.Nonsense(CharacterNameValidator.MaxLength);
		if (sample.All(char.IsWhiteSpace))
		{
			continue;
		}
		
		var result = CharacterNameValidator.Validate(sample);


		if (result is CharacterNameValidator.Result.Ok)
		{
			fw.WriteLine(sample);
			samplesGenerated++;
		}
}
using Valspire.Core.CharacterCreation;
using Valspire.Test.Generators.Primitives;

using var fw = new StreamWriter("D:/Samples.txt");

var sampleLength = 16u;
var samplesToGenerate = 50000u;
var samplesGenerated = 0u;

while(samplesGenerated < samplesToGenerate)
{
	
		var sample = Strings.Nonsense(16u);
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
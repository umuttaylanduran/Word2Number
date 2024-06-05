using NLP.API.Repositories;
using NLP.API.Services.Abstracts;
using System.Text.RegularExpressions;

namespace NLP.API.Services.Concretes
{
    public class TextProcessingService : ITextProcessingService
    {
        // dependency injection
        private readonly IRegexPatternService _regexPatternService;
        public TextProcessingService(IRegexPatternService regexPatternService)
        {
            _regexPatternService = regexPatternService;
        }

        public string PreprocessText(string text)
        {
            var matches = _regexPatternService.GetExtendedNumberPattern().Matches(text); // Oluşturulan Regular Pattern doğrultusunda cümledeki metinleri bulur. MatchCollection'da tutar.
            foreach (Match match in matches)
            {
                var numberString = match.Value;
                var separatedWords = SeparateWords(numberString); // Birleşik sayıları ayırma işlemi yapar (yedi100 --> yedi 100 vs.)
                text = text.Replace(numberString, separatedWords);
            }
            return text;
        }
        private string SeparateWords(string matchedString)
        {
            var result = matchedString;
            foreach (var key in NumberWordsDictionary.NumbersAndMultipliers.Keys)
            {
                result = Regex.Replace(result, key, $" {key} "); // Tek tek dictionary'yi tarar ve ilgili 'key' ile ' key ' ifesini değiştirir (Sağdan ve soldan birer boşluk)
            }
            return Regex.Replace(result, @"\s+", " ").Trim(); // Tekrardan ardaşık boşluklar temizlenir ve return edilir.
        }
    }
}

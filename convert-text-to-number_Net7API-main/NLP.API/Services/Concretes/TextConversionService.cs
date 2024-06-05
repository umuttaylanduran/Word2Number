using NLP.API.Services.Abstracts;
using System.Text.RegularExpressions;

namespace NLP.API.Services.Concretes
{
    public class TextConversionService : ITextConversionService
    {
        // Dependency Injection
        private readonly IRegexPatternService _regexPatternService; // Regex Pattern'in oluşturulması
        private readonly ITextProcessingService _textProcessingService; // Metin işleme servisi
        private readonly INumberConversionService _numberConversionService; // Sayıya çevirme servisi
        public TextConversionService(ITextProcessingService textProcessingService, INumberConversionService numberConversionService, IRegexPatternService regexPatternService)
        {
            _textProcessingService = textProcessingService;
            _numberConversionService = numberConversionService;
            _regexPatternService = regexPatternService;
        }

        public string ConvertToNumberFormat(string text) // Sayı formatına çevirme
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Metin boş olamaz.");

            text = Regex.Replace(text.ToLowerInvariant().Trim(), @"\s+", " "); // Bütün harfleri küçültüyoruz ve gereksiz boşluklardan vs. kurtuluyoruz.
            text = _textProcessingService.PreprocessText(text); // Metin işleme methodumuzu çalıştırıyoruzç

            var regexPattern = _regexPatternService.GetNumberWordRegexPattern(); // İstediğimiz sınırlandırmalar dahilinde bir 'Regex Pattern' oluşturuyoruz.
            var matches = Regex.Matches(text, regexPattern); // Regex'in Matches methodunu kullanarak aradığımız sınırlar dahilinde 'text' ile matchleşen alanları yakalıyoruz.

            foreach (Match match in matches)
            {
                var numberString = match.Value.Trim();
                var numberValue = _numberConversionService.ConvertNumberWordsToNumber(numberString); // İlgili metinsel ifadeyi yazılı ifadeye dönüştüren method.
                text = text.Replace(numberString, numberValue.ToString()); // numberString ile numberValue cümle içinde değiştiriliyor (Replace).
            }

            return text;
        }
    }
}

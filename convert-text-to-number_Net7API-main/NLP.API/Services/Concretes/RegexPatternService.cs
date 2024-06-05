using NLP.API.Repositories;
using NLP.API.Services.Abstracts;
using System.Text.RegularExpressions;

namespace NLP.API.Services.Concretes
{
    public class RegexPatternService : IRegexPatternService
    {
        public Regex GetExtendedNumberPattern()
        {
            var allNumberWords = string.Join("|", CombinedMethod()); // Bir takım kelimeyi 'veya' bağlacı ile bağlıyoruz
            return new Regex($@"\b({allNumberWords})+\b", RegexOptions.Compiled); // '\b' --> yalnızca "allNumberWords" içindeki değişkenleri ara anlamına gelir , '+' --> tekrarlanan öğeler için kullanılır / RegexOptions.Compiled (Derlenmiş Modda)
        }
        public string GetNumberWordRegexPattern()
        {
            return $@"(\b({string.Join("|", CombinedMethod())})\b\s*)+"; // '\b' --> kelime sınırlarını belirler, '\s*' --> Kelimeler arasındaki boşlukları yakalar, '+' --> Tekrarlanan öğeler için kullanılır
        }

        // private method
        private IEnumerable<string> CombinedMethod() // Dictionary'deki key-value'leri birleştirerek bize bir arama havuzu oluşturur.
        {
            var keys = NumberWordsDictionary.NumbersAndMultipliers.Keys;
            var values = NumberWordsDictionary.NumbersAndMultipliers.Values.Select(v => v.ToString());
            // Anahtarları ve değerleri birleştirin
            return keys.Concat(values);
        }
    }
}

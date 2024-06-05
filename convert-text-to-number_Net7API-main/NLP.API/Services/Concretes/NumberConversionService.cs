using NLP.API.Repositories;
using NLP.API.Services.Abstracts;

namespace NLP.API.Services.Concretes
{
    public class NumberConversionService : INumberConversionService
    {
        public long ConvertNumberWordsToNumber(string numberWord)
        {
            long total = 0; // toplam sayı
            long currentNumber = 0; // mevcut sayı
            var words = numberWord.Split(' '); // Gelen ifadeyi 'boşluk' a bağlı olarak ayırıyor (words array)
            long value = 0; // methoda gelen değer

            foreach (var word in words)
            {
                if (long.TryParse(word, out long numericValue)) { value = numericValue; } // gelen değer zaten sayısal ifade mi (örn: "100")
                else if (NumberWordsDictionary.NumbersAndMultipliers.TryGetValue(word, out value)) { } // gelen değer metinsel ifade ise (örn: "yüz")
                else { continue; } // else koşulu (örn: "lira")

                if (value < 100) // normal sayı
                {
                    currentNumber += value;
                }
                else // çarpan (100,1000 vs.)
                {
                    currentNumber = (currentNumber == 0 ? 1 : currentNumber) * value; // currentNumber == 0 --> 1 * 100 ||||| currentNumber != 0 --> x * 100
                    if (value >= 1000)
                    {
                        total += currentNumber;
                        currentNumber = 0;
                    }
                }
            }
            return total + currentNumber;
        }
    }
}

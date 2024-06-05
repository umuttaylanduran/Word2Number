using System.Text.RegularExpressions;

namespace NLP.API.Services.Abstracts
{
    public interface IRegexPatternService
    {
        Regex GetExtendedNumberPattern();
        string GetNumberWordRegexPattern();
    }
}

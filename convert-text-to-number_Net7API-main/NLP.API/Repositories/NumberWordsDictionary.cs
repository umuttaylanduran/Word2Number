﻿namespace NLP.API.Repositories
{
    public static class NumberWordsDictionary
    {
        public static readonly Dictionary<string, long> NumbersAndMultipliers = new Dictionary<string, long>
        {
            {"bir", 1}, {"iki", 2}, {"üç", 3}, {"dört", 4}, {"beş", 5},{"altı", 6}, {"yedi", 7}, {"sekiz", 8}, {"dokuz", 9},
            {"on", 10}, {"yirmi", 20}, {"otuz", 30}, {"kırk", 40}, {"elli", 50}, {"altmış", 60}, {"yetmiş", 70}, {"seksen", 80}, {"doksan", 90},
            {"yüz", 100},
            {"bin", 1000}
        };
    }
}

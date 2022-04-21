using System;
using System.Collections.Concurrent;
using System.IO;
using SkiaSharp;

namespace QuestPDF.ReportSample
{
    public static class Helpers
    {
        public static Random Random { get; } = new Random(1);
        
        public static string GetTestItem(string path) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", path);

        public static byte[] GetImage(string name)
        {
            var photoPath = GetTestItem(name);
            return SKImage.FromEncodedData(photoPath).EncodedData.ToArray();
        }

        public static Location RandomLocation()
        {
            return new Location
            {
                Longitude = Helpers.Random.NextDouble() * 360f - 180f,
                Latitude = Helpers.Random.NextDouble() * 180f - 90f
            };
        }

        private static readonly ConcurrentDictionary<int, string> RomanNumeralCache = new ConcurrentDictionary<int, string>();

        public static string FormatAsRomanNumeral(this int number)
        {
            if (number < 0 || number > 3999) 
                throw new ArgumentOutOfRangeException("Number should be in range from 1 to 3999");
            
            return RomanNumeralCache.GetOrAdd(number, x =>
            {
                if (x >= 1000) return "M" + FormatAsRomanNumeral(x - 1000);
                if (x >= 900) return "CM" + FormatAsRomanNumeral(x - 900); 
                if (x >= 500) return "D" + FormatAsRomanNumeral(x - 500);
                if (x >= 400) return "CD" + FormatAsRomanNumeral(x - 400);
                if (x >= 100) return "C" + FormatAsRomanNumeral(x - 100);            
                if (x >= 90) return "XC" + FormatAsRomanNumeral(x - 90);
                if (x >= 50) return "L" + FormatAsRomanNumeral(x - 50);
                if (x >= 40) return "XL" + FormatAsRomanNumeral(x - 40);
                if (x >= 10) return "X" + FormatAsRomanNumeral(x - 10);
                if (x >= 9) return "IX" + FormatAsRomanNumeral(x - 9);
                if (x >= 5) return "V" + FormatAsRomanNumeral(x - 5);
                if (x >= 4) return "IV" + FormatAsRomanNumeral(x - 4);
                if (x >= 1) return "I" + FormatAsRomanNumeral(x - 1);
                
                return string.Empty;  
            });
        }
    }
}
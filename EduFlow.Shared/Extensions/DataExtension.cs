using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduFlow.Shared.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Determines whether the specified integer value is within the specified range.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>
        /// true if the value is within the range [min, max]; otherwise, false.
        /// </returns>
        public static bool IsInRange(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Determines whether the specified double value is within the specified range.
        /// </summary>
        /// <param name="value">The double value to check.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>
        /// true if the value is within the range [min, max]; otherwise, false.
        /// </returns>
        public static bool IsInRange(this double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Determines whether the specified decimal value is within the specified range.
        /// </summary>
        /// <param name="value">The decimal value to check.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>
        /// true if the value is within the range [min, max]; otherwise, false.
        /// </returns>
        public static bool IsInRange(this decimal value, decimal min, decimal max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Determines whether the specified integer value is even.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <returns>
        /// true if the value is even; otherwise, false.
        /// </returns>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Determines whether the specified integer value is odd.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <returns>
        /// true if the value is odd; otherwise, false.
        /// </returns>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Rounds the specified double value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="decimalPlaces">The number of decimal places to round to.</param>
        /// <returns>
        /// The value rounded to the specified number of decimal places.
        /// </returns>
        public static double RoundTo(this double value, int decimalPlaces)
        {
            return Math.Round(value, decimalPlaces);
        }

        /// <summary>
        /// Rounds the specified decimal value to a specified number of decimal places.
        /// </summary>
        /// <param name="value">The decimal value to round.</param>
        /// <param name="decimalPlaces">The number of decimal places to round to.</param>
        /// <returns>
        /// The value rounded to the specified number of decimal places.
        /// </returns>
        public static decimal RoundTo(this decimal value, int decimalPlaces)
        {
            return Math.Round(value, decimalPlaces);
        }

        /// <summary>
        /// Converts the specified double value to a percentage string with a specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <param name="decimalPlaces">The number of decimal places to include in the percentage string.</param>
        /// <returns>
        /// A string representing the value as a percentage with the specified number of decimal places.
        /// </returns>
        public static string ToPercentage(this double value, int decimalPlaces = 2)
        {
            return (value * 100).RoundTo(decimalPlaces) + "%";
        }

        /// <summary>
        /// Converts the specified decimal value to a percentage string with a specified number of decimal places.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="decimalPlaces">The number of decimal places to include in the percentage string.</param>
        /// <returns>
        /// A string representing the value as a percentage with the specified number of decimal places.
        /// </returns>
        public static string ToPercentage(this decimal value, int decimalPlaces = 2)
        {
            return (value * 100).RoundTo(decimalPlaces) + "%";
        }

    }
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified string contains the specified substring, 
        /// using a case-insensitive comparison.
        /// </summary>
        /// <param name="source">The source string to search within.</param>
        /// <param name="value">The substring to search for.</param>
        /// <returns>
        /// true if the substring occurs within the source string; otherwise, false. 
        /// If the source string is null, returns false.
        /// </returns>
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            return source?.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Converts the specified string to title case (first letter of each word capitalized).
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>
        /// A string in title case if the input is not null, empty, or whitespace; otherwise, 
        /// returns the original string. The conversion is performed based on the current culture.
        /// </returns>
        public static string ToTitleCase(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return value;
            }

            var cultureInfo = CultureInfo.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Determines whether the specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>
        /// true if the value parameter is null or System.String.Empty, or if value consists exclusively of white-space characters.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// Determines whether the specified string is null or an empty string.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>
        /// true if the value parameter is null or an empty string (""); otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }


        /// <summary>
        /// Truncates the specified string to a specified maximum length.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">The maximum length of the returned string.</param>
        /// <returns>
        /// The truncated string if the length of the string exceeds the specified maximum length; 
        /// otherwise, the original string. If the input string is null, empty, or consists only of white-space characters, 
        /// the original string is returned.
        /// </returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (value.IsNullOrWhiteSpace() || value.Length <= maxLength)
            {
                return value;
            }

            return value.Substring(0, maxLength);
        }




        public static bool IsValidEmail(this string email)
        {
            Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return !string.IsNullOrWhiteSpace(email) && _emailRegex.IsMatch(email);
        }
        public static string? NormalizeEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            try
            {
                return new MailAddress(email).Address;
            }
            catch
            {
                return null;
            }
        }

    }
    //public class Example
    //{
    //    public void Run()
    //    {
    //        // String extensions
    //        string name = "john doe";
    //        string truncatedName = name.Truncate(4); // "john"
    //        bool isEmpty = name.IsNullOrEmpty(); // false
    //        string titleCaseName = name.ToTitleCase(); // "John Doe"

    //        // Numeric extensions
    //        int number = 5;
    //        bool isInRange = number.IsInRange(1, 10); // true
    //        bool isEven = number.IsEven(); // false

    //        double percentage = 0.12345;
    //        string percentageString = percentage.ToPercentage(); // "12.35%"
    //    }
    //}



}
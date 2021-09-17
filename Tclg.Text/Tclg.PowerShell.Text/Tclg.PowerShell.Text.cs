using System.Linq;
using System;
using System.Text;

namespace Tclg.PowerShell.Text
{
    public static class StringExtensions
    {
        public static string AddPrefix(this string @this, string value, string separator = "") => String.Join(separator, value, @this);
        public static string AddPrefixIfAbsent(this string @this, string value, string separator = "") => @this.StartsWith(value) ? @this : @this.AddPrefix(value, separator);
        public static string AddSuffix(this string @this, string value, string separator = "") => String.Join(separator, @this, value);
        public static string AddSuffixIfAbsent(this string @this, string value, string separator = "") => @this.EndsWith(value) ? @this : @this.AddSuffix(value, separator);
        public static string Head(this string @this, int length) => @this.Substring(0, Math.Clamp(length, 0, @this.Length));
        public static string Remove(this string @this, string value) => @this.Replace(value, String.Empty);
        public static string RemoveFirst(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Remove(index, value.Length) : @this; }
        public static string RemoveHead(this string @this, int length) => @this.Substring(Math.Clamp(length, 0, @this.Length));
        public static string RemoveLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Remove(index, value.Length) : @this; }
        public static string RemovePrefixIfPresent(this string @this, string value) => @this.StartsWith(value) ? @this.Substring(value.Length) : @this;
        public static string RemoveSuffixIfPresent(this string @this, string value) => @this.EndsWith(value) ? @this.Substring(0, @this.Length - value.Length) : @this;
        public static string RemoveTail(this string @this, int length) => @this.Substring(0, @this.Length - Math.Clamp(length, 0, @this.Length));
        public static string ReplaceHead(this string @this, int length, string newValue) => @this.RemoveHead(length).AddPrefix(newValue);
        public static string ReplacePrefixIfPresent(this string @this, string oldValue, string newValue) => @this.StartsWith(oldValue) ? @this.RemoveHead(oldValue.Length).AddPrefix(newValue) : @this;
        public static string ReplaceSuffixIfPresent(this string @this, string oldValue, string newValue) => @this.EndsWith(oldValue) ? @this.RemoveTail(oldValue.Length).AddSuffix(newValue) : @this;
        public static string ReplaceTail(this string @this, int length, string newValue) => @this.RemoveTail(length).AddSuffix(newValue);
        public static string SubstringFrom(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Substring(index) : String.Empty; }
        public static string SubstringFromLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Substring(index) : String.Empty; }
        public static string SubstringUntil(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Substring(0, index) : String.Empty; }
        public static string SubstringUntilLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Substring(0, index) : String.Empty; }
        public static string Tail(this string @this, int length) => @this.Substring(@this.Length - (length = Math.Clamp(length, 0, @this.Length)), length);
    }

    public static class UTF8EncodingExtensions
    {
        public static bool HasBOM(this UTF8Encoding @this) => @this.GetPreamble().Length > 0;
    }
}

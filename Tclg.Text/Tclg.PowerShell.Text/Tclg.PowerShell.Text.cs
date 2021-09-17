using System;
using System.Management.Automation;
using System.Text;

namespace Tclg.PowerShell.Text
{
    public static class StringTypeData
    {
        private const string DefaultSeparator = "";

        private static string AddPrefix(this string @this, string value, string separator = DefaultSeparator) => String.Join(separator, value, @this);
        private static string AddPrefixIfAbsent(this string @this, string value, string separator = DefaultSeparator) => @this.StartsWith(value) ? @this : @this.AddPrefix(value, separator);
        private static string AddSuffix(this string @this, string value, string separator = DefaultSeparator) => String.Join(separator, @this, value);
        private static string AddSuffixIfAbsent(this string @this, string value, string separator = DefaultSeparator) => @this.EndsWith(value) ? @this : @this.AddSuffix(value, separator);
        private static string Head(this string @this, int length) => @this.Substring(0, Math.Clamp(length, 0, @this.Length));
        private static string Remove(this string @this, string value) => @this.Replace(value, String.Empty);
        private static string RemoveFirst(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Remove(index, value.Length) : @this; }
        private static string RemoveHead(this string @this, int length) => @this.Substring(Math.Clamp(length, 0, @this.Length));
        private static string RemoveLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Remove(index, value.Length) : @this; }
        private static string RemovePrefixIfPresent(this string @this, string value) => @this.StartsWith(value) ? @this.Substring(value.Length) : @this;
        private static string RemoveSuffixIfPresent(this string @this, string value) => @this.EndsWith(value) ? @this.Substring(0, @this.Length - value.Length) : @this;
        private static string RemoveTail(this string @this, int length) => @this.Substring(0, @this.Length - Math.Clamp(length, 0, @this.Length));
        private static string ReplaceHead(this string @this, int length, string newValue) => @this.RemoveHead(length).AddPrefix(newValue);
        private static string ReplacePrefixIfPresent(this string @this, string oldValue, string newValue) => @this.StartsWith(oldValue) ? @this.RemoveHead(oldValue.Length).AddPrefix(newValue) : @this;
        private static string ReplaceSuffixIfPresent(this string @this, string oldValue, string newValue) => @this.EndsWith(oldValue) ? @this.RemoveTail(oldValue.Length).AddSuffix(newValue) : @this;
        private static string ReplaceTail(this string @this, int length, string newValue) => @this.RemoveTail(length).AddSuffix(newValue);
        private static string SubstringFrom(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Substring(index) : String.Empty; }
        private static string SubstringFromLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Substring(index) : String.Empty; }
        private static string SubstringUntil(this string @this, string value) { int index = @this.IndexOf(value); return index >= 0 ? @this.Substring(0, index) : String.Empty; }
        private static string SubstringUntilLast(this string @this, string value) { int index = @this.LastIndexOf(value); return index >= 0 ? @this.Substring(0, index) : String.Empty; }
        private static string Tail(this string @this, int length) => @this.Substring(@this.Length - (length = Math.Clamp(length, 0, @this.Length)), length);

        public static string AddPrefix(PSObject psObject, string value, string separator = DefaultSeparator) => ((string) psObject.BaseObject).AddPrefix(value, separator);
        public static string AddPrefixIfAbsent(PSObject psObject, string value, string separator = DefaultSeparator) => ((string) psObject.BaseObject).AddPrefixIfAbsent(value, separator);
        public static string AddSuffix(PSObject psObject, string value, string separator = DefaultSeparator) => ((string) psObject.BaseObject).AddSuffix(value, separator);
        public static string AddSuffixIfAbsent(PSObject psObject, string value, string separator = DefaultSeparator) => ((string) psObject.BaseObject).AddSuffixIfAbsent(value, separator);
        public static string Head(PSObject psObject, int length) => ((string) psObject.BaseObject).Head(length);
        public static string Remove(PSObject psObject, string value) => ((string) psObject.BaseObject).Remove(value);
        public static string RemoveFirst(PSObject psObject, string value) => ((string) psObject.BaseObject).RemoveFirst(value);
        public static string RemoveHead(PSObject psObject, int length) => ((string) psObject.BaseObject).RemoveHead(length);
        public static string RemoveLast(PSObject psObject, string value) => ((string) psObject.BaseObject).RemoveLast(value);
        public static string RemovePrefixIfPresent(PSObject psObject, string value) => ((string) psObject.BaseObject).RemovePrefixIfPresent(value);
        public static string RemoveSuffixIfPresent(PSObject psObject, string value) => ((string) psObject.BaseObject).RemoveSuffixIfPresent(value);
        public static string RemoveTail(PSObject psObject, int length) => ((string) psObject.BaseObject).RemoveTail(length);
        public static string ReplaceHead(PSObject psObject, int length, string newValue) => ((string) psObject.BaseObject).ReplaceHead(length, newValue);
        public static string ReplacePrefixIfPresent(PSObject psObject, string oldValue, string newValue) => ((string) psObject.BaseObject).ReplacePrefixIfPresent(oldValue, newValue);
        public static string ReplaceSuffixIfPresent(PSObject psObject, string oldValue, string newValue) => ((string) psObject.BaseObject).ReplaceSuffixIfPresent(oldValue, newValue);
        public static string ReplaceTail(PSObject psObject, int length, string newValue) => ((string) psObject.BaseObject).ReplaceTail(length, newValue);
        public static string SubstringFrom(PSObject psObject, string value) => ((string) psObject.BaseObject).SubstringFrom(value);
        public static string SubstringFromLast(PSObject psObject, string value) => ((string) psObject.BaseObject).SubstringFromLast(value);
        public static string SubstringUntil(PSObject psObject, string value) => ((string) psObject.BaseObject).SubstringUntil(value);
        public static string SubstringUntilLast(PSObject psObject, string value) => ((string) psObject.BaseObject).SubstringUntilLast(value);
        public static string Tail(PSObject psObject, int length) => ((string) psObject.BaseObject).Tail(length);
    }

    public static class UTF8EncodingTypeData
    {
        private static bool HasBOM(this UTF8Encoding @this) => @this.GetPreamble().Length > 0;

        public static bool HasBOM(PSObject psObject) => ((UTF8Encoding) psObject.BaseObject).HasBOM();
    }
}

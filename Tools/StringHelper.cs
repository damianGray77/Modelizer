using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools {
	public enum Access {
		Public, Private
	}

	public static class StringHelper {
		private static bool CanSeparate<T>(string String1, string String2, T Separator) where T : IComparable, IConvertible, IComparable<T>, IEquatable<T> {
			bool no = 
				string.IsNullOrWhiteSpace(String1)
				|| string.IsNullOrWhiteSpace(String2)
			;

			if(Separator is string) {
				no = no || string.IsNullOrEmpty(Separator as string);
			}

			return !no;
		}

		private static string Concat<T>(string String1, string String2, T Separator, bool Separate) where T : IComparable, IConvertible, IComparable<T>, IEquatable<T> {
			if (Separate) {
				return String2 + Separator + String1;
			} else {
				return String2 + String1;
			}
		}

		public static string Suffix(this string String1, string String2, string Separator = null) {
			bool separate = CanSeparate(String1, String2, Separator);

			return Concat(String1, String2, Separator, separate);
		}

		public static string Suffix(this string String1, string String2, char Separator) {
			bool separate = CanSeparate(String1, String2, Separator);

			return Concat(String1, String2, Separator, separate);
		}

		public static string Prefix(this string String1, string String2, string Separator = null) {
			bool separate = CanSeparate(String1, String2, Separator);

			return Concat(String2, String1, Separator, separate);
		}

		public static string Prefix(this string String1, string String2, char Separator) {
			bool separate = CanSeparate(String1, String2, Separator);

			return Concat(String2, String1, Separator, separate);
		}

		private delegate string Parser(object Obj);

		private static IDictionary<Type, Parser> dict = new Dictionary<Type, Parser> {
			{ typeof(bool), o => (bool)o ? "true" : "false" }
			, { typeof(string), o => "\"" + o + "\""  }
			, { typeof(char), o => "'" + o + "'"  }
		};

		private static string GetFormattedValue(object o) {
			if (null == o) {
				return "null";
			}

			Type t = o.GetType();
			return dict.ContainsKey(t) ? dict[t](o) : o.ToString();
		}

		public static string AsString(object o, Access? viewAccess = null, bool showNameSpace = false) {
			if (null == o) {
				return "null";
			}

			Type t = o.GetType();

			showNameSpace &= !string.IsNullOrWhiteSpace(t.Namespace);
			string nameSpace = showNameSpace ? (t.Namespace + ".") : "";
			string properties = nameSpace + t.Name + "\n";

			BindingFlags flags = BindingFlags.Instance | BindingFlags.Static;
			switch (viewAccess) {
				case Access.Public: flags |= BindingFlags.Public; break;
				case Access.Private: flags |= BindingFlags.NonPublic; break;
				default: flags |= BindingFlags.Public | BindingFlags.NonPublic; break;
			}

			PropertyInfo[] pArr = t.GetProperties(flags);

			for (int i = 0; i < pArr.Length; ++i) {
				PropertyInfo p = pArr[i];

				object oVal = p.GetValue(o, null);
				string val = GetFormattedValue(oVal);

				string access = 0 == p.GetAccessors().Count() ? "private" : "public";

				string type = showNameSpace ? p.PropertyType.FullName : p.PropertyType.Name;

				properties += "- " + access + " " + type + " " + p.Name + " = " + val + "\n";
			}

			return properties;
		}
	}
}

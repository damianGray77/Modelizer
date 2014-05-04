using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools {
	public static class ParseHelper {
		private delegate object Parser(string val);								// Internal generic parser function
		private delegate bool Parser<T>(string str, out T val);		// TryParse method signature

		private class ParserList : Dictionary<Type, Parser> {
			public ParserList AddParser<T>(Parser<T> p) where T : struct, IComparable, IConvertible {
				Add(typeof(T), o => TryParse<T>(p, o));
				return this;
			}
		}

		private static ParserList list = new ParserList()
			.AddParser<bool>(bool.TryParse)
			.AddParser<byte>(byte.TryParse)
			.AddParser<sbyte>(sbyte.TryParse)
			.AddParser<char>(char.TryParse)
			.AddParser<short>(short.TryParse)
			.AddParser<int>(int.TryParse)
			.AddParser<long>(long.TryParse)
			.AddParser<ushort>(ushort.TryParse)
			.AddParser<uint>(uint.TryParse)
			.AddParser<ulong>(ulong.TryParse)
			.AddParser<float>(float.TryParse)
			.AddParser<double>(double.TryParse)
			.AddParser<decimal>(decimal.TryParse)
			.AddParser<DateTime>(DateTime.TryParse)
		;

		/// <summary>Casts from a string to a primitive data type, returns null on cast failure</summary>
		/// <typeparam name="T">Any primitive type that has a TryParse method</typeparam>
		/// <param name="val">Any string value</param>
		/// <returns>Returns val casted to T, or null if failed</returns>
		public static T? To<T>(this string val) where T : struct, IComparable, IConvertible {
			Type t = typeof(T);

			return list.ContainsKey(t)
				? list[t](val) as T?
				: TryEnumParse<T>(val)
			;
		}

		private static T? TryParse<T>(Parser<T> Parser, string val) where T : struct, IComparable, IConvertible {
			T n; return Parser(val, out n) ? n as T? : null;
		}

		private static T? TryEnumParse<T>(string val) where T : struct, IComparable, IConvertible {
			T n; return Enum.TryParse<T>(val, out n) ? n as T? : null;
		}
	}
}

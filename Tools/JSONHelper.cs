using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Tools {
	public class JSON<T> {
		private T _data;
		public T Data {
			get { return _data; }
			set {
				_data = value;
				_jsonString = value.ToJSON();
			}
		}

		private string _jsonString;
		public string JSONString {
			get { return _jsonString; }
			set {
				_jsonString = value;
				_data = value.FromJSON<T>();
			}
		}

		public JSON(string val) {
			JSONString = val;
		}

		public JSON(T val) {
			Data = val;
		}

		public static implicit operator JSON<T>(string val) {
			return new JSON<T>(val);
		}

		public static implicit operator JSON<T>(T val) {
			return new JSON<T>(val);
		}

		public static implicit operator string(JSON<T> val) {
			return val.JSONString;
		}

		public static implicit operator T(JSON<T> val) {
			return val.Data;
		}
	}

	public static class JSONHelper {
		/// <summary>
		/// Convert an object T type to a string of JSON
		/// </summary>
		/// <param name="val">Object to convert to JSON</param>
		/// <returns></returns>
		public static string ToJSON<T>(this T val) {
			JavaScriptSerializer _serializer = new JavaScriptSerializer {
				MaxJsonLength = int.MaxValue
			};

			return _serializer.Serialize(val);
		}

		/// <summary>
		/// Convert a string of JSON to object T type
		/// </summary>
		/// <param name="val">JSON string to convert from</param>
		/// <returns></returns>
		public static T FromJSON<T>(this string val) {
			JavaScriptSerializer _serializer = new JavaScriptSerializer {
				MaxJsonLength = int.MaxValue
			};

			return _serializer.Deserialize<T>(val);
		}
	}
}

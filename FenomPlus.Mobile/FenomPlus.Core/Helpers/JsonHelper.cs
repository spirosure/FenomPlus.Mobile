using System;
using System.IO;
using System.Reflection;

namespace FenomPlus.Core.Helpers
{
	public static class JsonHelper
	{
		/// <summary>
		/// Loads the resources from assembly.
		/// </summary>
		/// <returns>The resources from assembly.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T LoadResourcesFromAssembly<T>() where T : class, new()
		{
			return JsonHelper.LoadResourcesFromAssembly<T>(typeof(T).Name);
		}

		/// <summary>
		/// Loads the resources from assembly.
		/// </summary>
		/// <returns>The resources from assembly.</returns>
		/// <param name="fileName">File name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T LoadResourcesFromAssembly<T>(string fileName) where T : class, new()
		{
			Assembly assembly = typeof(T).GetTypeInfo().Assembly;
			string jsonResourceName = fileName;
			string[] resources = assembly.GetManifestResourceNames();

			string fullResourcePath = Array.Find(resources, name => name.Contains(jsonResourceName));

			using (Stream stream = assembly.GetManifestResourceStream(fullResourcePath))
			{
				return DeserializeStream<T>(stream);
			}
		}

		/// <summary>
		/// Serializes the stream.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="s">S.</param>
		public static void SerializeStream(object value, Stream s)
		{
			using (StreamWriter writer = new StreamWriter(s))
			using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
			{
				JsonSerializer ser = new JsonSerializer();
				ser.Serialize(jsonWriter, value);
				jsonWriter.Flush();
			}
		}

		/// <summary>
		/// Deserializes the stream.
		/// </summary>
		/// <returns>The stream.</returns>
		/// <param name="s">S.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T DeserializeStream<T>(Stream s)
		{
			using (StreamReader reader = new StreamReader(s))
			using (JsonTextReader jsonReader = new JsonTextReader(reader))
			{
				JsonSerializer ser = new JsonSerializer();
				return ser.Deserialize<T>(jsonReader);
			}
		}
	}
}
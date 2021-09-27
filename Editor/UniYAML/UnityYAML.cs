using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using UnityEngine;
using YamlDotNet.Serialization;

namespace AssetLens.YAML
{
	internal class UnityYAML
	{
		private readonly Dictionary<ulong, YAMLObject> objects = new Dictionary<ulong, YAMLObject>();
		
		private string version;
		private string[] tag;
		private string classId;
		private bool stripped;
		
		private EClassIdReference ClassId;

		private Dictionary<EClassIdReference, Type> typeMap = new Dictionary<EClassIdReference, Type>();

		public void Read(string[] contents)
		{
			var types = Assembly
				.GetAssembly(typeof(YAMLObject))
				.GetTypes()
				.Where(e => e.IsSubclassOf(typeof(YAMLObject))
				)
				.OrderBy(e => e.Name);

			foreach (Type type in types)
			{
				ClassIDAttribute attribute = type.GetCustomAttribute<ClassIDAttribute>();
				if (attribute != null)
				{
					typeMap[attribute.id] = type;
				}
			}
				
			objects.Clear();

			StringBuilder sb = new StringBuilder();
			ulong instanceId = 0;

			bool isFirstLine = false;
			
			foreach (var content in contents)
			{
				if (content.StartsWith("%"))
				{
					if (content.Contains("YAML"))
					{
						version = content.Split(' ')[1];
					}
					else if (content.Contains("TAG"))
					{
						int index = content.IndexOf("tag:", StringComparison.Ordinal);
						tag = content.Substring(index+4).Replace(":", "").Split(',');
					}
				}
				else if (content.StartsWith("---"))
				{
					isFirstLine = true;
					
					if (instanceId != 0)
					{
						IDeserializer serializer = new DeserializerBuilder()
							.IgnoreUnmatchedProperties()
							.Build();

						Type type = typeof(YAMLObject);
						if (typeMap.ContainsKey(ClassId))
						{
							type = typeMap[ClassId];
						}

						YAMLObject deserialized = (YAMLObject)serializer.Deserialize(sb.ToString(), type);
						
						deserialized.content = sb.ToString();
						deserialized.stripped = stripped;

						objects.Add(instanceId, deserialized);

						sb.Clear();
						stripped = false;
					}

					stripped = content.Contains("stripped");

					// @TODO :: convert to regex
					string[] block = content.Split('&');
					string id = block[1].Split(' ')[0].Trim(' ');

					if (!ulong.TryParse(id, out instanceId))
					{
						Debug.LogError($"Failed to parse instanceId : {id}, {content}");
					}

					int index = content.IndexOf("!u!", StringComparison.Ordinal);
					classId = content.Substring(index + 3).Split(' ')[0];

					if (!ulong.TryParse(classId, out var ulongClassId))
					{
						Debug.LogError($"Failed to pare ClassId : {classId}, {content}");
					}

					ClassId = (EClassIdReference)ulongClassId;
				}
				else
				{
					if (isFirstLine)
					{
						isFirstLine = false;
						continue;
					}
					
					sb.AppendLine(content);
				}
			}

			string tags = string.Empty;
			foreach (string t in tag)
			{
				tags += t;
				tags += ", ";
			}
			
			Debug.Log($"Result : {objects.Keys.Count}, version: {version}, tags: {tags}");

			foreach (YAMLObject objectsValue in objects.Values)
			{
				if (objectsValue is GameObject_YAML g)
				{
					Debug.Log(JsonUtility.ToJson(g));
				}
			}
		}
	}
}
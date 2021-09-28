using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AssetLens.YAML
{
	using CodeGen;
	
	public static class UniYAMLUtil
	{
		private const string namespaceName = "AssetLens.YAML";
		
#if DEBUG_ASSETLENS
		[MenuItem("Tools/YAML/Create Class ID Enum")]
		private static void CreateClassIdEnums()
		{
			const string className = "EClassIdReference";
			
			string path = Application.dataPath + "/classid.txt";
			string[] textContent = File.ReadAllLines(path);
			
			CodeFactory code = new CodeFactory();

			using (code.NewNamespace(namespaceName))
			{
				code.AppendLine("/// https://docs.unity3d.com/Manual/ClassIDReference.html");
				
				using (var e = code.NewEnum(className, EEnumAccessModifier.Public, EEnumBaseType.Ulong))
				{
					foreach (string content in textContent)
					{
						var block = content.Split('|');
				
						var indexString = block[0];
						var name = block[1];

						var space = 52 - name.Length;
						
						e.Add($"@{name}",indexString, space);
					}
				}	
			}

			string filePath = Path.GetFullPath("Packages/com.calci.uniyaml") + $"/Editor/UniYAML/{className}.cs";
			
			File.WriteAllText(filePath, code.ToString());
			
			AssetDatabase.ImportAsset(filePath);
			AssetDatabase.SaveAssets();
		}

		[MenuItem("Tools/YAML/Read Sample")]
		private static void ReadSample()
		{
			string path =
				@"C:\Projects\Unity Engine\Portfolio\AutoChessFramework\ACF.Unity\Assets\Content\Maps\Shared\Bootstrap.unity";

			var stringContent = File.ReadAllLines(path);
			UnityYAML yamlObject = new UnityYAML();
			
			yamlObject.Read(stringContent);
		}

		[MenuItem("Tools/YAML/Generate ResolverClass")]
		private static void GenerateResolver()
		{
			const string className = "YAMLTypeResolver";

			CodeFactory code = new CodeFactory();
			
			code.AddUsing("YamlDotNet.Serialization");

			using (code.NewNamespace(namespaceName))
			{
				using (ClassBuilder c = code.NewClass(className, EClassAccessModifier.Public, EClassInheritModifier.Static))
				{
					var types = Assembly
						.GetAssembly(typeof(YAMLObject))
						.GetTypes()
						.Where(e => e.IsSubclassOf(typeof(YAMLObject))
						)
						.OrderBy(e => e.Name);
					
					code.AppendLine($"public static YAMLObject Deserialize(IDeserializer serializer, EClassIdReference classId, string yamlContent)");
					code.OpenBrace();
					{
						foreach (Type type in types)
						{
							ClassIDAttribute attribute = type.GetCustomAttribute<ClassIDAttribute>();
							EClassIdReference classId = attribute?.id ?? EClassIdReference.Object;
							
							string returnTypeName = type.FullName;
						
							code.AppendLine($"if (classId == EClassIdReference.@{classId})");
							code.OpenBrace();
							{
								code.AppendLine($"return serializer.Deserialize<{returnTypeName}>(yamlContent);");
							}
							code.CloseBrace();
						}	
						
						code.AppendLine("return default;");
					}
					code.CloseBrace();
				}	
			}
			
			string filePath = Path.GetFullPath("Packages/com.calci.uniyaml") + $"/Editor/UniYAML/{className}.cs";
			
			File.WriteAllText(filePath, code.ToString());
			
			AssetDatabase.ImportAsset(filePath);
			AssetDatabase.SaveAssets();
		}

		[MenuItem("Tools/YAML/Generate Missing Classess")]
		private static void GenerateMissingClass()
		{
			foreach (EClassIdReference classId in Enum.GetValues(typeof(EClassIdReference)))
			{
				string className = $"{classId}_YAML";
				string filePath = Path.GetFullPath("Packages/com.calci.uniyaml") + $"/Editor/UniYAML/Object/{className}.cs";

				if (File.Exists(filePath)) continue;
				
				CodeFactory code = new CodeFactory();
				code.AddUsing("System");

				using (code.NewNamespace(namespaceName))
				{
					code.AppendLine("[Serializable]");
					code.AppendLine($"[ClassID(EClassIdReference.@{classId})]");
					
					using (ClassBuilder c = code.NewChildClass(className, "YAMLObject"))
					{
						
					}
				}
				
				File.WriteAllText(filePath, code.ToString());
			}
			
			AssetDatabase.Refresh();
		}
#endif
	}
}

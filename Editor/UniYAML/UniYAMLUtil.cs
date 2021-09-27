using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AssetLens.YAML
{
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

			// StringBuilder sb = new StringBuilder();
			//
			// sb.AppendLine($"namespace {namespaceName}");
			// sb.AppendLine("{");
			// sb.AppendLine("\t/// https://docs.unity3d.com/Manual/ClassIDReference.html");
			// sb.AppendLine($"\tpublic enum {className} : ulong");
			// sb.AppendLine("\t{");
			//
			// foreach (string content in textContent)
			// {
			// 	var block = content.Split('|');
			// 	
			// 	var indexString = block[0];
			// 	var name = block[1];
			//
			// 	sb.Append("\t\t@");
			// 	sb.Append(name);
			//
			// 	int count = name.Length;
			// 	for (int i = count; i < 40; i++)
			// 	{
			// 		sb.Append(" ");
			// 	}
			// 	sb.Append(" = ");
			//
			// 	sb.Append(indexString);
			// 	sb.Append(",\n");
			// }
			//
			// sb.AppendLine("\t}");
			// sb.AppendLine("}");
			
			CodeFactory code = new CodeFactory();

			using (code.NewNamespace(namespaceName))
			{
				using (var e = code.NewEnum(className, CodeFactory.EEnumAccessModifier.Public, CodeFactory.EEnumBaseType.Ulong))
				{
					foreach (string content in textContent)
					{
						var block = content.Split('|');
				
						var indexString = block[0];
						var name = block[1];

						var space = 40 - name.Length;
						
						e.Add(name, indexString, space);
					}
				}	
			}

			string filePath = Application.dataPath + $"/{className}.cs";
			
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

			using (code.NewNamespace(namespaceName))
			{
				using (var klass = code.NewClass(className, CodeFactory.EClassAccessModifier.Public, CodeFactory.EClassInheritModifier.Sealed))
				{
				
				}	
			}
			
			Debug.Log(code.ToString());
		}
#endif
	}
}

namespace AssetLens
{ }
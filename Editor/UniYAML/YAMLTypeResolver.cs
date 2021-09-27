using YamlDotNet.Serialization;

namespace AssetLens.YAML
{
	public static class YAMLTypeResolver
	{
		public static YAMLObject Deserialize(IDeserializer serializer, EClassIdReference classId, string yamlContent)
		{
			if (classId == EClassIdReference.@GameObject)
			{
				return serializer.Deserialize<AssetLens.YAML.GameObject_YAML>(yamlContent);
			}

			return default;
		}
	}
}

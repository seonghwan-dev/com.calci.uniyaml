using System;

namespace AssetLens.YAML
{
	[Serializable]
	[ClassID(EClassIdReference.GameObject)]
	public class GameObject_YAML : YAMLObject
	{
		public int serializedVersion;
		
		public InstanceRegistry m_CorrespondingSourceObject;
		public InstanceRegistry m_PrefabInstance;
		public InstanceRegistry m_PrefabAsset;
		public ComponentRegistry[] m_Component;
		public int m_Layer;
		public string m_Name;
		public string m_TagString;
		public int m_NavMeshLayer;
		public int m_StaticEditorFlags;
		public int m_IsActive;	
	}
}
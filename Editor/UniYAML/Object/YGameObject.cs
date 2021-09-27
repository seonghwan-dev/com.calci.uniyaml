using System;
using System.Collections.Generic;

namespace AssetLens.YAML
{
	[Serializable]
	[ClassID(EClassIdReference.GameObject)]
	public class YGameObject : YAMLObject
	{
		public int m_ObjectHideFlags;
		public InstanceRegistry m_CorrespondingSourceObject;
		public InstanceRegistry m_PrefabInstance;
		public InstanceRegistry m_PrefabAsset;
		public int serializedVersion;
		public List<InstanceRegistry> m_Component;
		public int m_Layer;
		public string m_Name;
		public string m_TagString;
		public int m_NavMeshLayer;
		public int m_StaticEditorFlags;
		public int m_IsActive;	
		
		// public Internal GameObject;
		//
		// public class Internal
		// {
		// 	public int m_ObjectHideFlags;
		// 	public InstanceRegistry m_CorrespondingSourceObject;
		// 	public InstanceRegistry m_PrefabInstance;
		// 	public InstanceRegistry m_PrefabAsset;
		// 	public int serializedVersion;
		// 	public List<InstanceRegistry> m_Component;
		// 	public int m_Layer;
		// 	public string m_Name;
		// 	public string m_TagString;
		// 	public int m_NavMeshLayer;
		// 	public int m_StaticEditorFlags;
		// 	public int m_IsActive;	
		// }
	}
}
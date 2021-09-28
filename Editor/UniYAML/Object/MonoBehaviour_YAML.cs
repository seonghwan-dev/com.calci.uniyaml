using System;

namespace AssetLens.YAML
{
	[Serializable]
	[ClassID(EClassIdReference.@MonoBehaviour)]
	public class MonoBehaviour_YAML : YAMLObject
	{
		/*
		   m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 5628819}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: 5f7201a12d95ffc409449d95f23cf332, type: 3}
  m_Name: 
  m_EditorClassIdentifier: 
		 */

		public InstanceRegistry m_CorrespondingSourceObject;
		public InstanceRegistry m_PrefabInstance;
		public InstanceRegistry m_PrefabAsset;
		public InstanceRegistry m_GameObject;
		public int m_Enabled;
		public int m_EditorHideFlags;
		public FileRegistry m_Script;
		public string m_Name;
		public string m_EditorClassIdentifier;
	}
}

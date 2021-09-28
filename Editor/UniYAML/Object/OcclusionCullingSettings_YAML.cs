using System;

namespace AssetLens.YAML
{
	[Serializable]
	[ClassID(EClassIdReference.@OcclusionCullingSettings)]
	public class OcclusionCullingSettings_YAML : YAMLObject
	{
		public string m_SceneGUID;
		public OcclusionCullingData_YAML m_OcculsionCullingData;
	}
}

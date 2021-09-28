using System;

namespace AssetLens.YAML
{
	[Serializable]
	[ClassID(EClassIdReference.@RenderSettings)]
	public class RenderSettings_YAML : YAMLObject
	{
		/*
		 *
		 *   m_Fog: 0
  m_FogColor: {r: 0.5, g: 0.5, b: 0.5, a: 1}
  m_FogMode: 3
  m_FogDensity: 0.01
  m_LinearFogStart: 0
  m_LinearFogEnd: 300
  m_AmbientSkyColor: {r: 0.212, g: 0.227, b: 0.259, a: 1}
  m_AmbientEquatorColor: {r: 0.114, g: 0.125, b: 0.133, a: 1}
  m_AmbientGroundColor: {r: 0.047, g: 0.043, b: 0.035, a: 1}
  m_AmbientIntensity: 1
  m_AmbientMode: 0
  m_SubtractiveShadowColor: {r: 0.42, g: 0.478, b: 0.627, a: 1}
  m_SkyboxMaterial: {fileID: 10304, guid: 0000000000000000f000000000000000, type: 0}
  m_HaloStrength: 0.5
  m_FlareStrength: 1
  m_FlareFadeSpeed: 3
  m_HaloTexture: {fileID: 0}
  m_SpotCookie: {fileID: 10001, guid: 0000000000000000e000000000000000, type: 0}
  m_DefaultReflectionMode: 0
  m_DefaultReflectionResolution: 128
  m_ReflectionBounces: 1
  m_ReflectionIntensity: 1
  m_CustomReflection: {fileID: 0}
  m_Sun: {fileID: 0}
  m_IndirectSpecularColor: {r: 0.18154702, g: 0.22719009, b: 0.30740646, a: 1}
  m_UseRadianceAmbientProbe: 0
		 */
		
		public int m_Fog;
		public Color_YAML m_FogColor;
		public int m_FogMode;
		public float m_FogDensity;
		public float m_LinearFogStart;
		public float m_LinearFogEnd;
		public Color_YAML m_AmbientSkyColor;
		public Color_YAML m_AmbientEquatorColor;
		public Color_YAML m_AmbientGroundColor;
		public float m_AmbientIntensity;
		public int m_AmbientMode;
		public Color_YAML m_SubtractiveShadowColor;
		public FileRegistry m_SkyboxMaterial;
		public int m_HaloStrength;
		public int m_FlareStrength;
		public int m_FlareFadeSpeed;
		public InstanceRegistry m_HaloTexture;
		public FileRegistry m_SpotCookie;
		public int m_DefaultReflectionMode;
		public int m_DefaultReflectionResolution;
		public int m_ReflectionBounces;
		public float m_ReflectionIntensity;
		public InstanceRegistry m_CustomReflection;
		public InstanceRegistry m_Sun;
		public Color_YAML m_IndirectSpecularColor;
		public int m_UseRadianceAmbientProbe;
	}
}

using System;
using UnityEngine;

namespace AssetLens.YAML
{
	[Serializable]
	public class InstanceRegistry
	{
		public ulong fileID;
	}
	
	
	namespace Util
	{
		static class YAMLUtilities
		{
			public static string ToYAML(this Quaternion v) => FormattableString.Invariant($"{{x: {v.x}, y: {v.y}, z: {v.z}, w: {v.w}}}");
			public static string ToYAML(this Vector3 v) => FormattableString.Invariant($"{{x: {v.x}, y: {v.y}, z: {v.z}}}");
			public static string ToYAML(this Color v) => FormattableString.Invariant($"{{r: {v.r}, g: {v.g}, b: {v.b}, a: {v.a}}}");
		}
	}

}
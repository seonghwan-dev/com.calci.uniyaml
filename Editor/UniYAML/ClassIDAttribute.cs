using System;

namespace AssetLens.YAML
{
	public class ClassIDAttribute : Attribute
	{
		public EClassIdReference id;
		
		public ClassIDAttribute(EClassIdReference id)
		{
			this.id = id;
		}
	}
}
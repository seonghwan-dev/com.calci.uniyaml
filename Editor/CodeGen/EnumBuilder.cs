namespace AssetLens.CodeGen
{
	public class EnumBuilder : Builder
	{
		public EnumBuilder(CodeFactory code, string name, EEnumAccessModifier access,
			EEnumBaseType baseType) : base(code)
		{
				
			code.AppendLine($"{access.ToString().ToLower()} enum {name} : {baseType.ToString().ToLower()}");
			code.AppendLine("{");
			code.IncrementIndent();
		}

		public void Add(string name)
		{
				
		}

		public void Add(string name, string value, int space = 0)
		{
			for (int i = 0; i < space; i++)
			{
				name += " ";
			}

			code.AppendLine($"{name}= {value},");
		}
	}
}
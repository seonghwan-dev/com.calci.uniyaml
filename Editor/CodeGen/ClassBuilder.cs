namespace AssetLens.CodeGen
{
	public class ClassBuilder : Builder
	{
		public ClassBuilder(CodeFactory code, string name, EClassAccessModifier access, 
			EClassInheritModifier inherit) : base(code)
		{
			string inh = inherit == EClassInheritModifier.None ? string.Empty : inherit.ToString().ToLower() + " ";
				
			code.AppendLine($"{access.ToString().ToLower()} {inh}class {name}");
			code.AppendLine("{");
			code.IncrementIndent();
		}
			
		public ClassBuilder(CodeFactory code, string name, string parent, EClassAccessModifier access, 
			EClassInheritModifier inherit) : base(code)
		{
			string inh = inherit == EClassInheritModifier.None ? string.Empty : inherit.ToString().ToLower() + " ";
				
			code.AppendLine($"{access.ToString().ToLower()} {inh}class {name} : {parent}");
			code.AppendLine("{");
			code.IncrementIndent();
		}

		public void Field(string type, string name)
		{
				
		}

		public void Field<T>(T type, string name, T defaultValue)
		{
				
		}

		public void Property(string type, string name, bool get = true, bool set = false)
		{
				
		}

		public void Method(string name, string returnType, params (string type, string name)[] parameters)
		{
				
		}

		public void Void(string name, params (string type, string name)[] parameters)
		{
				
		}
	}
}
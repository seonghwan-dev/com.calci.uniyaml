using System.Text;

namespace AssetLens.CodeGen
{
	public class CodeFactory
	{
		public int indent = 0;
		
		private readonly StringBuilder sb = new StringBuilder(1024);
		private readonly StringBuilder usedNamespaces = new StringBuilder(1024);

		public void IncrementIndent()
		{
			indent++;
		}

		public void DecrementIndent()
		{
			indent--;
		}

		public void AppendLine(string msg)
		{
			for (int i = 0; i < indent; i++)
			{
				sb.Append("\t");
			}

			sb.Append(msg);
			sb.Append("\n");
		}

		public void OpenBrace()
		{
			AppendLine("{");
			IncrementIndent();
		}

		public void CloseBrace()
		{
			DecrementIndent();
			AppendLine("}");
		}

		public override string ToString()
		{
			if (usedNamespaces.Length > 0)
			{
				return usedNamespaces.ToString() + "\n" + sb.ToString();
			}

			return sb.ToString();
		}

		public void AddUsing(string name)
		{
			usedNamespaces.AppendLine($"using {name};");
		}
		
		public Namespace NewNamespace(string name)
		{
			return new Namespace(this, name);
		}

		public ClassBuilder NewClass(string name, 
			EClassAccessModifier access = EClassAccessModifier.Public, 
			EClassInheritModifier inherit = EClassInheritModifier.None)
		{
			return new ClassBuilder(this, name, access, inherit);
		}
		
		public ClassBuilder NewChildClass(string name, string parent,
			EClassAccessModifier access = EClassAccessModifier.Public, 
			EClassInheritModifier inherit = EClassInheritModifier.None)
		{
			return new ClassBuilder(this, name, parent, access, inherit);
		}

		public EnumBuilder NewEnum(string name,
			EEnumAccessModifier access = EEnumAccessModifier.Public,
			EEnumBaseType type = EEnumBaseType.Int)
		{
			return new EnumBuilder(this, name, access, type);
		}
	}
}
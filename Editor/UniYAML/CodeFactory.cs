using System;
using System.Text;

namespace AssetLens
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
		
		public class Namespace : Builder
		{
			public Namespace(CodeFactory code, string name) : base(code)
			{
				code.AppendLine($"namespace {name}");
				code.AppendLine("{");
				code.IncrementIndent();
			}
		}

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
		}

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

				code.AppendLine($"{name} = {value};");
			}
		}

		public class Builder : IDisposable
		{
			protected readonly CodeFactory code;
			protected Builder(CodeFactory code)
			{
				this.code = code;
			}
			
			public virtual void Dispose()
			{
				code.DecrementIndent();
				code.AppendLine("}");
			}
		}

		public enum EClassAccessModifier
		{
			Public,
			Internal,
			Private,
		}

		public enum EClassInheritModifier
		{
			None,
			Virtual,
			Abstract,
			Sealed,
			Static,
		}

		public enum EEnumAccessModifier
		{
			Private,
			Public,
			Internal,
		}

		public enum EEnumBaseType
		{
			Byte,
			Sbyte,
			Short,
			Ushort,
			Int,
			Uint,
			Long,
			Ulong,
		}
	}
}
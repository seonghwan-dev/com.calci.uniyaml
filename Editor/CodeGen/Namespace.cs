namespace AssetLens.CodeGen
{
	public class Namespace : Builder
	{
		public Namespace(CodeFactory code, string name) : base(code)
		{
			code.AppendLine($"namespace {name}");
			code.AppendLine("{");
			code.IncrementIndent();
		}
	}
}
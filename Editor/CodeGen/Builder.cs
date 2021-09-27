using System;

namespace AssetLens.CodeGen
{
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
}
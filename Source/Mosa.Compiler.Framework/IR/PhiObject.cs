// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.IR;

/// <summary>
/// PhiObject
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.IR.BaseIRInstruction" />
public sealed class PhiObject : BaseIRInstruction
{
	public PhiObject()
		: base(0, 0)
	{
	}

	public override bool VariableOperands => true;
}

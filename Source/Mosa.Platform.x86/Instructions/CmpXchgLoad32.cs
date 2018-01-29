// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// CmpXchgLoad32
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed class CmpXchgLoad32 : X86Instruction
	{
		public CmpXchgLoad32()
			: base(1, 4)
		{
		}

		public override bool IsMemoryRead { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == DefaultResultCount || VariableOperands);
			System.Diagnostics.Debug.Assert(node.OperandCount == DefaultOperandCount || VariableOperands);

			StaticEmitters.EmitCmpXchgLoad32(node, emitter);
		}

		// The following is used by the automated code generator.

		public override string __staticEmitMethod { get { return "StaticEmitters.Emit%"; } }
	}
}


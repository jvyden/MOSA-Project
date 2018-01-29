// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// BranchGreaterOrEqual
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed class BranchGreaterOrEqual : X86Instruction
	{
		public static readonly byte[] opcode = new byte[] { 0x0F, 0x08 };

		public BranchGreaterOrEqual()
			: base(0, 0)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == DefaultResultCount || VariableOperands);
			System.Diagnostics.Debug.Assert(node.OperandCount == DefaultOperandCount || VariableOperands);

			emitter.Write(opcode);
		}

		// The following is used by the automated code generator.

		public override byte[] __opcode { get { return opcode; } }
	}
}


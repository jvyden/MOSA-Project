// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Invlpg
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed class Invlpg : X86Instruction
	{
		public Invlpg()
			: base(0, 1)
		{
		}

		public override bool HasIRUnspecifiedSideEffect { get { return true; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == DefaultResultCount);
			System.Diagnostics.Debug.Assert(node.OperandCount == DefaultOperandCount);

			StaticEmitters.EmitInvlpg(node, emitter);
		}

		// The following is used by the automated code generator.

		public override string __staticEmitMethod { get { return "StaticEmitters.Emit%"; } }
	}
}


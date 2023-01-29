// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions;

/// <summary>
/// Cvttss2si32
/// </summary>
/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
public sealed class Cvttss2si32 : X86Instruction
{
	internal Cvttss2si32()
		: base(1, 1)
	{
	}

	public override void Emit(InstructionNode node, OpcodeEncoder opcodeEncoder)
	{
		System.Diagnostics.Debug.Assert(node.ResultCount == 1);
		System.Diagnostics.Debug.Assert(node.OperandCount == 1);

		opcodeEncoder.Append8Bits(0xF3);
		opcodeEncoder.Append8Bits(0x0F);
		opcodeEncoder.Append8Bits(0x2C);
		opcodeEncoder.Append2Bits(0b11);
		opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
		opcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
	}
}

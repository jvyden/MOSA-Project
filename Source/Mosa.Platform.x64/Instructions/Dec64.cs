// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions;

/// <summary>
/// Dec64
/// </summary>
/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
public sealed class Dec64 : X64Instruction
{
	internal Dec64()
		: base(1, 1)
	{
	}

	public override bool IsZeroFlagModified => true;

	public override bool IsSignFlagModified => true;

	public override bool IsOverflowFlagModified => true;

	public override bool IsParityFlagModified => true;

	public override void Emit(InstructionNode node, OpcodeEncoder opcodeEncoder)
	{
		System.Diagnostics.Debug.Assert(node.ResultCount == 1);
		System.Diagnostics.Debug.Assert(node.OperandCount == 1);
		System.Diagnostics.Debug.Assert(node.Result.IsCPURegister);
		System.Diagnostics.Debug.Assert(node.Operand1.IsCPURegister);
		System.Diagnostics.Debug.Assert(node.Result.Register == node.Operand1.Register);

		opcodeEncoder.SuppressByte(0x40);
		opcodeEncoder.Append4Bits(0b0100);
		opcodeEncoder.Append1Bit(0b0);
		opcodeEncoder.Append1Bit(0b0);
		opcodeEncoder.Append1Bit(0b0);
		opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
		opcodeEncoder.Append8Bits(0xFF);
		opcodeEncoder.Append2Bits(0b11);
		opcodeEncoder.Append3Bits(0b001);
		opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
	}
}

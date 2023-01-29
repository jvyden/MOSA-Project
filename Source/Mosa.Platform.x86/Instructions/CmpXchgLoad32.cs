// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions;

/// <summary>
/// CmpXChgLoad32
/// </summary>
/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
public sealed class CmpXChgLoad32 : X86Instruction
{
	internal CmpXChgLoad32()
		: base(1, 4)
	{
	}

	public override bool IsMemoryRead => true;

	public override bool IsZeroFlagUnchanged => true;

	public override bool IsZeroFlagUndefined => true;

	public override bool IsCarryFlagUnchanged => true;

	public override bool IsCarryFlagUndefined => true;

	public override bool IsSignFlagUnchanged => true;

	public override bool IsSignFlagUndefined => true;

	public override bool IsOverflowFlagUnchanged => true;

	public override bool IsOverflowFlagUndefined => true;

	public override bool IsParityFlagUnchanged => true;

	public override bool IsParityFlagUndefined => true;

	public override void Emit(InstructionNode node, OpcodeEncoder opcodeEncoder)
	{
		System.Diagnostics.Debug.Assert(node.ResultCount == 1);
		System.Diagnostics.Debug.Assert(node.OperandCount == 4);

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 0 && node.Operand2.IsCPURegister && node.Operand3.IsConstantZero && node.GetOperand(3).IsCPURegister)
		{
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xB1);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.GetOperand(3).Register.RegisterCode);
			opcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
			return;
		}

		throw new Compiler.Common.Exceptions.CompilerException("Invalid Opcode");
	}
}

// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions;

/// <summary>
/// MovsxLoad16
/// </summary>
/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
public sealed class MovsxLoad16 : X64Instruction
{
	internal MovsxLoad16()
		: base(1, 2)
	{
	}

	public override bool IsMemoryRead => true;

	public override void Emit(InstructionNode node, OpcodeEncoder opcodeEncoder)
	{
		System.Diagnostics.Debug.Assert(node.ResultCount == 1);
		System.Diagnostics.Debug.Assert(node.OperandCount == 2);

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 5 && node.Operand2.IsConstantZero)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b01);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b101);
			opcodeEncoder.Append8Bits(0x00);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 5 && node.Operand2.IsCPURegister)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(node.Operand2.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b01);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b101);
			opcodeEncoder.Append8Bits(0x00);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4 && node.Operand2.IsConstantZero)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append3Bits(0b100);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4 && node.Operand2.IsConstant && node.Operand2.ConstantSigned32 >= -128 && node.Operand2.ConstantSigned32 <= 127)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b01);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append8BitImmediate(node.Operand2);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand1.Register.RegisterCode == 4 && node.Operand2.IsConstant)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b10);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append8BitImmediate(node.Operand2);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand2.IsCPURegister)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(node.Operand1.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b100);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Operand2.Register.RegisterCode);
			opcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand2.IsConstantZero)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Operand1.Register.RegisterCode >> 3);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand2.IsConstant && node.Operand2.ConstantSigned32 >= -128 && node.Operand2.ConstantSigned32 <= 127)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Operand1.Register.RegisterCode >> 3);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b01);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
			opcodeEncoder.Append8BitImmediate(node.Operand2);
			return;
		}

		if (node.Operand1.IsCPURegister && node.Operand2.IsConstant)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Operand1.Register.RegisterCode >> 3);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b10);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
			opcodeEncoder.Append32BitImmediate(node.Operand2);
			return;
		}

		if (node.Operand1.IsConstant && node.Operand2.IsConstantZero)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b101);
			opcodeEncoder.Append32BitImmediate(node.Operand1);
			return;
		}

		if (node.Operand1.IsConstant && node.Operand2.IsConstant)
		{
			opcodeEncoder.SuppressByte(0x40);
			opcodeEncoder.Append4Bits(0b0100);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(node.Result.Register.RegisterCode >> 3);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append1Bit(0b0);
			opcodeEncoder.Append8Bits(0x0F);
			opcodeEncoder.Append8Bits(0xBF);
			opcodeEncoder.Append2Bits(0b00);
			opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
			opcodeEncoder.Append3Bits(0b101);
			opcodeEncoder.Append32BitImmediateWithOffset(node.Operand1, node.Operand2);
			return;
		}

		throw new Compiler.Common.Exceptions.CompilerException("Invalid Opcode");
	}
}

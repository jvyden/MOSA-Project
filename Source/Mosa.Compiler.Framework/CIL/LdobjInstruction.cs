/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using Mosa.Compiler.MosaTypeSystem;
using System;

namespace Mosa.Compiler.Framework.CIL
{
	/// <summary>
	///
	/// </summary>
	public sealed class LdobjInstruction : UnaryInstruction
	{
		/// <summary>
		/// A fixed typeref for ldind.* instructions.
		/// </summary>
		private readonly MosaTypeCode? elementType;

		/// <summary>
		/// Initializes a new instance of the <see cref="LdobjInstruction"/> class.
		/// </summary>
		/// <param name="opcode">The opcode.</param>
		public LdobjInstruction(OpCode opcode)
			: base(opcode, 1)
		{
			switch (opcode)
			{
				case OpCode.Ldind_i1: elementType = MosaTypeCode.I1; break;
				case OpCode.Ldind_i2: elementType = MosaTypeCode.I2; break;
				case OpCode.Ldind_i4: elementType = MosaTypeCode.I4; break;
				case OpCode.Ldind_i8: elementType = MosaTypeCode.I8; break;
				case OpCode.Ldind_u1: elementType = MosaTypeCode.U1; break;
				case OpCode.Ldind_u2: elementType = MosaTypeCode.U2; break;
				case OpCode.Ldind_u4: elementType = MosaTypeCode.U4; break;
				case OpCode.Ldind_i: elementType = MosaTypeCode.I; break;
				case OpCode.Ldind_r4: elementType = MosaTypeCode.R4; break;
				case OpCode.Ldind_r8: elementType = MosaTypeCode.R8; break;
				case OpCode.Ldind_ref: elementType = MosaTypeCode.Object; break;
				case OpCode.Ldobj: elementType = null; break;
				default: throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(InstructionNode ctx, IInstructionDecoder decoder)
		{
			// Decode base classes first
			base.Decode(ctx, decoder);

			MosaType type = (elementType == null)
				? type = (MosaType)decoder.Instruction.Operand
				: type = decoder.TypeSystem.GetTypeFromTypeCode(elementType.Value);

			// Push the loaded value
			ctx.Result = LoadInstruction.CreateResultOperand(decoder, type);
			ctx.MosaType = type;
		}

		/// <summary>
		/// Validates the instruction operands and creates a matching variable for the result.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="compiler">The compiler.</param>
		public override void Resolve(Context ctx, BaseMethodCompiler compiler)
		{
			base.Resolve(ctx, compiler);

			// If we're ldind.i8, fix an IL deficiency that the result may be U8
			if (opcode == OpCode.Ldind_i8 && elementType.Value == MosaTypeCode.I8)
			{
				if (ctx.Operand1.Type.ElementType != null && ctx.Operand1.Type.ElementType.IsU8)
				{
					ctx.Result = compiler.CreateVirtualRegister(compiler.TypeSystem.BuiltIn.U8);
				}
			}
		}

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		/// <param name="context">The context.</param>
		public override void Visit(ICILVisitor visitor, Context context)
		{
			visitor.Ldobj(context);
		}
	}
}
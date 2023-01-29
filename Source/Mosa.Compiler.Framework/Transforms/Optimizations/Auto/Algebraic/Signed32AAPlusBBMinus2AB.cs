// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.Algebraic;

/// <summary>
/// Signed32AAPlusBBMinus2AB
/// </summary>
public sealed class Signed32AAPlusBBMinus2AB : BaseTransform
{
	public Signed32AAPlusBBMinus2AB() : base(IRInstruction.Sub32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Add32)
			return false;

		if (!context.Operand1.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand1.Definitions[0].Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.ShiftLeft32)
			return false;

		if (!context.Operand2.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.Definitions[0].Operand2.IsResolvedConstant)
			return false;

		if (context.Operand2.Definitions[0].Operand2.ConstantUnsigned64 != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand1))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand2.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1;

		var v1 = transform.AllocateVirtualRegister(transform.I4);
		var v2 = transform.AllocateVirtualRegister(transform.I4);

		context.SetInstruction(IRInstruction.Sub32, v1, t1, t2);
		context.AppendInstruction(IRInstruction.Sub32, v2, t1, t2);
		context.AppendInstruction(IRInstruction.MulSigned32, result, v2, v1);
	}
}

/// <summary>
/// Signed32AAPlusBBMinus2AB_v1
/// </summary>
public sealed class Signed32AAPlusBBMinus2AB_v1 : BaseTransform
{
	public Signed32AAPlusBBMinus2AB_v1() : base(IRInstruction.Sub32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Add32)
			return false;

		if (!context.Operand1.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand1.Definitions[0].Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.ShiftLeft32)
			return false;

		if (!context.Operand2.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.Definitions[0].Operand2.IsResolvedConstant)
			return false;

		if (context.Operand2.Definitions[0].Operand2.ConstantUnsigned64 != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand2.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand1))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1;

		var v1 = transform.AllocateVirtualRegister(transform.I4);
		var v2 = transform.AllocateVirtualRegister(transform.I4);

		context.SetInstruction(IRInstruction.Sub32, v1, t1, t2);
		context.AppendInstruction(IRInstruction.Sub32, v2, t1, t2);
		context.AppendInstruction(IRInstruction.MulSigned32, result, v2, v1);
	}
}

/// <summary>
/// Signed32AAPlusBBMinus2AB_v2
/// </summary>
public sealed class Signed32AAPlusBBMinus2AB_v2 : BaseTransform
{
	public Signed32AAPlusBBMinus2AB_v2() : base(IRInstruction.Sub32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Add32)
			return false;

		if (!context.Operand1.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand1.Definitions[0].Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.ShiftLeft32)
			return false;

		if (!context.Operand2.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.Definitions[0].Operand2.IsResolvedConstant)
			return false;

		if (context.Operand2.Definitions[0].Operand2.ConstantUnsigned64 != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand2.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand1))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1;

		var v1 = transform.AllocateVirtualRegister(transform.I4);
		var v2 = transform.AllocateVirtualRegister(transform.I4);

		context.SetInstruction(IRInstruction.Sub32, v1, t2, t1);
		context.AppendInstruction(IRInstruction.Sub32, v2, t2, t1);
		context.AppendInstruction(IRInstruction.MulSigned32, result, v2, v1);
	}
}

/// <summary>
/// Signed32AAPlusBBMinus2AB_v3
/// </summary>
public sealed class Signed32AAPlusBBMinus2AB_v3 : BaseTransform
{
	public Signed32AAPlusBBMinus2AB_v3() : base(IRInstruction.Sub32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Add32)
			return false;

		if (!context.Operand1.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand1.Definitions[0].Operand2.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Operand2.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.ShiftLeft32)
			return false;

		if (!context.Operand2.Definitions[0].Operand1.IsVirtualRegister)
			return false;

		if (!context.Operand2.Definitions[0].Operand2.IsResolvedConstant)
			return false;

		if (context.Operand2.Definitions[0].Operand2.ConstantUnsigned64 != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Operand1.Definitions[0].Instruction != IRInstruction.MulSigned32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand1))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand2.Definitions[0].Operand2))
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand1.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2.Definitions[0].Operand1;

		var v1 = transform.AllocateVirtualRegister(transform.I4);
		var v2 = transform.AllocateVirtualRegister(transform.I4);

		context.SetInstruction(IRInstruction.Sub32, v1, t2, t1);
		context.AppendInstruction(IRInstruction.Sub32, v2, t2, t1);
		context.AppendInstruction(IRInstruction.MulSigned32, result, v2, v1);
	}
}

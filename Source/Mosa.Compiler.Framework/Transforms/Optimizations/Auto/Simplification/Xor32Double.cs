// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.Simplification;

/// <summary>
/// Xor32Double
/// </summary>
public sealed class Xor32Double : BaseTransform
{
	public Xor32Double() : base(IRInstruction.Xor32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Or32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand2;

		context.SetInstruction(IRInstruction.Move32, result, t1);
	}
}

/// <summary>
/// Xor32Double_v1
/// </summary>
public sealed class Xor32Double_v1 : BaseTransform
{
	public Xor32Double_v1() : base(IRInstruction.Xor32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.Or32)
			return false;

		if (!AreSame(context.Operand1, context.Operand2.Definitions[0].Operand1))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand2.Definitions[0].Operand2;

		context.SetInstruction(IRInstruction.Move32, result, t1);
	}
}

/// <summary>
/// Xor32Double_v2
/// </summary>
public sealed class Xor32Double_v2 : BaseTransform
{
	public Xor32Double_v2() : base(IRInstruction.Xor32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Or32)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1;

		context.SetInstruction(IRInstruction.Move32, result, t1);
	}
}

/// <summary>
/// Xor32Double_v3
/// </summary>
public sealed class Xor32Double_v3 : BaseTransform
{
	public Xor32Double_v3() : base(IRInstruction.Xor32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.Or32)
			return false;

		if (!AreSame(context.Operand1, context.Operand2.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand2.Definitions[0].Operand1;

		context.SetInstruction(IRInstruction.Move32, result, t1);
	}
}

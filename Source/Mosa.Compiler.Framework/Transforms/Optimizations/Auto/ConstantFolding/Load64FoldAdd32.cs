// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.ConstantFolding;

/// <summary>
/// Load64FoldAdd32
/// </summary>
public sealed class Load64FoldAdd32 : BaseTransform
{
	public Load64FoldAdd32() : base(IRInstruction.Load64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Add32)
			return false;

		if (!IsResolvedConstant(context.Operand2))
			return false;

		if (!IsResolvedConstant(context.Operand1.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2;
		var t3 = context.Operand2;

		var e1 = transform.CreateConstant(Add32(To32(t2), To32(t3)));

		context.SetInstruction(IRInstruction.Load64, result, t1, e1);
	}
}

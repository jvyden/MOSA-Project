﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transform.Manual.ConstantFolding
{
	public sealed class Branch32 : BaseTransformation
	{
		public Branch32() : base(IRInstruction.Branch32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			if (!IsResolvedConstant(context.Operand2))
				return false;

			return IsNormal(context.ConditionCode);
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var target = context.BranchTargets[0];
			var block = context.Block;

			if (!Compare32(context))
			{
				context.SetNop();
			}
			else
			{
				context.SetInstruction(IRInstruction.Jmp, target);

				RemoveRestOfInstructions(context);
			}

			TransformContext.RemoveBlockFromPHIInstructions(block, target);
		}
	}
}

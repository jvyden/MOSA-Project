// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.CheckedConversion;

/// <summary>
/// CheckedConversionR4ToU64
/// </summary>
public sealed class CheckedConversionR4ToU64 : BaseCheckedConversionTransform
{
	public CheckedConversionR4ToU64() : base(IRInstruction.CheckedConversionR4ToU64, TransformType.Manual | TransformType.Transform)
	{
	}

	public override int Priority => -10;

	public override bool Match(Context context, TransformContext transform)
	{
		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		CallCheckOverflow(transform, context, "R4ToU8");
	}
}

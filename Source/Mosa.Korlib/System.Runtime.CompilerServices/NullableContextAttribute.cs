// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices;

[Embedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
public sealed class NullableContextAttribute : Attribute
{
	public readonly byte Flag;

	public NullableContextAttribute([In] byte flag) => this.Flag = flag;
}

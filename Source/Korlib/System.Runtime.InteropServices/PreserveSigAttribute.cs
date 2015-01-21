﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

namespace System.System.Runtime.InteropServices
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public sealed class PreserveSigAttribute : Attribute
	{
		public PreserveSigAttribute()
		{
		}
	}
}

// Copyright (c) MOSA Project. Licensed under the New BSD License.

// ReSharper disable once CheckNamespace
namespace System;

public readonly struct ConsoleKeyInfo : IEquatable<ConsoleKeyInfo>
{
    public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control)
    {
        this.KeyChar = keyChar;
        this.Key = key;

        this.Shift = shift;
        this.Alt = alt;
        this.Control = control;
    }

    public readonly char KeyChar;
    public readonly ConsoleKey Key;

    public readonly bool Shift;
    public readonly bool Alt;
    public readonly bool Control;

    public bool Equals(ConsoleKeyInfo other)
    {
	    return this.KeyChar == other.KeyChar && this.Key == other.Key && this.Shift == other.Shift && this.Alt == other.Alt && this.Control == other.Control;
    }

    public override bool Equals(object obj)
    {
	    return obj is ConsoleKeyInfo other && Equals(other);
    }

    public override int GetHashCode()
    {
	    return this.KeyChar;
    }

    public static bool operator ==(ConsoleKeyInfo left, ConsoleKeyInfo right)
    {
	    return left.Equals(right);
    }

    public static bool operator !=(ConsoleKeyInfo left, ConsoleKeyInfo right)
    {
	    return !left.Equals(right);
    }
}

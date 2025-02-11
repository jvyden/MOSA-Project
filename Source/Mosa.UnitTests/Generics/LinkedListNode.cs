﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.UnitTests.Generics;

/// <summary>
/// Represents a node in a LinkedList<T>. This class cannot be inherited.
/// </summary>
/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
internal sealed class LinkedListNode<T>
{
	internal LinkedList<T> list;
	internal LinkedListNode<T> next;
	internal LinkedListNode<T> previous;
	internal T value;

	/// <summary>
	/// Gets the LinkedList<T> that the LinkedListNode<T> belongs to.
	/// </summary>
	public LinkedList<T> List => list;

	/// <summary>
	/// Gets the next node in the LinkedList<T>.
	/// </summary>
	public LinkedListNode<T> Next => next;

	/// <summary>
	/// Gets the previous node in the LinkedList<T>.
	/// </summary>
	public LinkedListNode<T> Previous => previous;

	/// <summary>
	/// Gets the value contained in the node.
	/// </summary>
	public T Value
	{
		get => value;
		set => this.value = value;
	}

	/// <summary>
	/// Initializes a new instance of the LinkedListNode<T> class, containing the specified value.
	/// </summary>
	/// <param name="value">The value.</param>
	public LinkedListNode(T value)
	{
		this.value = value;
	}
}

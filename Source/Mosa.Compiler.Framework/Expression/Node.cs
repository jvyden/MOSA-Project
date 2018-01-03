﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.MosaTypeSystem;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mosa.Compiler.Framework.Expression
{
	public class Node
	{
		public NodeType NodeType { get; }

		public List<Node> ParentNodes { get; } = new List<Node>();

		public BaseInstruction Instruction { get; }
		public InstructionSize Size { get; } = InstructionSize.None;
		public ConditionCode ConditionCode { get; set; } = ConditionCode.Undefined;

		public string Name { get; }
		public int Index { get; }

		public ulong ConstantInteger { get; }
		public double ConstantDouble { get; }

		public PhysicalRegister PhysicalRegister { get; }

		public ExpressionNode ExpressionNode { get; }

		public Node(BaseInstruction instruction)
		{
			NodeType = NodeType.Instruction;
			Instruction = instruction;
		}

		public Node(BaseInstruction instruction, InstructionSize size)
		{
			NodeType = NodeType.Instruction;
			Instruction = instruction;
			Size = size;
		}

		public Node(BaseInstruction instruction, ConditionCode condition)
		{
			NodeType = NodeType.Instruction;
			Instruction = instruction;
			ConditionCode = condition;
		}

		public Node(BaseInstruction instruction, ConditionCode condition, InstructionSize size)
		{
			NodeType = NodeType.Instruction;
			Instruction = instruction;
			ConditionCode = condition;
			Size = size;
		}

		public Node(ulong constant)
		{
			NodeType = NodeType.FixedIntegerConstant;
			ConstantInteger = constant;
		}

		public Node(double constant)
		{
			NodeType = NodeType.FixedDoubleConstant;
			ConstantDouble = constant;
		}

		public Node(PhysicalRegister physicalRegister)
		{
			NodeType = NodeType.PhyiscalRegister;
			PhysicalRegister = physicalRegister;
		}

		public Node(ExpressionNode expressionNode)
		{
			NodeType = NodeType.Expression;
			ExpressionNode = expressionNode;
		}

		public Node(NodeType type, string name, int index)
		{
			Debug.Assert(type != NodeType.FixedIntegerConstant);
			Debug.Assert(type != NodeType.PhyiscalRegister);
			Debug.Assert(type != NodeType.Instruction);
			Debug.Assert(type != NodeType.Expression);

			NodeType = type;
			Index = index;
			Name = name;
		}

		public void AddNode(Node node)
		{
			ParentNodes.Add(node);
		}

		protected bool ValidateInstruction(InstructionNode node)
		{
			if (node == null)
				return false;

			if (node.IsEmpty)
				return false;

			if (NodeType != NodeType.Instruction)
				return false;

			if (node.Instruction != Instruction)
				return false;

			if (Size != InstructionSize.Native && node.Size != Size)
				return false;

			if (ConditionCode != ConditionCode.Undefined && node.ConditionCode != ConditionCode)
				return false;

			return true;
		}

		protected bool ValidateOperand(InstructionNode node, int operandIndex, Operand[] operands, MosaType[] types)
		{
			if (operandIndex > node.OperandCount)
				return false;

			return ValidateOperand(node.GetOperand(operandIndex), operands, types);
		}

		protected bool ValidateOperand(Operand operand, Operand[] operands, MosaType[] types)
		{
			if (operand == null)
				return false;

			if (NodeType == NodeType.Instruction)
				return false;

			if (NodeType == NodeType.PhyiscalRegister && operand.IsCPURegister && operand.Register == PhysicalRegister)
				return true;

			if (NodeType == NodeType.VirtualRegister && operand.IsVirtualRegister)
				return true;

			if (NodeType == NodeType.FixedIntegerConstant && operand.IsResolvedConstant && operand.ConstantUnsignedLongInteger == ConstantInteger)
				return true;

			if (NodeType == NodeType.ConstantVariable && operand.IsConstant)
			{
				if (operands[Index] == null)
				{
					operands[Index] = operand;
					return true;
				}
				else
				{
					return operands[Index].ConstantUnsignedInteger == operand.ConstantUnsignedInteger;
				}
			}

			if (NodeType == NodeType.OperandVariable)
			{
				if (operands[Index] == null)
				{
					operands[Index] = operand;
					return true;
				}
				else
				{
					return operands[Index] == operand;
				}
			}

			if (NodeType == NodeType.TypeVariable)
			{
				if (types[Index] == null)
				{
					types[Index] = operand.Type;
					return true;
				}
				else
				{
					return types[Index] == operand.Type;
				}
			}

			return false;
		}

		public bool Match(InstructionNode node, Operand[] operands, MosaType[] types)
		{
			if (NodeType == NodeType.Instruction)
			{
				if (!ValidateInstruction(node))
					return false;

				for (int i = 0; i < ParentNodes.Count; i++)
				{
					var parentNode = ParentNodes[i];

					if (NodeType == NodeType.Any)
						continue;

					if (parentNode.NodeType == NodeType.Instruction)
					{
						var operand = node.GetOperand(i);

						if (operand.Definitions.Count != 1)
							return false;

						var parent = operand.Definitions[0];

						if (!parentNode.Match(parent, operands, types))
							return false;
					}
					else
					{
						if (!parentNode.ValidateOperand(node, i, operands, types))
							return false;
					}
				}
			}

			return true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			switch (NodeType)
			{
				case NodeType.Instruction: sb.Append(Instruction.BaseInstructionName); break;
				case NodeType.FixedIntegerConstant: sb.Append(ConstantInteger.ToString()); break;
				case NodeType.FixedDoubleConstant: sb.Append(ConstantDouble.ToString()); break;
				case NodeType.PhyiscalRegister: sb.Append(PhysicalRegister.ToString()); break;
				case NodeType.VirtualRegister:
				case NodeType.OperandVariable: sb.Append(Name); break;
				case NodeType.ConstantVariable: sb.Append("(Const "); sb.Append(Name); sb.Append(")"); break;
				case NodeType.TypeVariable: sb.Append('<'); sb.Append(Name); sb.Append('>'); break;
				case NodeType.Expression: sb.Append("["); sb.Append(ExpressionNode.ToString()); sb.Append("]"); break;
				case NodeType.Any: sb.Append("_"); break;
				default: break;
			}

			if (ParentNodes.Count != 0)
			{
				foreach (var node in ParentNodes)
				{
					sb.Append(" ");
					sb.Append(node.ToString());
				}
			}

			return sb.ToString();
		}
	}
}

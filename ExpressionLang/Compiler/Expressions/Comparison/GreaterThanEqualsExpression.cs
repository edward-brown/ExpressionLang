﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionLang.Compiler.Expressions.Comparison
{
    public abstract class GreaterThanEqualsExpression<T> : UnaryExpression, IExpression<bool>
    {
        internal IExpression<T> Left { get; }
        internal IExpression<T> Right { get; }

        public GreaterThanEqualsExpression(IExpression<T> left, IExpression<T> right)
            : base(left.StartLine, left.StartColumn, right.EndLine, right.EndColumn)
        {
            Left = left;
            Right = right;
        }

        public abstract bool Evaluate();
    }

    public class IntGreaterThanEqualsExpression : GreaterThanEqualsExpression<int>
    {
        public IntGreaterThanEqualsExpression(IExpression<int> left, IExpression<int> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() >= Right.Evaluate();
    }

    public class FloatGreaterThanEqualsExpression : GreaterThanEqualsExpression<float>
    {
        public FloatGreaterThanEqualsExpression(IExpression<float> left, IExpression<float> right) : base(left, right) { }

        public override IExpression<T> As<T>()
        {
            if (typeof(T) != typeof(bool))
                throw new Exception($"Can't cast from bool to {typeof(T)} ({StartLine}:{StartColumn}-{EndLine}:{EndColumn})");
            else
                return (IExpression<T>)this;
        }

        public override bool Evaluate() => Left.Evaluate() >= Right.Evaluate();
    }
}

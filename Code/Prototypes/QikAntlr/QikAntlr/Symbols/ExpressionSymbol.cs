﻿using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal class ExpressionSymbol : BaseSymbol, IExpression
    {
        private BaseFunction func;
        public bool Hidden { get; private set; }

        public ExpressionSymbol(string symbol, string title, BaseFunction func, string hidden)
            : base(symbol, title)
        {
            this.func = func;
            this.Hidden = ParseHidden(hidden);
        }

        public ExpressionSymbol(string symbol, string title, BaseFunction func, string hidden, string prefix, string postfix)
            : base(symbol, title, prefix, postfix)
        {
            this.func = func;
            this.Hidden = ParseHidden(hidden);
        }

        public override string Value
        {
            get { return func.Execute(); }
        }

        private bool ParseHidden(string hidden)
        {
            if (string.IsNullOrEmpty(hidden))
                return false;
            else
            {
                bool result = false;
                bool.TryParse(hidden, out result);
                return result;
            }
        }
    }
}

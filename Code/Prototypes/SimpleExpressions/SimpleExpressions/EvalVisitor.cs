using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpressions
{
    public class EvalVisitor : LabeledExprBaseVisitor<int>
    {
        private Dictionary<string, int> memory = new Dictionary<string, int>();

        private List<int> calculations = new List<int>();
        public int[] Calculations
        {
            get { return this.calculations.ToArray(); }
        }


        // All assignments are added to the memory/symbol/id dictionary.
        // These assignments appear to be picked up before the "id" is visited later.
        // so use this to populate the symbol/id memory dictionary so that you can use
        // "VisitId" to return the values later. 
        public override int VisitAssign(LabeledExprParser.AssignContext context)
        {
            string id = context.ID().GetText();                     // id is left-hand side of '='.
            int value = Visit(context.expr());                      // compute value of expression on the right.
            memory[id] = value;

            return value;
        }

        // Actually where the computation is processed for each expression on each line
        // and then passed to the output window.
        public override int VisitPrintExpr(LabeledExprParser.PrintExprContext context)
        {
            int value = Visit(context.expr());                      // evaluate the expr child
            System.Diagnostics.Debug.WriteLine(value);              // print the result
            this.calculations.Add(value);
            return 0;
        }

        // get the integer value
        public override int VisitInt(LabeledExprParser.IntContext context)
        {
            return int.Parse(context.INT().GetText());
        }

        // return ID from the symbol/id table. The parser has recognized an ID, which has already
        // been added to the "memory" dictionary with a value. So the value is picked up from there.
        public override int VisitId(LabeledExprParser.IdContext context)
        {
            string id = context.ID().GetText();
            if (memory.ContainsKey(id))
                return memory[id];
            return 0;
        }

        // Multiply / Divide
        public override int VisitMulDiv(LabeledExprParser.MulDivContext context)
        {
            int left = Visit(context.expr(0));                      // get the value of the left sub-expression
            int right = Visit(context.expr(1));                     // get the value of the right sub-expression

            if (context.op.Type == LabeledExprParser.MUL)
                return left * right;

            return left / right;                                    // must be division
        }

        // Add / Subtract
        public override int VisitAddSub(LabeledExprParser.AddSubContext context)
        {
            int left = Visit(context.expr(0));                      // get value of left sub-expression
            int right = Visit(context.expr(1));                     // get value of right sub-expression

            if (context.op.Type == LabeledExprParser.ADD)
                return left + right;

            return left - right;                                    // must be subraction
        }

        // parenthisis
        public override int VisitParens(LabeledExprParser.ParensContext context)
        {
            return Visit(context.expr());                           // return child expression's value.
        }

        public override int VisitClear(LabeledExprParser.ClearContext context)
        {
            memory.Clear();
            return 0;
        }
    }
}

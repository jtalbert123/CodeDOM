using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace CodeDOM_Helper
{
    public static class Expressions
    {
        private static CodeExpression Last;

        public static CodeExpression TheExpression { get { return Last; } }

        public static CodeExpression Expression(string Content)
        {
            CodeSnippetExpression Snippet = new CodeSnippetExpression(Content);
            Last = Snippet;
            return Snippet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace CodeDOM_Helper
{
    public static class Statements
    {
        private static CodeStatement Last;

        public static CodeStatement TheStatement { get { return Last; } }

        public static CodeStatement Statement(string Content)
        {
            CodeSnippetStatement Snippet = new CodeSnippetStatement(Content);
            Last = Snippet;
            return Snippet;
        }
    }
}

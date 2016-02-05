using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace CodeDOM_Helper
{
    public static class Parameters
    {
        private static CodeParameterDeclarationExpression Last;

        public static CodeParameterDeclarationExpression TheParameter {get {return Last;} }

        public static CodeParameterDeclarationExpression Parameter(Type Type, string name)
        {
            CodeParameterDeclarationExpression Parameter = new CodeParameterDeclarationExpression(Type, name);
            Last = Parameter;
            return Parameter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace CodeDOM_Helper
{
    public static class Methods
    {
        private static CodeMemberMethod Last;

        /// <summary>
        /// Returns the last Method that was created by this class.
        /// </summary>
        public static CodeMemberMethod TheMethod { get { return Last; } }

        public static CodeMemberMethod Method()
        {
            return Method(null, null);
        }

        public static CodeMemberMethod Method(CodeTypeReference ReturnType)
        {
            return Method(null, ReturnType);
        }

        public static CodeMemberMethod Method(string Name)
        {
            return Method(Name, null);
        }

        public static CodeMemberMethod Method(string Name, CodeTypeReference ReturnType)
        {
            CodeMemberMethod Method = new CodeMemberMethod();
            if (Name != null)
            {
                Method.Name = Name;
            }
            if (ReturnType != null)
            {
                Method.ReturnType = ReturnType;
            }
            Last = Method;
            return Method;
        }

        public static CodeMemberMethod Public(this CodeMemberMethod Method)
        {
            Method.Attributes = (Method.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            return Method;
        }

        public static CodeMemberMethod Private(this CodeMemberMethod Method)
        {
            Method.Attributes = (Method.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private;
            return Method;
        }

        public static CodeMemberMethod Internal(this CodeMemberMethod Method)
        {
            Method.Attributes = (Method.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Assembly;
            return Method;
        }

        public static CodeMemberMethod Protect(this CodeMemberMethod Method)
        {
            Method.Attributes = (Method.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Family;
            return Method;
        }

        public static CodeMemberMethod Return(this CodeMemberMethod Method, CodeExpression Expression)
        {
            CodeMethodReturnStatement RetStatment = new CodeMethodReturnStatement(Expression);
            Method.Statements.Add(RetStatment);
            return Method;
        }

        public static CodeMemberMethod Add(this CodeMemberMethod Method, CodeStatement Statement)
        {
            Method.Statements.Add(Statement);
            return Method;
        }

        public static CodeMemberMethod Add(this CodeMemberMethod Method, CodeParameterDeclarationExpression Parameter)
        {
            Method.Parameters.Add(Parameter);
            return Method;
        }

        public static CodeMemberMethod Add(this CodeMemberMethod Method, params CodeParameterDeclarationExpression[] Parameters)
        {
            foreach (CodeParameterDeclarationExpression Parameter in Parameters)
            {
                Method.Parameters.Add(Parameter);
            }
            return Method;
        }

        public static CodeMemberMethod Add(this CodeMemberMethod Method, CodeParameterDeclarationExpressionCollection Parameters)
        {
            foreach (CodeParameterDeclarationExpression Parameter in Parameters)
            {
                Method.Parameters.Add(Parameter);
            }
            return Method;
        }
    }
}

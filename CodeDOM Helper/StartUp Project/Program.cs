using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using static CodeDOM_Helper.Classes;
using static CodeDOM_Helper.Methods;
using static CodeDOM_Helper.Types;
using static CodeDOM_Helper.Parameters;
using static CodeDOM_Helper.Expressions;

using Microsoft.CSharp;
using System.IO;

namespace StartUp_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeTypeDeclaration MyClass = Class("MyClass");
            MyClass.Add(Method("StrLen", Type(typeof(int))));
            TheMethod.Add(Parameter(typeof(string), "str"));
            TheMethod.Return(Expression("str.Length"));

            CSharpCodeProvider Provider = new CSharpCodeProvider();
            Provider.GenerateCodeFromType(MyClass, Console.Out, new System.CodeDom.Compiler.CodeGeneratorOptions());
            Console.ReadKey();
        }
    }
}

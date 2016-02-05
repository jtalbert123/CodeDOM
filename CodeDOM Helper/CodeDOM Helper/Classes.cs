using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.Reflection;

namespace CodeDOM_Helper
{
    public static class Classes
    {
        private static CodeTypeDeclaration Last;

        /// <summary>
        /// Returns the last Class that was created by this class.
        /// </summary>
        /// <returns></returns>
        public static CodeTypeDeclaration TheClass { get { return Last; } }

        public static CodeTypeDeclaration Class()
        {
            return Class(null, 0, null);
        }

        public static CodeTypeDeclaration Class(string Name)
        {
            return Class(Name, 0, null);
        }

        public static CodeTypeDeclaration Class(TypeAttributes Attributes)
        {
            return Class(null, Attributes, null);
        }

        public static CodeTypeDeclaration Class(string Name, TypeAttributes Attributes, CodeTypeReference BaseType)
        {
            CodeTypeDeclaration NewClass = new CodeTypeDeclaration(Name);
            if (Name != null)
            {
                NewClass.Name = Name;
            }
            NewClass.TypeAttributes = Attributes;
            NewClass.IsClass = true;
            if (BaseType != null)
            {
                NewClass.BaseTypes.Add(BaseType);
            }
            Last = NewClass;
            return NewClass;
        }

        public static CodeTypeDeclaration Public(this CodeTypeDeclaration Class)
        {
            Class.Attributes = (Class.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Public;
            Class.TypeAttributes = (Class.TypeAttributes & ~TypeAttributes.VisibilityMask) | TypeAttributes.Public;
            return Class;
        }

        public static CodeTypeDeclaration Private(this CodeTypeDeclaration Class)
        {
            Class.Attributes = (Class.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private;
            Class.TypeAttributes = (Class.TypeAttributes & ~TypeAttributes.VisibilityMask) | TypeAttributes.NestedPrivate;
            return Class;
        }

        public static CodeTypeDeclaration Internal(this CodeTypeDeclaration Class)
        {
            Class.Attributes = (Class.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Assembly;
            Class.TypeAttributes = (Class.TypeAttributes & ~TypeAttributes.VisibilityMask) | TypeAttributes.NestedAssembly;
            return Class;
        }

        public static CodeTypeDeclaration Protect(this CodeTypeDeclaration Class)
        {
            Class.Attributes = (Class.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Family;
            Class.TypeAttributes = (Class.TypeAttributes & ~TypeAttributes.VisibilityMask) | TypeAttributes.NestedFamily;
            return Class;
        }

        public static CodeTypeDeclaration Seal(this CodeTypeDeclaration Class)
        {
            Class.TypeAttributes = (Class.TypeAttributes & ~TypeAttributes.VisibilityMask) | TypeAttributes.Sealed;
            return Class;
        }

        public static CodeTypeDeclaration Add(this CodeTypeDeclaration Class, CodeMemberMethod Method)
        {
            Class.Members.Add(Method);
            return Class;
        }

        public static CodeTypeDeclaration Add(this CodeTypeDeclaration Class, CodeMemberProperty Property)
        {
            Class.Members.Add(Property);
            return Class;
        }
    }
}

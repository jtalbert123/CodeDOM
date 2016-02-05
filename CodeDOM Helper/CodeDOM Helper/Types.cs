using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace CodeDOM_Helper
{
    public static class Types
    {
        private static CodeTypeReference Last;

        /// <summary>
        /// Returns the last TypeReference created
        /// </summary>
        public static CodeTypeReference TheType { get { return Last; } }

        public static CodeTypeReference Type(object type)
        {
            return Type(type.GetType());
        }

        public static CodeTypeReference Type(Type type)
        {
            Last = new CodeTypeReference(type);
            return Last;
        }
    }
}

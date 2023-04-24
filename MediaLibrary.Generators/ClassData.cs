using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaLibrary.Generators
{
    internal class ClassData
    {
        public ClassDeclarationSyntax Node { get; set; }
        public AttributeSyntax Attribute { get; set; }
        public ClassData(ClassDeclarationSyntax node, AttributeSyntax attribute)
        {
            Node = node;
            Attribute = attribute;  
        }
    }
}

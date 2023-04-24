using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibrary.Generators
{
    internal class SyntaxReceiver : ISyntaxReceiver
    {
        private const string _attributeName = "UseCustomGenerator";
        public List<ClassData> Nodes { get; } = new List<ClassData>();
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (!(syntaxNode is ClassDeclarationSyntax declarationSyntax) || !declarationSyntax.AttributeLists.Any())
            {
                return;
            }
            var attrList = declarationSyntax.AttributeLists
                .Select(x => x.Attributes)
                .SelectMany(x => x)
                .Where(x => x.Name.ToString() == _attributeName)
                .ToList();

            var customGenerator = attrList.FirstOrDefault(x => x.Name.ToString() == _attributeName);
            if (customGenerator is null)
            {
                return;
            }

            Nodes.Add(new ClassData(declarationSyntax, customGenerator));
        }
    }
}

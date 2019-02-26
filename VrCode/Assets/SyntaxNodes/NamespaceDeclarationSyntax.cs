using System;
using Microsoft.CodeAnalysis.CSharp;
using NodeComponents;
using UnityEngine;

namespace SyntaxNodes
{
    public class NamespaceDeclarationSyntax : MemberDeclarationSyntax
    {
        public override string DisplayString => "namespace";
    }
}
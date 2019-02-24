//using System.Linq;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using UnityEngine;
//using UnityEditor;

//[InitializeOnLoad]
//public class Startup
//{
//    static Startup()
//    {
//        SyntaxTree helloWorld = new CsGenerator2.RoslynCodeEditor().Gen();

//        var writeLineNode = (MemberAccessExpressionSyntax)helloWorld.GetRoot().ChildNodes().ElementAt(1)
//            .ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First()
//            .ChildNodes().First().ChildNodes().First();

//        var thing = writeLineNode.ToString();

//    }
//}


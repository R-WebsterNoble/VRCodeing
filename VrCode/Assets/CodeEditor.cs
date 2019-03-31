using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

public class CodeEditor
{
    private static readonly IEnumerable<string> DefaultNamespaces =
        new[]
        {
            "System",
            "System.IO",
            "System.Net",
            "System.Linq",
            "System.Text",
            "System.Text.RegularExpressions",
            "System.Collections.Generic"
        };

    private static readonly string runtimePath =
        @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\{0}.dll";

    private static readonly IEnumerable<MetadataReference> DefaultReferences =
        new[]
        {
            MetadataReference.CreateFromFile(string.Format(runtimePath, "mscorlib")),
            MetadataReference.CreateFromFile(string.Format(runtimePath, "System")),
            MetadataReference.CreateFromFile(string.Format(runtimePath, "System.Core"))
        };

    private static readonly CSharpCompilationOptions DefaultCompilationOptions =
        new CSharpCompilationOptions(OutputKind.ConsoleApplication)
            .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release)
            .WithUsings(DefaultNamespaces);

    public static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
    {
        var stringText = SourceText.From(text, Encoding.UTF8);
        return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
    }

    public SyntaxTree Gen(string source)
    {
        //var source = "// A Hello World! program in C#.\r\nusing System;\r\nnamespace HelloWorld\r\n{\r\n    class Hello \r\n    {\r\n        static void Main() \r\n        {\r\n            Console.WriteLine(\"Hello World!\");\r\n\r\n            // Keep the console window open in debug mode.\r\n            Console.WriteLine(\"Press any key to exit.\");\r\n            Console.ReadKey();\r\n        }\r\n    }\r\n}";

        //var helloWorld = SyntaxFactory.ParseSyntaxTree(source);

        var helloWorld = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp5));

        return helloWorld;
        var compilation =
            CSharpCompilation.Create("Test.dll", new[] {helloWorld}, DefaultReferences, DefaultCompilationOptions);

        ////LiteralExpressionSyntax helloWorldStringLiteral = (LiteralExpressionSyntax) helloWorld.GetRoot().ChildNodes().ElementAt(1).ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First().ChildNodes().First().ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().First();
        //var memberAccessNode = (MemberAccessExpressionSyntax)helloWorld.GetRoot().ChildNodes().ElementAt(1)
        //    .ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First()
        //    .ChildNodes().First().ChildNodes().First();

        //var updated = memberAccessNode.WithName(SyntaxFactory.IdentifierName("Write"));

        //var updatedHelloWorld = helloWorld.GetRoot().ReplaceNode(memberAccessNode, updated).SyntaxTree;

        //compilation = CSharpCompilation.Create("Test.dll", new[] { updatedHelloWorld }, DefaultReferences, DefaultCompilationOptions);

        using (var ms = new MemoryStream())
        {
            var emitResult = compilation.Emit(ms);
            if (!emitResult.Success)
            {
                var errorNodes = emitResult.Diagnostics.Select(FindErrorNode);
                var errorString = $"{emitResult.Diagnostics}\n\n{string.Join(",", errorNodes)}";
                throw new Exception(string.Join("\n", errorString));
            }
        }

        return helloWorld;
        // helloWorldStringLiteral.Update(new SyntaxToken());
        //SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression);
        //SyntaxFactory.ParseExpression("\"hello\"")//var 

        //var syntaxNode = helloWorld.GetRoot().ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().First().ChildNodes();
        //helloWorld.GetCompilationUnitRoot().SyntaxTree
        //Microsoft.CodeAnalysis.CSharp.Syntax.E
        //var  blah = (Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax.EqualsExpression)SyntaxFactory.ParseExpression("true == false");
        //var ex = SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression);
        //var ifStmt = (IfStatementSyntax)SyntaxFactory.ParseStatement("if (1==1){Blah();}");
        //ifStmt = ifStmt.WithCondition(SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, ifStmt.Condition, ex));

        //var condition =  = ifStmt.GetCompilationUnitRoot().DescendantNodes().OfType<IfStatementSyntax>().Single();

        //var exprStmt1 = (ExpressionStatementSyntax)ifStmt.Statement;
        //var expr1 = (IdentifierNameSyntax)exprStmt1.Expression;
        //var token1 = expr1.Identifier;
    }

    private static SyntaxNode FindErrorNode(Diagnostic first)
    {
        var targetStartPos = first.Location.SourceSpan.Start;
        var targetEndPos = first.Location.SourceSpan.End;
        var currentNode = first.Location.SourceTree.GetRoot();
        while (currentNode != null)
        {
            var childNodes = currentNode.ChildNodes();
            currentNode = null; // exit the loop if we don't find an improvement on the previous current node
            foreach (var node in childNodes)
            {
                var nodeSpan = node.Span;
                var nodeStartPos = nodeSpan.Start;
                var nodeEndPos = nodeSpan.End;

                if (nodeStartPos == targetStartPos && nodeEndPos == targetEndPos)
                    return node; // The target node is current node

                // The target node is within current node
                if (nodeStartPos <= targetStartPos && nodeEndPos >= targetEndPos)
                {
                    currentNode = node;
                    break;
                }
            }
        }

        return null;
    }
}
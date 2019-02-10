﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using UnityEngine; 

using Ros = Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SyntaxNodes
{
    public class CSharpSyntaxNode : Node
    {
    }

    public class AliasedQualifiedNameSyntax : NameSyntax
    {
    }

    public class AccessorDeclarationSyntax : CSharpSyntaxNode
    {
    }

    public class AccessorListSyntax : CSharpSyntaxNode
    {
    }

    public class AnonymousObjectMemberDeclaratorSyntax : CSharpSyntaxNode
    {
    }

    public class ArgumentSyntax : CSharpSyntaxNode
    {
    }

    public class ArrayRankSpecifierSyntax : CSharpSyntaxNode
    {
    }

    public class ArrowExpressionClauseSyntax : CSharpSyntaxNode
    {
    }

    public class AttributeArgumentListSyntax : CSharpSyntaxNode
    {
    }

    public class AttributeArgumentSyntax : CSharpSyntaxNode
    {
    }

    public class AttributeListSyntax : CSharpSyntaxNode
    {
    }

    public class AttributeSyntax : CSharpSyntaxNode
    {
    }

    public class AttributeTargetSpecifierSyntax : CSharpSyntaxNode
    {
    }

    public class BaseArgumentListSyntax : CSharpSyntaxNode
    {
    }

    public class ArgumentListSyntax : BaseArgumentListSyntax
    {
    }

    public class BracketedArgumentListSyntax : BaseArgumentListSyntax
    {
    }

    public class BaseCrefParameterListSyntax : CSharpSyntaxNode
    {
    }

    public class CrefBracketedParameterListSyntax : BaseCrefParameterListSyntax
    {
    }

    public class CrefParameterListSyntax : BaseCrefParameterListSyntax
    {
    }

    public class BaseListSyntax : CSharpSyntaxNode
    {
    }

    public class BaseParameterListSyntax : CSharpSyntaxNode
    {
    }

    public class BracketedParameterListSyntax : BaseParameterListSyntax
    {
    }

    public class ParameterListSyntax : BaseParameterListSyntax
    {
    }

    public class BaseTypeSyntax : CSharpSyntaxNode
    {
    }

    public class SimpleBaseTypeSyntax : BaseTypeSyntax
    {
    }

    public class CatchClauseSyntax : CSharpSyntaxNode
    {
    }

    public class CatchDeclarationSyntax : CSharpSyntaxNode
    {
    }

    public class CatchFilterClauseSyntax : CSharpSyntaxNode
    {
    }

    public class CompilationUnitSyntax : CSharpSyntaxNode
    {
        public void Awake()
        {
            GameObject textObject = (GameObject)Instantiate(Resources.Load("Clickable"));
            textObject.transform.parent = transform;
            textObject.GetComponent<Clickable>().Clicked += (sender, args) => { SetName(); };
        }

        private void SetName()
        {
            Debug.Log("clicked");

            var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();

            if (root.SelectedNode == null)
            {
                Debug.Log("nothing selected");
                return;
            }

            if (root.SelectedNode.SyntaxNode is Ros.UsingDirectiveSyntax selectedUsing)
            {

                var newNode = ((Ros.CompilationUnitSyntax)SyntaxNode).AddUsings(selectedUsing);
                RootNode.ReplaceNode(SyntaxNode, newNode);

                //var line = gameObject.AddComponent<LineRenderer>();
                //line.material = new Material(Shader.Find("Unlit/Texture"));
                //line.startColor = Color.grey;
                //line.endColor = Color.grey;
                //line.startWidth = 0.1f;
                //line.endWidth = 0.1f;
                //line.SetPositions(new[] { transform.position, transform.position + new Vector3(-0.25f, 0f, 0f) });

                //Line = line;
                if (root.SelectedNode.gameObject != null)
                    Destroy(root.SelectedNode.gameObject);

                root.SelectedNode = null;
            }
            else
            {
                Debug.Log($"Couldn't attach {root.SelectedNode.DisplayString} to {DisplayString}");
            }
        }
    }

    public class ConstructorInitializerSyntax : CSharpSyntaxNode
    {
    }

    public class CrefParameterSyntax : CSharpSyntaxNode
    {
    }

    public class CrefSyntax : CSharpSyntaxNode
    {
    }

    public class MemberCrefSyntax : CrefSyntax
    {
    }

    public class ConversionOperatorMemberCrefSyntax : MemberCrefSyntax
    {
    }

    public class IndexerMemberCrefSyntax : MemberCrefSyntax
    {
    }

    public class NameMemberCrefSyntax : MemberCrefSyntax
    {
    }

    public class OperatorMemberCrefSyntax : MemberCrefSyntax
    {
    }

    public class QualifiedCrefSyntax : CrefSyntax
    {
    }

    public class TypeCrefSyntax : CrefSyntax
    {
    }

    public class ElseClauseSyntax : CSharpSyntaxNode
    {
        public override string DisplayString => "else";
    }

    public class EqualsValueClauseSyntax : CSharpSyntaxNode
    {
        public override string DisplayString => "=";
    }

    public class ExplicitInterfaceSpecifierSyntax : CSharpSyntaxNode
    {
    }

    public class ExpressionSyntax : CSharpSyntaxNode
    {
    }

    public class AnonymousFunctionExpressionSyntax : ExpressionSyntax
    {
    }

    public class AnonymousMethodExpressionSyntax : AnonymousFunctionExpressionSyntax
    {
    }

    public class LambdaExpressionSyntax : AnonymousFunctionExpressionSyntax
    {
    }

    public class ParenthesizedLambdaExpressionSyntax : LambdaExpressionSyntax
    {
    }

    public class SimpleLambdaExpressionSyntax : LambdaExpressionSyntax
    {
    }

    public class AnonymousObjectCreationExpressionSyntax : ExpressionSyntax
    {
    }

    public class ArrayCreationExpressionSyntax : ExpressionSyntax
    {
    }

    public class AssignmentExpressionSyntax : ExpressionSyntax
    {
    }

    public class AwaitExpressionSyntax : ExpressionSyntax
    {
    }

    public class BinaryExpressionSyntax : ExpressionSyntax
    {
    }

    public class CastExpressionSyntax : ExpressionSyntax
    {
    }

    public class CheckedExpressionSyntax : ExpressionSyntax
    {
    }

    public class ConditionalAccessExpressionSyntax : ExpressionSyntax
    {
    }

    public class ConditionalExpressionSyntax : ExpressionSyntax
    {
    }

    public class DeclarationExpressionSyntax : ExpressionSyntax
    {
    }

    public class DefaultExpressionSyntax : ExpressionSyntax
    {
    }

    public class ElementAccessExpressionSyntax : ExpressionSyntax
    {
    }

    public class ElementBindingExpressionSyntax : ExpressionSyntax
    {
    }

    public class ImplicitArrayCreationExpressionSyntax : ExpressionSyntax
    {
    }

    public class ImplicitElementAccessSyntax : ExpressionSyntax
    {
    }

    public class ImplicitStackAllocArrayCreationExpressionSyntax : ExpressionSyntax
    {
    }

    public class InitializerExpressionSyntax : ExpressionSyntax
    {
    }

    public class InstanceExpressionSyntax : ExpressionSyntax
    {
    }

    public class BaseExpressionSyntax : InstanceExpressionSyntax
    {
    }

    public class ThisExpressionSyntax : InstanceExpressionSyntax
    {
    }

    public class InterpolatedStringExpressionSyntax : ExpressionSyntax
    {
    }

    public class InvocationExpressionSyntax : ExpressionSyntax
    {
    }

    public class IsPatternExpressionSyntax : ExpressionSyntax
    {
    }

    public class LiteralExpressionSyntax : ExpressionSyntax
    {
        public override string DisplayString =>
            ((Ros.LiteralExpressionSyntax)SyntaxNode).Token.ToString().Replace("\n", "");
    }

    public class MakeRefExpressionSyntax : ExpressionSyntax
    {
    }

    public class MemberAccessExpressionSyntax : ExpressionSyntax
    {
        //internal override void OnMouseDown()
        //{
        //    base.OnMouseDown();

        //    if (!Input.GetKey("r"))
        //        return;

        //    var rootNode = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();


        //    var identifier = SyntaxFactory.IdentifierName("Write");

        //    var newNode = ((Ros.MemberAccessExpressionSyntax)SyntaxNode)
        //        .WithName(identifier);

        //    var newTree = rootNode.SyntaxNode.ReplaceNode(SyntaxNode, newNode);

        //    rootNode.RebuildTree(newTree);
        //}
    }

    public class MemberBindingExpressionSyntax : ExpressionSyntax
    {
    }

    public class ObjectCreationExpressionSyntax : ExpressionSyntax
    {
        public override string DisplayString => "new";
    }

    public class OmittedArraySizeExpressionSyntax : ExpressionSyntax
    {
    }

    public class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
    }

    public class PostfixUnaryExpressionSyntax : ExpressionSyntax
    {
    }

    public class PrefixUnaryExpressionSyntax : ExpressionSyntax
    {
    }

    public class QueryExpressionSyntax : ExpressionSyntax
    {
    }

    public class RangeExpressionSyntax : ExpressionSyntax
    {
    }

    public class RefExpressionSyntax : ExpressionSyntax
    {
    }

    public class RefTypeExpressionSyntax : ExpressionSyntax
    {
    }

    public class RefValueExpressionSyntax : ExpressionSyntax
    {
    }

    public class SizeOfExpressionSyntax : ExpressionSyntax
    {
    }

    public class StackAllocArrayCreationExpressionSyntax : ExpressionSyntax
    {
    }

    public class SwitchExpressionSyntax : ExpressionSyntax
    {
    }

    public class ThrowExpressionSyntax : ExpressionSyntax
    {
    }

    public class TupleExpressionSyntax : ExpressionSyntax
    {
    }

    public class TypeOfExpressionSyntax : ExpressionSyntax
    {
    }

    public class TypeSyntax : ExpressionSyntax
    {
    }

    public class ArrayTypeSyntax : TypeSyntax
    {
    }

    public class NameSyntax : TypeSyntax
    {
    }

    public class AliasQualifiedNameSyntax : NameSyntax
    {
    }

    public class QualifiedNameSyntax : NameSyntax
    {
    }

    public class SimpleNameSyntax : NameSyntax
    {
    }

    public class GenericNameSyntax : SimpleNameSyntax
    {
    }

    public class IdentifierNameSyntax : SimpleNameSyntax
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax)SyntaxNode).Identifier.ValueText;
    }

    public class NullableTypeSyntax : TypeSyntax
    {
    }

    public class OmittedTypeArgumentSyntax : TypeSyntax
    {
    }

    public class PointerTypeSyntax : TypeSyntax
    {
    }

    public class PredefinedTypeSyntax : TypeSyntax
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax)SyntaxNode).Keyword.ValueText;
    }

    public class RefTypeSyntax : TypeSyntax
    {
    }

    public class TupleTypeSyntax : TypeSyntax
    {
    }

    public class ExternAliasDirectiveSyntax : CSharpSyntaxNode
    {
    }

    public class FinallyClauseSyntax : CSharpSyntaxNode
    {
    }

    public class InterpolatedStringContentSyntax : CSharpSyntaxNode
    {
    }

    public class InterpolatedStringTextSyntax : InterpolatedStringContentSyntax
    {
    }

    public class InterpolationSyntax : InterpolatedStringContentSyntax
    {
    }

    public class InterpolationAlignmentClauseSyntax : CSharpSyntaxNode
    {
    }

    public class InterpolationFormatClauseSyntax : CSharpSyntaxNode
    {
    }

    public class JoinIntoClauseSyntax : CSharpSyntaxNode
    {
    }

    public class MemberDeclarationSyntax : CSharpSyntaxNode
    {
    }

    public class BaseFieldDeclarationSyntax : MemberDeclarationSyntax
    {
        public override int Height { get; set; } = 0;
        public override string DisplayString => "";
    }

    public class EventFieldDeclarationSyntax : BaseFieldDeclarationSyntax
    {
    }

    public class FieldDeclarationSyntax : BaseFieldDeclarationSyntax
    {
    }

    public class BaseMethodDeclarationSyntax : MemberDeclarationSyntax
    {
    }

    public class ConstructorDeclarationSyntax : BaseMethodDeclarationSyntax
    {
    }

    public class ConversionOperatorDeclarationSyntax : BaseMethodDeclarationSyntax
    {
    }

    public class DestructorDeclarationSyntax : BaseMethodDeclarationSyntax
    {
    }

    public class MethodDeclarationSyntax : BaseMethodDeclarationSyntax
    {
    }

    public class OperatorDeclarationSyntax : BaseMethodDeclarationSyntax
    {
    }

    public class BasePropertyDeclarationSyntax : MemberDeclarationSyntax
    {
    }

    public class EventDeclarationSyntax : BasePropertyDeclarationSyntax
    {
    }

    public class IndexerDeclarationSyntax : BasePropertyDeclarationSyntax
    {
    }

    public class PropertyDeclarationSyntax : BasePropertyDeclarationSyntax
    {
    }

    public class BaseTypeDeclarationSyntax : MemberDeclarationSyntax
    {
    }

    public class EnumDeclarationSyntax : BaseTypeDeclarationSyntax
    {
    }

    public class TypeDeclarationSyntax : BaseTypeDeclarationSyntax
    {
    }

    public class ClassDeclarationSyntax : TypeDeclarationSyntax
    {
    }

    public class InterfaceDeclarationSyntax : TypeDeclarationSyntax
    {
    }

    public class StructDeclarationSyntax : TypeDeclarationSyntax
    {
    }

    public class DelegateDeclarationSyntax : MemberDeclarationSyntax
    {
    }

    public class EnumMemberDeclarationSyntax : MemberDeclarationSyntax
    {
    }

    public class GlobalStatementSyntax : MemberDeclarationSyntax
    {
    }

    public class IncompleteMemberSyntax : MemberDeclarationSyntax
    {
    }

    public class NamespaceDeclarationSyntax : MemberDeclarationSyntax
    {

        public override string DisplayString => "namespace";
    }

    public class NameColonSyntax : CSharpSyntaxNode
    {
    }

    public class NameEqualsSyntax : CSharpSyntaxNode
    {
    }

    public class OrderingSyntax : CSharpSyntaxNode
    {
    }

    public class ParameterSyntax : CSharpSyntaxNode
    {
    }

    public class PatternSyntax : CSharpSyntaxNode
    {
    }

    public class ConstantPatternSyntax : PatternSyntax
    {
    }

    public class DeclarationPatternSyntax : PatternSyntax
    {
    }

    public class DiscardPatternSyntax : PatternSyntax
    {
    }

    public class RecursivePatternSyntax : PatternSyntax
    {
    }

    public class VarPatternSyntax : PatternSyntax
    {
    }

    public class PositionalPatternClauseSyntax : CSharpSyntaxNode
    {
    }

    public class PropertyPatternClauseSyntax : CSharpSyntaxNode
    {
    }

    public class QueryBodySyntax : CSharpSyntaxNode
    {
    }

    public class QueryClauseSyntax : CSharpSyntaxNode
    {
    }

    public class FromClauseSyntax : QueryClauseSyntax
    {
    }

    public class JoinClauseSyntax : QueryClauseSyntax
    {
    }

    public class LetClauseSyntax : QueryClauseSyntax
    {
    }

    public class OrderByClauseSyntax : QueryClauseSyntax
    {
    }

    public class WhereClauseSyntax : QueryClauseSyntax
    {
    }

    public class QueryContinuationSyntax : CSharpSyntaxNode
    {
    }

    public class SelectOrGroupClauseSyntax : CSharpSyntaxNode
    {
    }

    public class GroupClauseSyntax : SelectOrGroupClauseSyntax
    {
    }

    public class SelectClauseSyntax : SelectOrGroupClauseSyntax
    {
    }

    public class StatementSyntax : CSharpSyntaxNode
    {
    }

    public class BlockSyntax : StatementSyntax
    {
    }

    public class BreakStatementSyntax : StatementSyntax
    {
    }

    public class CheckedStatementSyntax : StatementSyntax
    {
    }

    public class CommonForEachStatementSyntax : StatementSyntax
    {
    }

    public class ForEachStatementSyntax : CommonForEachStatementSyntax
    {
    }

    public class ForEachVariableStatementSyntax : CommonForEachStatementSyntax
    {
    }

    public class ContinueStatementSyntax : StatementSyntax
    {
    }

    public class DoStatementSyntax : StatementSyntax
    {
    }

    public class EmptyStatementSyntax : StatementSyntax
    {
    }

    public class ExpressionStatementSyntax : StatementSyntax
    {
    }

    public class FixedStatementSyntax : StatementSyntax
    {
    }

    public class ForStatementSyntax : StatementSyntax
    {

        public override string DisplayString => "for";
    }

    public class GotoStatementSyntax : StatementSyntax
    {
    }

    public class IfStatementSyntax : StatementSyntax
    {
    }

    public class LabeledStatementSyntax : StatementSyntax
    {
    }

    public class LocalDeclarationStatementSyntax : StatementSyntax
    {
        public override string DisplayString => "";
        public override int Height { get; set; } = 0;
    }

    public class LocalFunctionStatementSyntax : StatementSyntax
    {
    }

    public class LockStatementSyntax : StatementSyntax
    {
    }

    public class ReturnStatementSyntax : StatementSyntax
    {

        public override string DisplayString => "return";
    }

    public class SwitchStatementSyntax : StatementSyntax
    {
    }

    public class ThrowStatementSyntax : StatementSyntax
    {
    }

    public class TryStatementSyntax : StatementSyntax
    {
    }

    public class UnsafeStatementSyntax : StatementSyntax
    {
    }

    public class UsingStatementSyntax : StatementSyntax
    {
    }

    public class WhileStatementSyntax : StatementSyntax
    {
    }

    public class YieldStatementSyntax : StatementSyntax
    {
    }

    public class StructuredTriviaSyntax : CSharpSyntaxNode
    {
    }

    public class DirectiveTriviaSyntax : StructuredTriviaSyntax
    {
    }

    public class BadDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class BranchingDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class ConditionalDirectiveTriviaSyntax : BranchingDirectiveTriviaSyntax
    {
    }

    public class ElifDirectiveTriviaSyntax : ConditionalDirectiveTriviaSyntax
    {
    }

    public class IfDirectiveTriviaSyntax : ConditionalDirectiveTriviaSyntax
    {
    }

    public class ElseDirectiveTriviaSyntax : BranchingDirectiveTriviaSyntax
    {
    }

    public class DefineDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class EndIfDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class EndRegionDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class ErrorDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class LineDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class LoadDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class NullableDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class PragmaChecksumDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class PragmaWarningDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class ReferenceDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class RegionDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class ShebangDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class UndefDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class WarningDirectiveTriviaSyntax : DirectiveTriviaSyntax
    {
    }

    public class DocumentationCommentTriviaSyntax : StructuredTriviaSyntax
    {
    }

    public class SkippedTokensTriviaSyntax : StructuredTriviaSyntax
    {
    }

    public class SubpatternSyntax : CSharpSyntaxNode
    {
    }

    public class SwitchExpressionArmSyntax : CSharpSyntaxNode
    {
    }

    public class SwitchLabelSyntax : CSharpSyntaxNode
    {
    }

    public class CasePatternSwitchLabelSyntax : SwitchLabelSyntax
    {
    }

    public class CaseSwitchLabelSyntax : SwitchLabelSyntax
    {
    }

    public class DefaultSwitchLabelSyntax : SwitchLabelSyntax
    {
    }

    public class SwitchSectionSyntax : CSharpSyntaxNode
    {
    }

    public class TupleElementSyntax : CSharpSyntaxNode
    {
    }

    public class TypeArgumentListSyntax : CSharpSyntaxNode
    {
    }

    public class TypeParameterConstraintClauseSyntax : CSharpSyntaxNode
    {
    }

    public class TypeParameterConstraintSyntax : CSharpSyntaxNode
    {
    }

    public class ClassOrStructConstraintSyntax : TypeParameterConstraintSyntax
    {
    }

    public class ConstructorConstraintSyntax : TypeParameterConstraintSyntax
    {
    }

    public class TypeConstraintSyntax : TypeParameterConstraintSyntax
    {
    }

    public class TypeParameterListSyntax : CSharpSyntaxNode
    {
    }

    public class TypeParameterSyntax : CSharpSyntaxNode
    {
    }

    public class UsingDirectiveSyntax : CSharpSyntaxNode
    {
        public override string DisplayString => "using";

        public override void InitComponents(Node parent)
        {
            name = GetType().ToString().Replace("Assets.SyntaxNodes.", "");

            GameObject thing = (GameObject)Instantiate(Resources.Load("Using"), transform);
            thing.name = "UsingPrefab";
            GameObject textObject = (GameObject)Instantiate(Resources.Load("Clickable"));
            textObject.transform.parent = transform;
            textObject.GetComponent<Clickable>().Clicked += (sender, args) => { SetName(); };
            base.InitLine(parent);
        }

        private void SetName()
        {
            Debug.Log("clicked");

            var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();

            if (root.SelectedNode == null)
            {
                Debug.Log("nothing selected");
                return;
            }

            if (root.SelectedNode.SyntaxNode is Ros.NameSyntax selectedName)
            {

                var newNode = ((Ros.UsingDirectiveSyntax) SyntaxNode).WithName(selectedName);
                RootNode.ReplaceNode(SyntaxNode, newNode);

                if(root.SelectedNode.gameObject != null)
                    Destroy(root.SelectedNode.gameObject);

                root.SelectedNode = null;
            }
            else
            {
                Debug.Log($"Couldn't attach {root.SelectedNode.DisplayString} to {DisplayString}");
            }
        }
    }

    public class VariableDeclarationSyntax : CSharpSyntaxNode
    {
        public override string DisplayString =>
            ((Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax) SyntaxNode).Variables.FirstOrDefault().Identifier.Text;
    }

    public class VariableDeclaratorSyntax : CSharpSyntaxNode
    {
        public override int Height { get; set; } = 0;
        public override string DisplayString => "";
    }

    public class VariableDesignationSyntax : CSharpSyntaxNode
    {
    }

    public class DiscardDesignationSyntax : VariableDesignationSyntax
    {
    }

    public class ParenthesizedVariableDesignationSyntax : VariableDesignationSyntax
    {
    }

    public class SingleVariableDesignationSyntax : VariableDesignationSyntax
    {
    }

    public class WhenClauseSyntax : CSharpSyntaxNode
    {
    }

    public class XmlAttributeSyntax : CSharpSyntaxNode
    {
    }

    public class XmlCrefAttributeSyntax : XmlAttributeSyntax
    {
    }

    public class XmlNameAttributeSyntax : XmlAttributeSyntax
    {
    }

    public class XmlTextAttributeSyntax : XmlAttributeSyntax
    {
    }

    public class XmlElementEndTagSyntax : CSharpSyntaxNode
    {
    }

    public class XmlElementStartTagSyntax : CSharpSyntaxNode
    {
    }

    public class XmlNameSyntax : CSharpSyntaxNode
    {
    }

    public class XmlNodeSyntax : CSharpSyntaxNode
    {
    }

    public class XmlCDataSectionSyntax : XmlNodeSyntax
    {
    }

    public class XmlCommentSyntax : XmlNodeSyntax
    {
    }

    public class XmlElementSyntax : XmlNodeSyntax
    {
    }

    public class XmlEmptyElementSyntax : XmlNodeSyntax
    {
    }

    public class XmlProcessingInstructionSyntax : XmlNodeSyntax
    {
    }

    public class XmlTextSyntax : XmlNodeSyntax
    {
    }

    public class XmlPrefixSyntax : CSharpSyntaxNode
    {
    }
}
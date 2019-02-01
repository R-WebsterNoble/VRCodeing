using System;
using Microsoft.CodeAnalysis;

namespace Assets.SyntaxNodes
{
    public static class SyntaxNodeLookup
    {
        public static Type LookupType(SyntaxNode node)
        {
            switch (node.GetType().ToString())
            {
                case "Microsoft.CodeAnalysis.CSharp.Syntax.CSharpSyntaxNode":
                    return typeof(CSharpSyntaxNode);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AliasedQualifiedNameSyntax":
                    return typeof(AliasedQualifiedNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax":
                    return typeof(AccessorDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AccessorListSyntax":
                    return typeof(AccessorListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax":
                    return typeof(AnonymousObjectMemberDeclaratorSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax":
                    return typeof(ArgumentSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArrayRankSpecifierSyntax":
                    return typeof(ArrayRankSpecifierSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArrowExpressionClauseSyntax":
                    return typeof(ArrowExpressionClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax":
                    return typeof(AttributeArgumentListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax":
                    return typeof(AttributeArgumentSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax":
                    return typeof(AttributeListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax":
                    return typeof(AttributeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AttributeTargetSpecifierSyntax":
                    return typeof(AttributeTargetSpecifierSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseArgumentListSyntax":
                    return typeof(BaseArgumentListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax":
                    return typeof(ArgumentListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BracketedArgumentListSyntax":
                    return typeof(BracketedArgumentListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseCrefParameterListSyntax":
                    return typeof(BaseCrefParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CrefBracketedParameterListSyntax":
                    return typeof(CrefBracketedParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CrefParameterListSyntax":
                    return typeof(CrefParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax":
                    return typeof(BaseListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseParameterListSyntax":
                    return typeof(BaseParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BracketedParameterListSyntax":
                    return typeof(BracketedParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax":
                    return typeof(ParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax":
                    return typeof(BaseTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax":
                    return typeof(SimpleBaseTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax":
                    return typeof(CatchClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CatchDeclarationSyntax":
                    return typeof(CatchDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CatchFilterClauseSyntax":
                    return typeof(CatchFilterClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax":
                    return typeof(CompilationUnitSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorInitializerSyntax":
                    return typeof(ConstructorInitializerSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CrefParameterSyntax":
                    return typeof(CrefParameterSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CrefSyntax":
                    return typeof(CrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MemberCrefSyntax":
                    return typeof(MemberCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorMemberCrefSyntax":
                    return typeof(ConversionOperatorMemberCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IndexerMemberCrefSyntax":
                    return typeof(IndexerMemberCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NameMemberCrefSyntax":
                    return typeof(NameMemberCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OperatorMemberCrefSyntax":
                    return typeof(OperatorMemberCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedCrefSyntax":
                    return typeof(QualifiedCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeCrefSyntax":
                    return typeof(TypeCrefSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ElseClauseSyntax":
                    return typeof(ElseClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax":
                    return typeof(EqualsValueClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ExplicitInterfaceSpecifierSyntax":
                    return typeof(ExplicitInterfaceSpecifierSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax":
                    return typeof(ExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax":
                    return typeof(AnonymousFunctionExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax":
                    return typeof(AnonymousMethodExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax":
                    return typeof(LambdaExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax":
                    return typeof(ParenthesizedLambdaExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax":
                    return typeof(SimpleLambdaExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectCreationExpressionSyntax":
                    return typeof(AnonymousObjectCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax":
                    return typeof(ArrayCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax":
                    return typeof(AssignmentExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AwaitExpressionSyntax":
                    return typeof(AwaitExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax":
                    return typeof(BinaryExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CastExpressionSyntax":
                    return typeof(CastExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax":
                    return typeof(CheckedExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalAccessExpressionSyntax":
                    return typeof(ConditionalAccessExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalExpressionSyntax":
                    return typeof(ConditionalExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationExpressionSyntax":
                    return typeof(DeclarationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DefaultExpressionSyntax":
                    return typeof(DefaultExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ElementAccessExpressionSyntax":
                    return typeof(ElementAccessExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ElementBindingExpressionSyntax":
                    return typeof(ElementBindingExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax":
                    return typeof(ImplicitArrayCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitElementAccessSyntax":
                    return typeof(ImplicitElementAccessSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax":
                    return typeof(ImplicitStackAllocArrayCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax":
                    return typeof(InitializerExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InstanceExpressionSyntax":
                    return typeof(InstanceExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionSyntax":
                    return typeof(BaseExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ThisExpressionSyntax":
                    return typeof(ThisExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax":
                    return typeof(InterpolatedStringExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax":
                    return typeof(InvocationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IsPatternExpressionSyntax":
                    return typeof(IsPatternExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax":
                    return typeof(LiteralExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MakeRefExpressionSyntax":
                    return typeof(MakeRefExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax":
                    return typeof(MemberAccessExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MemberBindingExpressionSyntax":
                    return typeof(MemberBindingExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax":
                    return typeof(ObjectCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OmittedArraySizeExpressionSyntax":
                    return typeof(OmittedArraySizeExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedExpressionSyntax":
                    return typeof(ParenthesizedExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax":
                    return typeof(PostfixUnaryExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PrefixUnaryExpressionSyntax":
                    return typeof(PrefixUnaryExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax":
                    return typeof(QueryExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RangeExpressionSyntax":
                    return typeof(RangeExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RefExpressionSyntax":
                    return typeof(RefExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeExpressionSyntax":
                    return typeof(RefTypeExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RefValueExpressionSyntax":
                    return typeof(RefValueExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SizeOfExpressionSyntax":
                    return typeof(SizeOfExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.StackAllocArrayCreationExpressionSyntax":
                    return typeof(StackAllocArrayCreationExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionSyntax":
                    return typeof(SwitchExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ThrowExpressionSyntax":
                    return typeof(ThrowExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TupleExpressionSyntax":
                    return typeof(TupleExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeOfExpressionSyntax":
                    return typeof(TypeOfExpressionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax":
                    return typeof(TypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax":
                    return typeof(ArrayTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax":
                    return typeof(NameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax":
                    return typeof(AliasQualifiedNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax":
                    return typeof(QualifiedNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SimpleNameSyntax":
                    return typeof(SimpleNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax":
                    return typeof(GenericNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax":
                    return typeof(IdentifierNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax":
                    return typeof(NullableTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OmittedTypeArgumentSyntax":
                    return typeof(OmittedTypeArgumentSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PointerTypeSyntax":
                    return typeof(PointerTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax":
                    return typeof(PredefinedTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeSyntax":
                    return typeof(RefTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TupleTypeSyntax":
                    return typeof(TupleTypeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax":
                    return typeof(ExternAliasDirectiveSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax":
                    return typeof(FinallyClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringContentSyntax":
                    return typeof(InterpolatedStringContentSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringTextSyntax":
                    return typeof(InterpolatedStringTextSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationSyntax":
                    return typeof(InterpolationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationAlignmentClauseSyntax":
                    return typeof(InterpolationAlignmentClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationFormatClauseSyntax":
                    return typeof(InterpolationFormatClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.JoinIntoClauseSyntax":
                    return typeof(JoinIntoClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax":
                    return typeof(MemberDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseFieldDeclarationSyntax":
                    return typeof(BaseFieldDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EventFieldDeclarationSyntax":
                    return typeof(EventFieldDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax":
                    return typeof(FieldDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseMethodDeclarationSyntax":
                    return typeof(BaseMethodDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorDeclarationSyntax":
                    return typeof(ConstructorDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax":
                    return typeof(ConversionOperatorDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax":
                    return typeof(DestructorDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax":
                    return typeof(MethodDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax":
                    return typeof(OperatorDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BasePropertyDeclarationSyntax":
                    return typeof(BasePropertyDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EventDeclarationSyntax":
                    return typeof(EventDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax":
                    return typeof(IndexerDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax":
                    return typeof(PropertyDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeDeclarationSyntax":
                    return typeof(BaseTypeDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax":
                    return typeof(EnumDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax":
                    return typeof(TypeDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax":
                    return typeof(ClassDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax":
                    return typeof(InterfaceDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax":
                    return typeof(StructDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax":
                    return typeof(DelegateDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax":
                    return typeof(EnumMemberDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax":
                    return typeof(GlobalStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IncompleteMemberSyntax":
                    return typeof(IncompleteMemberSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax":
                    return typeof(NamespaceDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NameColonSyntax":
                    return typeof(NameColonSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax":
                    return typeof(NameEqualsSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax":
                    return typeof(OrderingSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax":
                    return typeof(ParameterSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax":
                    return typeof(PatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConstantPatternSyntax":
                    return typeof(ConstantPatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationPatternSyntax":
                    return typeof(DeclarationPatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DiscardPatternSyntax":
                    return typeof(DiscardPatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RecursivePatternSyntax":
                    return typeof(RecursivePatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.VarPatternSyntax":
                    return typeof(VarPatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PositionalPatternClauseSyntax":
                    return typeof(PositionalPatternClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PropertyPatternClauseSyntax":
                    return typeof(PropertyPatternClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QueryBodySyntax":
                    return typeof(QueryBodySyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QueryClauseSyntax":
                    return typeof(QueryClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.FromClauseSyntax":
                    return typeof(FromClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.JoinClauseSyntax":
                    return typeof(JoinClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax":
                    return typeof(LetClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax":
                    return typeof(OrderByClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.WhereClauseSyntax":
                    return typeof(WhereClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.QueryContinuationSyntax":
                    return typeof(QueryContinuationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SelectOrGroupClauseSyntax":
                    return typeof(SelectOrGroupClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.GroupClauseSyntax":
                    return typeof(GroupClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SelectClauseSyntax":
                    return typeof(SelectClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax":
                    return typeof(StatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax":
                    return typeof(BlockSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BreakStatementSyntax":
                    return typeof(BreakStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CheckedStatementSyntax":
                    return typeof(CheckedStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CommonForEachStatementSyntax":
                    return typeof(CommonForEachStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax":
                    return typeof(ForEachStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax":
                    return typeof(ForEachVariableStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ContinueStatementSyntax":
                    return typeof(ContinueStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DoStatementSyntax":
                    return typeof(DoStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax":
                    return typeof(EmptyStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionStatementSyntax":
                    return typeof(ExpressionStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.FixedStatementSyntax":
                    return typeof(FixedStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ForStatementSyntax":
                    return typeof(ForStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.GotoStatementSyntax":
                    return typeof(GotoStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IfStatementSyntax":
                    return typeof(IfStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LabeledStatementSyntax":
                    return typeof(LabeledStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax":
                    return typeof(LocalDeclarationStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax":
                    return typeof(LocalFunctionStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax":
                    return typeof(LockStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ReturnStatementSyntax":
                    return typeof(ReturnStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax":
                    return typeof(SwitchStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax":
                    return typeof(ThrowStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TryStatementSyntax":
                    return typeof(TryStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.UnsafeStatementSyntax":
                    return typeof(UnsafeStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax":
                    return typeof(UsingStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.WhileStatementSyntax":
                    return typeof(WhileStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.YieldStatementSyntax":
                    return typeof(YieldStatementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.StructuredTriviaSyntax":
                    return typeof(StructuredTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax":
                    return typeof(DirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BadDirectiveTriviaSyntax":
                    return typeof(BadDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.BranchingDirectiveTriviaSyntax":
                    return typeof(BranchingDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalDirectiveTriviaSyntax":
                    return typeof(ConditionalDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ElifDirectiveTriviaSyntax":
                    return typeof(ElifDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.IfDirectiveTriviaSyntax":
                    return typeof(IfDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ElseDirectiveTriviaSyntax":
                    return typeof(ElseDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DefineDirectiveTriviaSyntax":
                    return typeof(DefineDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EndIfDirectiveTriviaSyntax":
                    return typeof(EndIfDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.EndRegionDirectiveTriviaSyntax":
                    return typeof(EndRegionDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ErrorDirectiveTriviaSyntax":
                    return typeof(ErrorDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectiveTriviaSyntax":
                    return typeof(LineDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.LoadDirectiveTriviaSyntax":
                    return typeof(LoadDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.NullableDirectiveTriviaSyntax":
                    return typeof(NullableDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PragmaChecksumDirectiveTriviaSyntax":
                    return typeof(PragmaChecksumDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningDirectiveTriviaSyntax":
                    return typeof(PragmaWarningDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ReferenceDirectiveTriviaSyntax":
                    return typeof(ReferenceDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.RegionDirectiveTriviaSyntax":
                    return typeof(RegionDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ShebangDirectiveTriviaSyntax":
                    return typeof(ShebangDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.UndefDirectiveTriviaSyntax":
                    return typeof(UndefDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.WarningDirectiveTriviaSyntax":
                    return typeof(WarningDirectiveTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DocumentationCommentTriviaSyntax":
                    return typeof(DocumentationCommentTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SkippedTokensTriviaSyntax":
                    return typeof(SkippedTokensTriviaSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax":
                    return typeof(SubpatternSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionArmSyntax":
                    return typeof(SwitchExpressionArmSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchLabelSyntax":
                    return typeof(SwitchLabelSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CasePatternSwitchLabelSyntax"
                    :
                    return typeof(CasePatternSwitchLabelSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.CaseSwitchLabelSyntax":
                    return typeof(CaseSwitchLabelSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax":
                    return typeof(DefaultSwitchLabelSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax":
                    return typeof(SwitchSectionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TupleElementSyntax":
                    return typeof(TupleElementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax":
                    return typeof(TypeArgumentListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax":
                    return typeof(TypeParameterConstraintClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintSyntax":
                    return typeof(TypeParameterConstraintSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ClassOrStructConstraintSyntax":
                    return typeof(ClassOrStructConstraintSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax":
                    return typeof(ConstructorConstraintSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeConstraintSyntax":
                    return typeof(TypeConstraintSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax":
                    return typeof(TypeParameterListSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax":
                    return typeof(TypeParameterSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax":
                    return typeof(UsingDirectiveSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax":
                    return typeof(VariableDeclarationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax":
                    return typeof(VariableDeclaratorSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.VariableDesignationSyntax":
                    return typeof(VariableDesignationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.DiscardDesignationSyntax":
                    return typeof(DiscardDesignationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax":
                    return typeof(ParenthesizedVariableDesignationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.SingleVariableDesignationSyntax":
                    return typeof(SingleVariableDesignationSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.WhenClauseSyntax":
                    return typeof(WhenClauseSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax":
                    return typeof(XmlAttributeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlCrefAttributeSyntax":
                    return typeof(XmlCrefAttributeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameAttributeSyntax":
                    return typeof(XmlNameAttributeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlTextAttributeSyntax":
                    return typeof(XmlTextAttributeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementEndTagSyntax":
                    return typeof(XmlElementEndTagSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementStartTagSyntax":
                    return typeof(XmlElementStartTagSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameSyntax":
                    return typeof(XmlNameSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlNodeSyntax":
                    return typeof(XmlNodeSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlCDataSectionSyntax":
                    return typeof(XmlCDataSectionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlCommentSyntax":
                    return typeof(XmlCommentSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementSyntax":
                    return typeof(XmlElementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlEmptyElementSyntax":
                    return typeof(XmlEmptyElementSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlProcessingInstructionSyntax":
                    return typeof(XmlProcessingInstructionSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlTextSyntax":
                    return typeof(XmlTextSyntax);

                case "Microsoft.CodeAnalysis.CSharp.Syntax.XmlPrefixSyntax":
                    return typeof(XmlPrefixSyntax);


                default:
                    throw new Exception($"Unable to find: {node.GetType()}");
            }
        }
    }
}
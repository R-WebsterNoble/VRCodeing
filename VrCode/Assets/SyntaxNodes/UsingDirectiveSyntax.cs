using System;
using Microsoft.CodeAnalysis;
using NodeComponents;
using UnityEngine;

namespace SyntaxNodes
{
    public class UsingDirectiveSyntax : CSharpSyntaxNode
    {
        public override string DisplayString => "using";

        public GameObject ChildAp;
        public GameObject BottomAp;

        public override void InitComponents()
        {
            ChildAp.GetComponent<AttachmentPoint>().Attached += AttachChildAp;
            name = GetType().ToString().Replace("SyntaxNodes.", "");


            //var thing = (GameObject) Instantiate(Resources.Load("Using"), transform);
            //thing.name = "UsingPrefab";

            //Draggable.Anchor = thing.gameObject.GetComponentInParent<Anchor>()?.AnchorObj;

            //GameObject textObject = (GameObject)Instantiate(Resources.Load("Clickable"));
            //textObject.transform.parent = transform;
            //textObject.GetComponent<Clickable>().Clicked += (sender, args) => { SetName(); };
            base.InitLine();
        }

        private void AttachChildAp(object sender, Node other)
        {
            if (other.SyntaxNode is Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax selectedName)
            {
                var newNode = ((Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax)SyntaxNode).WithName(selectedName);
                RootNode.ReplaceNode(SyntaxNode, newNode);

                if (other.gameObject != null)
                    Destroy(other.gameObject);
            }
            else
            {
                Debug.Log($"Couldn't attach {other.DisplayString} to {DisplayString}");
            }
        }

        public override void Attach(Node other)
        {
            if (other.SyntaxNode is Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax selectedName)
            {
                var newNode = ((Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax) SyntaxNode).WithName(selectedName);
                RootNode.ReplaceNode(SyntaxNode, newNode);

                if (other.gameObject != null)
                    Destroy(other.gameObject);
            }
            else
            {
                Debug.Log($"Couldn't attach {other.DisplayString} to {DisplayString}");
            }
        }
    }
}
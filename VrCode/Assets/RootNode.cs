using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine;

namespace Assets
{
    public class Node : MonoBehaviour
    {
        public SyntaxNode SyntaxNode { get; set; }
        public Transform Parent { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public LineRenderer Line { get; set; }

        public Vector3 screenPoint;
        public Vector3 offset;

        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        }

        void OnMouseDrag()
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;

            UpdateLine();
        }

        public void UpdateLine()
        {
            Line.SetPositions(new[] { transform.position, Parent.position });
            foreach (var child in Children)
            {
                child.UpdateLine();
            }
        }
    }

    public class RootNode : MonoBehaviour
    {
        //private Dictionary<SyntaxNode, GameObject> _nodes = new Dictionary<SyntaxNode, GameObject>();


        // Start is called before the first frame update
        void Start()
        {
            SyntaxTree helloWorld = new CodeEditor().Gen();
            InstantiateNode(gameObject.transform, helloWorld.GetRoot());

            //var memberAccessNode = (MemberAccessExpressionSyntax)helloWorld.GetRoot().ChildNodes().ElementAt(1)
            //    .ChildNodes().ElementAt(1).ChildNodes().First().ChildNodes().ElementAt(2).ChildNodes().First()
            //    .ChildNodes().First().ChildNodes().First();

            //var node = _nodes[memberAccessNode].;
            //_nodes.TryGetValue(node.Parent, out var ga);

            //var syntaxNodeParent = ga.GetComponent<Node>().SyntaxNode.Parent;
            //_nodes.TryGetValue(syntaxNodeParent, out var ga2);
        }

        private Node InstantiateNode(Transform parentTransform, SyntaxNode node)
        {
            var nodeText = node.GetType().ToString()
                .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "")
                .Replace("Syntax", "");

            var newNode = new GameObject(nodeText);
            var nodeScript = newNode.AddComponent<Node>();
            nodeScript.SyntaxNode = node;
            nodeScript.Parent = parentTransform;
            //_nodes[node] = newNode;

            newNode.transform.parent = parentTransform;
            newNode.transform.localPosition = new Vector3(0, -2, 0);

            var text = newNode.AddComponent<TextMesh>();
            text.text = nodeText;
            var box = newNode.AddComponent<BoxCollider>();

            var textBounds = text.GetComponent<Renderer>().bounds;
            //box.center = textBounds.center;
            box.size = textBounds.size;

            var line = newNode.AddComponent<LineRenderer>();
            line.SetPositions(new[]{ newNode.transform.position , parentTransform.position});
            nodeScript.Line = line;

            foreach (var childNode in node.ChildNodes())
            {
                var newChildNode = InstantiateNode(newNode.transform, childNode);
                nodeScript.Children.Add(newChildNode);
            }

            return nodeScript;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

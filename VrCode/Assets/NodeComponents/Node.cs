using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using UnityEngine;

namespace NodeComponents
{
    public abstract class Node : MonoBehaviour
    {
        public List<Node> Children { get; set; } = new List<Node>();
        public Node Parent { get; set; }
        public Node RootNode { get; set; }

        public SyntaxNode SyntaxNode { get; set; }

        public AttachmentPoint ChildAp;

        public virtual int Height { get; set; }

        public Transform Anchor;

        private Vector3 _childApInitialPosition;

        public virtual int ThisNodeHeight => 1;

        public void SetPosition(Node parent)
        {
            Height = ThisNodeHeight;
            _childApInitialPosition = ChildAp.transform.localPosition;

            Parent = parent;
            gameObject.transform.parent = parent.transform;

            var offset = parent.ChildAp.transform.position - Anchor.gameObject.transform.position;
            gameObject.transform.Translate(offset);
        }

        public virtual string DisplayString => SyntaxNode.GetType().ToString()
            .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "")
            .Replace("Syntax", "");

        public void AttachChildren(IEnumerable<SyntaxNode> nodes)
        {
            foreach (var childNode in nodes)
            {
                var newChildNode = CreateTree(childNode, RootNode);

                NewAttachmentPoint(newChildNode);
                ChildAp.transform.Translate(0, -newChildNode.Height, 0);

                Height += newChildNode.Height;
                Children.Add(newChildNode);
            }

            ChildrenAttached();
        }

        private void NewAttachmentPoint(Node newChildNode)
        {
            var newChildAp = Instantiate(Resources.Load<AttachmentPoint>("AttachmentPoint"), transform);

            var sendMouseEventsTo = newChildAp.GetComponent<SendMouseEventsTo>();
            //if (sendMouseEventsTo != null)
                sendMouseEventsTo.Node = this;

            newChildAp.tag = "ClonedAP";
            newChildAp.transform.localPosition = ChildAp.transform.localPosition;

            var attachmentPoint = newChildAp.GetComponent<AttachmentPoint>();
            attachmentPoint.Child = newChildNode;
        }

        public virtual void ChildrenAttached()
        {
        }

        public Node CreateTree(SyntaxNode node, Node rootNode)
        {
            var nodeScript = InstantiateSyntaxNode(node, rootNode);

            nodeScript.SetPosition(this);

            nodeScript.InitComponents();

            nodeScript.AttachChildren(node.ChildNodes());

            return nodeScript;
        }

        public virtual void InitComponents()
        {
            throw new NotImplementedException();
        }

        // rootNode: null root to make this a new root
        public static Node InstantiateSyntaxNode(SyntaxNode rosNode, [CanBeNull] Node rootNode)
        {
            var nodeName = rosNode.GetType().ToString()
                .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "");

            var nodePrefab = Resources.Load("SyntaxNodePrefabs/" + nodeName) ??
                             Resources.Load("DefaultNode");

            //if(nodePrefab != null)
            //{
            var newNode = (GameObject) Instantiate(nodePrefab, rootNode?.transform);
            var nodeScript = newNode.GetComponent<Node>();
            //var syntaxNodeType = SyntaxNodeLookup.LookupType(rosNode);
            //nodeScript = (Node)newNode.AddComponent(syntaxNodeType);
            //}
            //else
            //{
            //    nodePrefab = Resources.Load("DefaultNode");
            //    newNode = new GameObject();
            //    var type = SyntaxNodeLookup.LookupType(rosNode);
            //    nodeScript = (Node)newNode.AddComponent(type);
            //    //var nodeScript = newNode.GetComponent<Node>();

            //    var rigidBody = newNode.AddComponent<Rigidbody>();
            //    rigidBody.isKinematic = true;
            //}

            nodeScript.RootNode = rootNode ?? nodeScript;
            nodeScript.SyntaxNode = rosNode;

            return nodeScript;
        }

        public void ReplaceNode(SyntaxNode oldNode, SyntaxNode newNode)
        {
            if (RootNode != this)
                throw new Exception("Only call ReplaceNode on Root Node");

            var newTreeRoot = SyntaxNode.ReplaceNode(oldNode, newNode);
            RebuildTree(newTreeRoot);
        }

        public void RebuildTree(SyntaxNode newRootNode)
        {
            SyntaxNode = newRootNode;
            foreach (var child in Children)
                if (child != null && child.gameObject != null)
                    Destroy(child.gameObject);

            foreach (var ap in GetComponentsInChildren<AttachmentPoint>().Where(ap => ap.tag == "ClonedAP"))
            {
                Destroy(ap.gameObject);
            }

            Height = ThisNodeHeight;
            ChildAp.transform.localPosition = _childApInitialPosition;
            Children = new List<Node>();
            AttachChildren(newRootNode.ChildNodes());
        }

        public virtual SyntaxNode TryAttach(Node targetNode, AttachmentPoint targetAp)
        {
            return null;
        }

        public virtual void Attach(Node other, AttachmentPoint ap)
        {
        }

        public void Detach()
        {
            try
            {
                var oldRootNode = RootNode;
                var newRootRosNode = RootNode.SyntaxNode.RemoveNode(SyntaxNode, SyntaxRemoveOptions.KeepExteriorTrivia);
                
                Parent.Children.Remove(this);
                RootNode = this;
                Parent = null;
                transform.parent = null;
                SetNewRootInAllChildren(this);
                void SetNewRootInAllChildren(Node node)
                {
                    foreach (var child in node.Children)
                    {
                        child.RootNode = this;
                        SetNewRootInAllChildren(child);
                    }
                }
                oldRootNode.RebuildTree(newRootRosNode);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        private Vector3 _screenPoint;
        private Vector3 _offset;

        private GameObject _closestNode;
        private Vector3 _startPos;

        private const float DetachSqrDist = 3;

        [UsedImplicitly]
        public void OnMouseDown()
        {
            _startPos = gameObject.transform.position;

            _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            _offset = gameObject.transform.position -
                      Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                          _screenPoint.z));

            //var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();
        }

        [UsedImplicitly]
        public void OnMouseDrag()
        {
            var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);

            var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
            var movement = curPosition - transform.position;

            var rb = GetComponent<Rigidbody>();
            rb.MovePosition(rb.transform.position + movement);

            if (RootNode != this && (_startPos - transform.position).sqrMagnitude > DetachSqrDist)
                Detach();

            if (Anchor != null) FindClosestNode();
        }

        [UsedImplicitly]
        public void OnMouseUp()
        {
            if (_closestNode == null)
            {
                if (RootNode != this)
                {
                    // Reset node position if not attached or detached
                    gameObject.transform.position = _startPos;
                }
                return;
            }

            _closestNode.GetComponent<Renderer>().material.color = Color.white;

            var targetAp = _closestNode.gameObject.GetComponent<AttachmentPoint>();
            var targetNode = _closestNode.gameObject.GetComponentInParent<Node>();

            targetNode.Attach(this, targetAp);
        }

        private static readonly Collider[] SnapOntoNearbyTargets = new Collider[100];

        private void FindClosestNode()
        {
            var objCount = Physics.OverlapSphereNonAlloc(
                Anchor.transform.position,
                3f,
                SnapOntoNearbyTargets,
                1 << 9,
                QueryTriggerInteraction.Ignore);

            var closestTargetDist = float.PositiveInfinity;
            GameObject newClosestNode = null;
            for (var index = 0; index < objCount; index++)
            {
                var target = SnapOntoNearbyTargets[index];
                if (target == null)
                    break;

                if (target.gameObject.GetComponentInParent<Node>().RootNode == RootNode)
                    continue;

                var directionToTarget = Anchor.transform.position - target.transform.position;
                var distToTarget = directionToTarget.sqrMagnitude;
                if (distToTarget < closestTargetDist)
                {
                    closestTargetDist = distToTarget;
                    newClosestNode = target.gameObject;
                }
            }

            if (newClosestNode != null)
            {
                if (newClosestNode != _closestNode)
                {
                    if (_closestNode != null)
                        _closestNode.GetComponent<Renderer>().material.color = Color.white;

                    var targetAp = newClosestNode.gameObject.GetComponent<AttachmentPoint>();
                    var targetNode = newClosestNode.gameObject.GetComponentInParent<Node>();
                    if(newClosestNode.gameObject.GetComponentInParent<Node>().TryAttach(targetNode, targetAp) != null)
                        newClosestNode.GetComponent<Renderer>().material.color = Color.green;
                }
            }
            else
            {
                //Nothing found. Clear out previous results
                if (_closestNode != null)
                    _closestNode.GetComponent<Renderer>().material.color = Color.white;
                _closestNode = null;
            }
            _closestNode = newClosestNode;
        }
    }
}
using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class Draggable : MonoBehaviour
    {
        public Node Node;
        public GameObject Anchor;
        public Vector3 ScreenPoint;
        public Vector3 Offset;

        private GameObject _closestNode;
        private Vector3 _startPos;

        const float DetachSqrDist = 3;

        [UsedImplicitly]
        public void OnMouseDown()
        {
            _startPos = gameObject.transform.position;

            ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));
            //var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();
        }

        [UsedImplicitly]
        public void OnMouseDrag()
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + Offset;

            var movement = curPosition - transform.position;
            foreach (var rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.MovePosition(rb.transform.position + movement);
            }
            
            Node.UpdateLine();


            if (Node.RootNode != Node && (_startPos - transform.position).sqrMagnitude > DetachSqrDist)
            {
                Node.Detach();
            }

            if (Anchor != null)
            {
                FindClosestNode();
            }
        }

        [UsedImplicitly]
        public void OnMouseUp()
        {
            if(_closestNode == null)
                return;

            var target = _closestNode.gameObject.GetComponentInParent<Node>();

            if (_closestNode.gameObject.GetComponent<AttachmentPoint>().SendToParent && target.Parent != null)
                target = target.Parent.gameObject.GetComponentInParent<Node>();

            target.Attach(Node);
        }


        static readonly Collider[] SnapOntoNearbyTargets = new Collider[100];
        private void FindClosestNode()
        {
            Physics.OverlapSphereNonAlloc(
                Anchor.transform.position,
                5f,
                SnapOntoNearbyTargets,
                1 << 9,
                QueryTriggerInteraction.Ignore);

            float closestTargetDist = float.PositiveInfinity;
            foreach (var target in SnapOntoNearbyTargets)
            {
                if(target == null)
                    break;

                if (target.gameObject.GetComponentInParent<Draggable>() == this)
                    continue;

                Vector3 directionToTarget = Anchor.transform.position - target.transform.position;
                float distToTarget = directionToTarget.sqrMagnitude;
                if (distToTarget < closestTargetDist)
                {
                    closestTargetDist = distToTarget;
                    _closestNode = target.gameObject;
                }
            }

            if (float.IsPositiveInfinity(closestTargetDist))
                _closestNode = null; //Nothing found. Clear out previous results
        }
    }
}

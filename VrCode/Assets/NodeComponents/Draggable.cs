using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class Draggable : MonoBehaviour
    {
        public Node Node;
        public Transform Anchor;
        public Vector3 ScreenPoint;
        public Vector3 Offset;

        private GameObject _closestNode;
        private Vector3 _startPos;

        private const float DetachSqrDist = 3;

        [UsedImplicitly]
        public void OnMouseDown()
        {
            _startPos = gameObject.transform.position;

            ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            Offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                         ScreenPoint.z));
            //var root = GameObject.FindGameObjectWithTag("GameController").GetComponent<RootNode>();
        }

        [UsedImplicitly]
        public void OnMouseDrag()
        {
            var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);

            var curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + Offset;

            var movement = curPosition - transform.position;
            foreach (var rb in GetComponentsInChildren<Rigidbody>()) rb.MovePosition(rb.transform.position + movement);

            Node.UpdateLine();


            if (Node.RootNode != Node && (_startPos - transform.position).sqrMagnitude > DetachSqrDist) Node.Detach();

            if (Anchor != null) FindClosestNode();
        }

        [UsedImplicitly]
        public void OnMouseUp()
        {
            if (_closestNode == null)
                return;

            var target = _closestNode.gameObject.GetComponent<AttachmentPoint>();
            target.Attach(Node);
        }


        private static readonly Collider[] SnapOntoNearbyTargets = new Collider[100];

        private void FindClosestNode()
        {
            Physics.OverlapSphereNonAlloc(
                Anchor.transform.position,
                5f,
                SnapOntoNearbyTargets,
                1 << 9,
                QueryTriggerInteraction.Ignore);

            var closestTargetDist = float.PositiveInfinity;
            foreach (var target in SnapOntoNearbyTargets)
            {
                if (target == null)
                    break;

                if (target.gameObject.GetComponentInParent<Draggable>() == this)
                    continue;

                var directionToTarget = Anchor.transform.position - target.transform.position;
                var distToTarget = directionToTarget.sqrMagnitude;
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
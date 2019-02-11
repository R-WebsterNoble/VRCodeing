using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public Node Node;
    public GameObject Anchor;
    public Vector3 ScreenPoint;
    public Vector3 Offset;

    [UsedImplicitly]
    public void OnMouseDown()
    {
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

        if (Anchor != null)
        {
            SnapOnto();
        }
    }

    [UsedImplicitly]
    public void OnMouseUp()
    {
        if(_closestNode == null)
            return;

        var target = _closestNode.gameObject.GetComponentInParent<Node>();

        if (_closestNode.gameObject.GetComponent<AttachmentPoint>().SendToParent)
            target = target.transform.parent.gameObject.GetComponentInParent<Node>();

        target.Attach(Node);
    }


    static readonly Collider[] SnapOntoNearbyTargets = new Collider[100];
    private GameObject _closestNode;

    private void SnapOnto()
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

            if (target.gameObject.GetComponentInParent<Dragable>() == this)
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

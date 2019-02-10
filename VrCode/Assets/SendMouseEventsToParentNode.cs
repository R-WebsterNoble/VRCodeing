using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SendMouseEventsToParentNode : MonoBehaviour
{
    public Node Parent;

    [UsedImplicitly]
    void Awake()
    {
        Parent = gameObject.GetComponentInParent<Node>();
    }

    [UsedImplicitly]
    public void OnMouseDown()
    {
        Parent.OnMouseDown();
    }

    [UsedImplicitly]
    public void OnMouseDrag()
    {
        Parent.OnMouseDrag();
    }
}

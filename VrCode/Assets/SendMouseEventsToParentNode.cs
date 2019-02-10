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
        var currentParent = gameObject;
        do
        {
            currentParent = currentParent.transform.parent.gameObject;
            Parent = currentParent.GetComponent<Node>();
        } while (Parent == null);
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

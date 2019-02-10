using JetBrains.Annotations;
using UnityEngine;

public class AttachmentPoint : MonoBehaviour
{
    public Node Node;
    public bool SendToParent = false;

    [UsedImplicitly]
    void Awake()
    {
        Node = gameObject.GetComponentInParent<Node>();
        Node.AttachmentPoint = this;
    }

    [UsedImplicitly]
    void OnTriggerEnter(Collider col)
    {
        var other = col.gameObject.GetComponentInParent<Node>();

        if (SendToParent)
            other = other.transform.parent?.gameObject.GetComponentInParent<Node>();

        other?.Attach(Node);
    }
}

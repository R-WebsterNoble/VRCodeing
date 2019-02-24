using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class AttachmentPoint : MonoBehaviour
    {
        public Node Node;
        public bool SendToParent = false;

        [UsedImplicitly]
        private void Awake()
        {
            Node = gameObject.GetComponentInParent<Node>();
            Node.AttachmentPoint = this;
        }

        [UsedImplicitly]
        private void OnTriggerEnter(Collider col)
        {
            var other = col.gameObject.GetComponentInParent<Node>();

            if (SendToParent)
                other = other.transform.parent?.gameObject.GetComponentInParent<Node>();

            other?.Attach(Node);
        }
    }
}
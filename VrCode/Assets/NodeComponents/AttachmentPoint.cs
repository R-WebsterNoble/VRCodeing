using System;
using UnityEngine;

namespace NodeComponents
{
    public class AttachmentPoint : MonoBehaviour
    {
        public Node Child;
        public event EventHandler<(Node Other, Node Child)> Attached;

        public void Attach(Node other)
        {
            Attached?.Invoke(this, (other, Child));
        }
    }
}
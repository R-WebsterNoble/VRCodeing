using System;
using UnityEngine;

namespace NodeComponents
{
    public class AttachmentPoint : MonoBehaviour
    {
        public event EventHandler<Node> Attached;

        public void Attach(Node other)
        {
            Attached?.Invoke(this, other);
        }
    }
}
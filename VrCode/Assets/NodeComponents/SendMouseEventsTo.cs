using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class SendMouseEventsTo : MonoBehaviour
    {
        public Node Node;

        [UsedImplicitly]
        public void OnMouseDown()
        {
            Node.OnMouseDown();
        }

        [UsedImplicitly]
        public void OnMouseUp()
        {
            Node.OnMouseUp();
        }

        [UsedImplicitly]
        public void OnMouseDrag()
        {
            Node.OnMouseDrag();
        }
    }
}
using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class SendMouseEventsToParentNode : MonoBehaviour
    {
        public Node Parent;

        [UsedImplicitly]
        private void Awake()
        {
            if(Parent == null)
                Parent = gameObject.GetComponentInParent<Node>();
        }

        [UsedImplicitly]
        public void OnMouseDown()
        {
            Parent.Draggable.OnMouseDown();
        }

        [UsedImplicitly]
        public void OnMouseDrag()
        {
            Parent.Draggable.OnMouseDrag();
        }
    }
}
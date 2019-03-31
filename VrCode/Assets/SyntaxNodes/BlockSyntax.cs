using UnityEngine;

namespace SyntaxNodes
{
    public class BlockSyntax : StatementSyntax
    {
        public GameObject TopRect;
        public TextMesh Text;
        public Transform BottomRect;
        public GameObject MiddleRect;

        private const int ThisNodeHeight = 5;
        private const float TextMargin = 0.5f;

        public override int Height { get; set; } = ThisNodeHeight;

        public override string DisplayString { get; } = "Block_";

        public override void InitComponents()
        {
            name = DisplayString;
        }

        public override void ChildrenAttached()
        {
            Text.text = DisplayString;

            var textBounds = Text.GetComponent<Renderer>().bounds;

            TopRect.transform.localScale = new Vector3(
                textBounds.extents.x * 2 + TextMargin * 2,
                TopRect.transform.localScale.y,
                TopRect.transform.localScale.z);

            TopRect.transform.position = new Vector3(
                textBounds.center.x,
                TopRect.transform.position.y,
                TopRect.transform.position.z);


            var t = -(Height - ThisNodeHeight);
            MiddleRect.transform.Translate(0, t / 2.0f, 0);
            BottomRect.transform.Translate(0, t, 0);

            var h = Height / ThisNodeHeight;
            MiddleRect.transform.localScale = new Vector3(
                MiddleRect.transform.localScale.x,
                MiddleRect.transform.localScale.y * (-1f + 2f * h),
                MiddleRect.transform.localScale.z);
        }
    }
}
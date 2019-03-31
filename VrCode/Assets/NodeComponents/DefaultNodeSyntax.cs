using UnityEngine;

namespace NodeComponents
{
    public class DefaultNodeSyntax : Node
    {
        public GameObject TopRect;
        public TextMesh Text;
        public Transform BottomRect;
        public GameObject MiddleRect;

        private const int ThisNodeHeight = 5;
        private const float TextMargin = 0.5f;

        public override int Height { get; set; } = ThisNodeHeight;

        private Vector3 _topInitialPosition;
        private Vector3 _topInitialScale;
        private Vector3 _middleInitialPosition;
        private Vector3 _middleInitialScale;
        private Vector3 _bottomInitialPosition;
        private Vector3 _bottomInitialScale;


        public override void InitComponents()
        {
            _topInitialPosition = TopRect.transform.localPosition;
            _topInitialScale = TopRect.transform.localScale;
            _middleInitialPosition = MiddleRect.transform.localPosition;
            _middleInitialScale = MiddleRect.transform.localScale;
            _bottomInitialPosition = BottomRect.transform.localPosition;
            _bottomInitialScale = BottomRect.transform.localScale;

            name = SyntaxNode.GetType().ToString()
                       .Replace("Microsoft.CodeAnalysis.CSharp.Syntax.", "") + " (Default)";
        }

        public override void ChildrenAttached()
        {
            TopRect.transform.localPosition = _topInitialPosition;
            TopRect.transform.localScale = _topInitialScale;
            MiddleRect.transform.localPosition = _middleInitialPosition;
            MiddleRect.transform.localScale = _middleInitialScale;
            BottomRect.transform.localPosition = _bottomInitialPosition;
            BottomRect.transform.localScale = _bottomInitialScale;

            Text.text = DisplayString;

            var textBounds = Text.GetComponent<Renderer>().bounds;

            TopRect.transform.localScale = new Vector3(
                textBounds.extents.x *2 + TextMargin *2,
                TopRect.transform.localScale.y,
                TopRect.transform.localScale.z);

            TopRect.transform.position = new Vector3(
                textBounds.center.x,
                TopRect.transform.position.y,
                TopRect.transform.position.z);


            var t = -(Height - ThisNodeHeight);
            MiddleRect.transform.Translate(0,t/2.0f,0);
            BottomRect.transform.Translate(0,t,0);

            var h = Height / ThisNodeHeight;
            MiddleRect.transform.localScale = new Vector3(
                    MiddleRect.transform.localScale.x,
                    MiddleRect.transform.localScale.y * (-1f + 2f * h),
                    MiddleRect.transform.localScale.z);
        }
    }
}

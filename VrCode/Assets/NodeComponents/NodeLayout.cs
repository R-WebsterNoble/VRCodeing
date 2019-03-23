using UnityEngine;

namespace NodeComponents
{
    partial class Node
    {

        public virtual int Height { get; set; } = 1;

        private void SetPosition(Node nodeScript)
        {
            nodeScript.Parent = this;
            nodeScript.gameObject.transform.parent = transform;
            nodeScript.gameObject.transform.localPosition = new Vector3(1, Height * -2, 0);
        }

        private void InitVisualComponents(string displayName)
        {
            var text = gameObject.AddComponent<TextMesh>();
            text.text = displayName;
            var box = gameObject.AddComponent<BoxCollider>();

            var textBounds = text.GetComponent<Renderer>().bounds;
            box.size = textBounds.size;
        }

        public virtual void InitLine()
        {
            if (Parent == null)
                return;

            var line = gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Unlit/Texture"));
            line.startColor = Color.grey;
            line.endColor = Color.grey;
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.SetPositions(new[]
            {
                gameObject.transform.position,
                Parent.transform.position + new Vector3(-0.25f, 0f, 0f)
            });

            Line = line;
        }

        public void UpdateLine()
        {
            if (Line != null)
                Line.SetPositions(new[] { transform.position, Parent.transform.position });

            foreach (var child in Children) child.UpdateLine();
        }
    }
}

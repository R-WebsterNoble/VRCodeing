using System;
using JetBrains.Annotations;
using UnityEngine;

namespace NodeComponents
{
    public class Clickable : MonoBehaviour
    {
        public event EventHandler Clicked;

        [UsedImplicitly]
        private void OnMouseDown()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
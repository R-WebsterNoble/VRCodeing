﻿using System;
using JetBrains.Annotations;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public event EventHandler Clicked;

    [UsedImplicitly]
    void OnMouseDown()
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

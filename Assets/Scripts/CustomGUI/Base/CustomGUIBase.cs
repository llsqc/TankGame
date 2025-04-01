using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_OnOff
{
    On,
    Off
}

public abstract class CustomGUIBase : MonoBehaviour
{
    public CustomGUIPos guiPos;

    public GUIContent content;

    public GUIStyle style;

    public E_Style_OnOff styleOnOrOff = E_Style_OnOff.Off;

    public void DrawGUI()
    {
        switch (styleOnOrOff)
        {
            case E_Style_OnOff.On:
                StyleOnDraw();
                break;
            case E_Style_OnOff.Off:
                StyleOffDraw();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected abstract void StyleOnDraw();
    protected abstract void StyleOffDraw();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIBase
{
    public event UnityAction clickEvent;

    protected override void StyleOnDraw()
    {
        if (GUI.Button(guiPos.Pos, content.text, style))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOffDraw()
    {
        if (GUI.Button(guiPos.Pos, content.text))
        {
            clickEvent?.Invoke();
        }
    }
}
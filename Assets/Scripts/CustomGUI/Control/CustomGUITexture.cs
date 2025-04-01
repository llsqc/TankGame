using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUIBase
{
    public ScaleMode scaleMode = ScaleMode.StretchToFill;
    
    protected override void StyleOnDraw()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }

    protected override void StyleOffDraw()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }
}

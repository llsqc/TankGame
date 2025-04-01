using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_SliderType
{
    Horizontal,
    Vertical
}

public class CustomGUISlider : CustomGUIBase
{
    public float minValue = 0;
    public float maxValue = 1;
    public float nowValue = 0;

    public E_SliderType sliderType = E_SliderType.Horizontal;

    public GUIStyle styleThumb;

    public event UnityAction<float> changeValue;

    private float oldValue = 0;

    protected override void StyleOnDraw()
    {
        switch (sliderType)
        {
            case E_SliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
            case E_SliderType.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
        }

        if (oldValue != nowValue)
        {
            changeValue?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }

    protected override void StyleOffDraw()
    {
        switch (sliderType)
        {
            case E_SliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case E_SliderType.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
        }

        if (oldValue != nowValue)
        {
            changeValue?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }
}
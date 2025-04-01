using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Alignment_Type
{
    Left,
    Right,
    Center,
    Top,
    Bottom,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}

[System.Serializable]
public class CustomGUIPos
{
    private Rect rPos = new Rect(0, 0, 100, 100);

    public E_Alignment_Type ScreenAlignmentType = E_Alignment_Type.Center;

    public E_Alignment_Type WidgetAlignmentType = E_Alignment_Type.Center;

    public Vector2 pos;

    public float width = 100;
    public float height = 100;

    private Vector2 centerPos;

    public void CalcCenterPos()
    {
        switch (WidgetAlignmentType)
        {
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Top:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Bottom:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.TopLeft:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.TopRight:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.BottomLeft:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.BottomRight:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CalcPos()
    {
        switch (ScreenAlignmentType)
        {
            case E_Alignment_Type.Left:
                rPos.x = centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height / 2 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Top:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = 0 + +centerPos.y + pos.y;
                break;
            case E_Alignment_Type.Bottom:
                rPos.x = Screen.width / 2 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.TopLeft:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.TopRight:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = 0 + centerPos.y + pos.y;
                break;
            case E_Alignment_Type.BottomLeft:
                rPos.x = 0 + centerPos.x + pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            case E_Alignment_Type.BottomRight:
                rPos.x = Screen.width + centerPos.x - pos.x;
                rPos.y = Screen.height + centerPos.y - pos.y;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Rect Pos
    {
        get
        {
            CalcCenterPos();
            CalcPos();
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}

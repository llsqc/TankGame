using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIBase[] allControls;

    void Start()
    {
        allControls = this.GetComponentsInChildren<CustomGUIBase>();
    }


    public void OnGUI()
    {
        if (!Application.isPlaying)
        {
            allControls = this.GetComponentsInChildren<CustomGUIBase>();
        }

        for (int i = 0; i < allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
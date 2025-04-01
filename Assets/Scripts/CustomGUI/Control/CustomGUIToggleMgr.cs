using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleMgr : MonoBehaviour
{
    public CustomGUIToggle[] toggles;

    private CustomGUIToggle selectedToggle;

    void Start()
    {
        if (toggles.Length == 0)
        {
            return;
        }

        for (int i = 0; i < toggles.Length; i++)
        {
            CustomGUIToggle toggle = toggles[i];
            toggle.changeValue += (value) =>
            {
                if (value)
                {
                    for (int j = 0; j < toggles.Length; j++)
                    {
                        if (toggles[j] != toggle)
                        {
                            toggles[j].isSel = false;
                        }
                    }

                    selectedToggle = toggle;
                }
                else if (toggle == selectedToggle)
                {
                    toggle.isSel = true;
                }
            };
        }
    }
}
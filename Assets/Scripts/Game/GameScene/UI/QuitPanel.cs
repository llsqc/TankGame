using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnContinue;
    public CustomGUIButton btnClose;

    void Start()
    {
        btnQuit.clickEvent += () => { SceneManager.LoadScene("BeginScene"); };
        btnContinue.clickEvent += () => { HideMe(); };
        btnClose.clickEvent += () => { HideMe(); };
        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;

    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;

    public CustomGUITexture texHP;

    public float hpWidth = 350;

    [HideInInspector] public int nowScore = 0;

    [HideInInspector] public float nowTime = 0f;

    private int time;

    void Start()
    {
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };

        btnQuit.clickEvent += () =>
        {
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        
        AddScore(100);
        UpdateHP(100, 30);
    }

    void Update()
    {
        nowTime += Time.deltaTime;
        labTime.content.text = "";
        time = (int)nowTime;
        
        if (time >= 3600)
        {
            labTime.content.text += $"{time / 3600}时";
        }

        if (time % 3600 >= 60 || labTime.content.text != "")
        {
            labTime.content.text += $"{time % 3600 / 60}分";
        }

        labTime.content.text += $"{time % 60}秒";
    }

    public void AddScore(int score)
    {
        nowScore = score;
        labScore.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpWidth;
    }
}
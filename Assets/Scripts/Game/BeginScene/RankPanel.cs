using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    private List<CustomGUILabel> labPlayerName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            labPlayerName.Add(this.transform.Find($"PlayerName/labPlayerName ({i})").GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find($"Score/labScore ({i})").GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find($"Time/labTime ({i})").GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };

        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }


    public void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.rankList;

        for (int i = 0; i < list.Count; i++)
        {
            labPlayerName[i].content.text = list[i].name;
            labScore[i].content.text = list[i].score.ToString();

            int time = (int)list[i].time;
            labTime[i].content.text = "";
            if (time >= 3600)
            {
                labTime[i].content.text += $"{time / 3600}时";
            }

            if (time % 3600 >= 60 || labTime[i].content.text != "")
            {
                labTime[i].content.text += $"{time % 3600 / 60}分";
            }

            labTime[i].content.text += $"{time % 60}秒";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleSound;

    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeMusicVolume(value);

        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundVolume(value);

        toggleMusic.changeValue += (value) => GameDataMgr.Instance.OpenCloseMusic(value);

        toggleSound.changeValue += (value) => GameDataMgr.Instance.OpenCloseSound(value);

        btnClose.clickEvent += () =>
        {
            HideMe();
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                //让开始面板重新显示出来
                BeginPanel.Instance.ShowMe();
            }
        };

        HideMe();
    }

    public void UpdatePanelInfo()
    {
        MusicData musicData = GameDataMgr.Instance.musicData;

        sliderSound.nowValue = musicData.soundVolume;
        sliderMusic.nowValue = musicData.musicVolume;
        toggleMusic.isSel = musicData.isMusicOn;
        toggleSound.isSel = musicData.isSoundOn;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
}
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
                BeginPanel.Instance.ShowMe();
            }
        };

        HideMe();
    }

    private void UpdatePanelInfo()
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

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
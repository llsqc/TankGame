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
        sliderMusic.changeValue += (value) => { };

        sliderSound.changeValue += (value) => { };

        toggleMusic.changeValue += (value) => { };

        toggleSound.changeValue += (value) => { };

        btnClose.clickEvent += () =>
        {
            HideMe();
            if(SceneManager.GetActiveScene().name == "BeginScene")
            {
                //让开始面板重新显示出来
                BeginPanel.Instance.ShowMe();
            }
        };
        
        HideMe();
    }
}
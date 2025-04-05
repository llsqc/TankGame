using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr _instance = new GameDataMgr();

    public static GameDataMgr Instance => _instance;

    public MusicData musicData;

    public RankData rankData;

    private GameDataMgr()
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        if (!musicData.isInit)
        {
            musicData.isInit = true;
            musicData.isSoundOn = true;
            musicData.isMusicOn = true;
            musicData.musicVolume = 1f;
            musicData.soundVolume = 1f;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }

        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankData), "Rank") as RankData;
    }

    public void AddRankInfo(string name, int score, float time)
    {
        rankData.rankList.Add(new RankInfo(name, score, time));
        rankData.rankList.Sort((x, y) => y.time.CompareTo(x.time));
        if (rankData.rankList.Count > 10)
        {
            rankData.rankList.RemoveRange(10, rankData.rankList.Count - 10);
        }

        PlayerPrefsDataMgr.Instance.SaveData(rankData, "Rank");
    }

    public void OpenCloseMusic(bool isOpen)
    {
        musicData.isMusicOn = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    public void OpenCloseSound(bool isOpen)
    {
        musicData.isSoundOn = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    public void ChangeMusicVolume(float volume)
    {
        musicData.musicVolume = volume;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    public void ChangeSoundVolume(float volume)
    {
        musicData.soundVolume = volume;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic _instance;

    public static BKMusic Instance => _instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        _instance = this;
        _audioSource = this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.musicVolume);
        ChangeOpen(GameDataMgr.Instance.musicData.isMusicOn);
    }

    public void ChangeValue(float value)
    {
        _audioSource.volume = value;
    }

    public void ChangeOpen(bool isOpen)
    {
        _audioSource.mute = !isOpen;
    }
}
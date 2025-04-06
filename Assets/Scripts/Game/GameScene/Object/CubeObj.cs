using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjects;

    public GameObject deadEff;
    
    private void OnTriggerEnter(Collider other)
    {
        int rangeInt = Random.Range(0, 100);
        if (rangeInt < 50)
        {
            rangeInt = Random.Range(0, rewardObjects.Length);
            Instantiate(rewardObjects[rangeInt], transform.position, transform.rotation);
        }
        
        GameObject obj = Instantiate(deadEff, transform.position, transform.rotation);
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSoundOn;
        
        Destroy(gameObject);
    }
}

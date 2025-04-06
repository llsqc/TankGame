using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;

    public GameObject getEff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index = Random.Range(0, weaponObj.Length);
            
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.SetWeapon(weaponObj[index]);
            
            GameObject eff = Instantiate(getEff, transform.position, transform.rotation);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSoundOn;
            
            Destroy(gameObject);
        }
    }
}
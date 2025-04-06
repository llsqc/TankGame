using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum E_PropType
{
    Atk,
    Def,
    MaxHP,
    HP
}


public class PropReward : MonoBehaviour
{
    public E_PropType propType;

    public int changeValue = 2;
    
    public GameObject getEff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();

            switch (propType)
            {
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.MaxHP:
                    player.maxHP += changeValue;
                    GamePanel.Instance.UpdateHP(player.maxHP, player.hp);
                    break;
                case E_PropType.HP:
                    player.hp += changeValue;
                    if (player.hp > player.maxHP)
                    {
                        player.hp = player.maxHP;
                    }

                    GamePanel.Instance.UpdateHP(player.maxHP, player.hp);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            GameObject eff = Instantiate(getEff, transform.position, transform.rotation);
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSoundOn;

            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;

    public TankBaseObj owner;

    public GameObject effObj;
    
    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube") ||
            other.gameObject.CompareTag("Player") && owner.gameObject.CompareTag("Monster") ||
            other.gameObject.CompareTag("Monster") && owner.gameObject.CompareTag("Player"))
        {
            TankBaseObj otherObj = other.GetComponent<TankBaseObj>();
            if (otherObj)
            {
                otherObj.Wound(owner);
            }
            
            if (effObj)
            {
                GameObject eff = Instantiate(effObj, transform.position, transform.rotation);
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicData.isSoundOn;
            }

            Destroy(gameObject);
        }
    }

    public void SetOwner(TankBaseObj obj)
    {
        owner = obj;
    }
}
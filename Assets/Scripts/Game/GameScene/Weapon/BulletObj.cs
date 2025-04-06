using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;

    public TankBaseObj owner;

    public GameObject effObj;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
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
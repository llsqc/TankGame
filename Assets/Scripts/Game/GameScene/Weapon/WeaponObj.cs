using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;
    
    public Transform[] firePoints;
    
    public TankBaseObj owner;

    public void SetOwner(TankBaseObj obj)
    {
        owner = obj;
    }
    
    public void Fire()
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            GameObject obj = Instantiate(bullet, firePoints[i].position, firePoints[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetOwner(owner);
        }
    }
}

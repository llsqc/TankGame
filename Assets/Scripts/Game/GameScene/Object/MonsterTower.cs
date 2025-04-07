using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    public float fireOffsetTime = 1;

    private float _nowTime;

    public Transform[] firePos;

    public GameObject bulletObj;

    void Update()
    {
        _nowTime += Time.deltaTime;
        if (_nowTime > fireOffsetTime)
        {
            _nowTime = 0;
            Fire();
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < firePos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, firePos[i].position, firePos[i].rotation);
            obj.GetComponent<BulletObj>().SetOwner(this);
        }
    }

    public override void Wound(TankBaseObj other)
    {
    }
}
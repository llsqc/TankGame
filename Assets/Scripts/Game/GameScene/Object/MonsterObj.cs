using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MonsterObj : TankBaseObj
{
    private Transform targetPos;

    public Transform[] randomPos;

    public Transform lookAtTarget;

    public float fireDis = 5;

    public float fireOffsetTime = 1;
    private float nowTime;

    public Transform[] firePos;
    public GameObject bulletObj;

    public Texture maxHpBack;
    public Texture hpBack;

    private Rect maxHpRect;
    private Rect hpRect;

    private float showTime = 0;

    void Start()
    {
        RandomPos();
    }

    void Update()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(transform.position, targetPos.position) < 0.1f)
        {
            RandomPos();
        }

        if (lookAtTarget)
        {
            tankHead.LookAt(lookAtTarget);

            if (Vector3.Distance(transform.position, lookAtTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    nowTime = 0;
                    Fire();
                }
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }

        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Fire()
    {
        for (int i = 0; i < firePos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, firePos[i].position, firePos[i].rotation);
            obj.GetComponent<BulletObj>().SetOwner(this);
        }
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;

            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            screenPoint.y = Screen.height - screenPoint.y;

            maxHpRect.x = screenPoint.x - 50;
            maxHpRect.y = screenPoint.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect, maxHpBack);

            hpRect.x = screenPoint.x - 50;
            hpRect.y = screenPoint.y - 50;
            hpRect.width = hp * 1.0f / maxHP * 100;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect, hpBack);
        }
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;

    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * (moveSpeed * Time.deltaTime)));
        transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * (roundSpeed * Time.deltaTime)));

        tankHead.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * (headRoundSpeed * Time.deltaTime)));

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if (nowWeapon)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        base.Dead();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHP(maxHP, hp);
    }

    public void SetWeapon(GameObject weapon)
    {
        if (nowWeapon)
        {
            Destroy(nowWeapon.gameObject);
        }

        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetOwner(this);
    }
}
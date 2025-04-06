using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
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
        throw new System.NotImplementedException();
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage = 10;

    public float Damage
    {
        get { return damage; }
        set
        {
            damage = value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3f);
    }
}

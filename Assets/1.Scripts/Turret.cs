using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    float attackDelay = 3f;
    float attacTime = 0;
    Character character;

    // Update is called once per frame
    void Update()
    {
        //FindEnemy();
    }

    void FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(character.charData.findTag);
        if (objs.Length == 0)
            return;
        float distance = 10f;
        GameObject target = null;
        foreach (var obj in objs)
        {
            float dis = Vector3.Distance(parent.transform.position, obj.transform.position);
            target = obj;
            distance = dis;
        }
        float targetPosition = Vector3.Distance(transform.position, target.transform.position);
        if (target == null)
            return;
        if (targetPosition > distance)
        {
            parent.transform.LookAt(target.transform);
            Attack();
        }
    }

    void Attack()
    {
        attacTime += Time.deltaTime;
        if (attacTime > attackDelay)
        {
            attacTime = 0;
            StartCoroutine("BulletCreat");
        }
    }
    IEnumerator BulletCreat()
    {
        GameObject bullet = Instantiate(prefab, parent);
        yield return new WaitForSeconds(1f);
    }
}

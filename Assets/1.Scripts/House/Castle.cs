using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Castle : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float curHP;

    [SerializeField] private Image hpImage;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    float attackDelay = 3f;
    float attacTime = 0;
    Character character;
    
    public float HP
    {
        get { return curHP; }
        set
        {
            curHP = value;
            hpImage.fillAmount = curHP / maxHp;
            if(curHP <= 0)
            {
                Destroy(gameObject);
                if(gameObject.name.Equals("MainHouse"))
                {
                    Time.timeScale = 0;
                    Debug.Log("Stage Clear!!");
                }
            }
        }
    }
    void Start()
    {
        curHP = maxHp;
    }

    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(character.charData.findTag);
        if (objs.Length == 0)
            return;
        float distance = 10f;
        GameObject target = null;
        foreach(var obj in objs)
        {
            float dis = Vector3.Distance(parent.transform.position, obj.transform.position);
            target = obj;
            distance = dis;
        }
        float targetPosition = Vector3.Distance(parent.transform.position, target.transform.position);
        if (target == null)
            return;
        if(targetPosition < distance)
        {
            parent.transform.LookAt(target.transform);
            Attack();
        }
    }

    void Attack()
    {
        attacTime += Time.deltaTime;
        if(attacTime > attackDelay)
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

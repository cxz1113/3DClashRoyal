using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public struct CharacterData
{
    public string findTag;
}
public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    [SerializeField] Image hpImage;
    public NavMeshAgent agent;
    public Animator animator;
    public CardData cardData;

    float curHP = 0;
    float maxHP = 0;
    float attDelay = 0;

    public virtual void Initialize()
    {
        curHP = cardData.HP;
        maxHP = cardData.HP;
    }

    // Update is called once per frame
    void Update()
    {
        {
            // 태그까지 이동
            GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.findTag);
            if (characters.Length == 0)
                return;

            float distance = 50f;
            GameObject findTarget = null;
            foreach (var character in characters)
            {

                // 거리값 계산
                float dis = Vector3.Distance(agent.transform.position, character.transform.position);
                if (distance > dis)
                { 
                    findTarget = character;
                    distance = dis;
                }
            }

            if (findTarget == null)
                return;

            if (cardData.AttRange < distance)
            {
                // 에이전트를 이용하여 타겟으로 이동
                agent.SetDestination(findTarget.transform.position);
                animator.SetTrigger("run");
            }
            else
            {
                animator.SetTrigger("idle");
                agent.SetDestination(transform.position);
                transform.LookAt(findTarget.transform);
                animator.SetTrigger("attack");
                attDelay += Time.deltaTime;
                if (attDelay > cardData.AttDelay)
                {
                    // attDelay를 Time.delta 이용하여 HP빼기
                    attDelay = 0;
                    if (findTarget.GetComponent<Castle>())
                    {
                        findTarget.GetComponent<Castle>().HP -= cardData.Damage;
                    }
                    else if (findTarget.GetComponent<Character>())
                    {
                        findTarget.GetComponent<Character>().Damage(cardData.Damage);
                    }
                }
            }
        }
    }

    public void Damage(float damage)
    {
        if (curHP <= 0)
            return;
        curHP -= damage;
        hpImage.fillAmount = curHP / maxHP;
        // hp가 0일때 이벤트
        if(curHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public struct CharacterData
{
    public string findTag;
    public float attRange;
}
public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public NavMeshAgent agent;
    public Animator animator;
    public CardData cardData;

    float attDelay = 0;
    // Update is called once per frame
    void Update()
    {
        // �±ױ��� �̵�
        GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.findTag);
        if (characters.Length == 0)
            return;

        float distance = 100f;
        GameObject findTarget = null;

        foreach(var character in characters)
        {
            // �Ÿ��� ���
            float dis = Vector3.Distance(agent.transform.position, character.transform.position);
            if (distance > dis)
            {
                findTarget = character;
                distance = dis;
            }
        }

        if (findTarget == null)
            return;

        if(charData.attRange < distance)
        {
            // ������Ʈ�� �̿��Ͽ� Ÿ������ �̵�
            agent.SetDestination(findTarget.transform.position);
            animator.SetTrigger("run");
        }
        else
        {
            animator.SetTrigger("idle");
            agent.SetDestination(transform.position);
            animator.SetTrigger("attack");
            if(attDelay > cardData.AttDelay)
            {
                attDelay = 0;
                if(findTarget.GetComponent<Castle>() != null)
                {
                    findTarget.GetComponent<Castle>().HP -= cardData.Damage;
                }
                else if(findTarget.GetComponent<Character>())
                {

                }
            }
        }
    }
}

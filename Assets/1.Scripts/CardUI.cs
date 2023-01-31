using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IDragHandler, IDropHandler 
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject cardBackGround;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Image image;
    [SerializeField] private Canvas canvas;

    CardData cardData;
    RaycastHit hit;
    public int Cost { get; set; }
    public bool Empty { get; set; }

    /*private float maxHP;
    private float curHP;
    public float HP
    {
        get { return curHP; }
        set { curHP = value; }
    }
    Image image;
    public void HP1(int value, bool isPlus = true)
    {
        if(isPlus)
            curHP += value;
        else
            curHP -= value;
        float curTmpHP = curHP / maxHP;
        image.fillAmount = curTmpHP;
        costText.text = $"{curHP}/{maxHP}";
    }*/
    void Start()
    {
        btn.onClick.AddListener(OnButtonSpawn);
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
        costText.text = Cost.ToString();
    }
    void OnButtonSpawn()
    {
        // 카드 생성 및 몬스터 생성
        /*if(ControllerManager.Instance.uiCont.IsEnergyCheck(cardData.Cost) == true)
        {
            ControllerManager.Instance.uiCont.Energy -= cardData.Cost;
            Character character = Instantiate(cardData.Cha, parent);
            character.cardData = cardData;
            character.tag = "my";
            character.charData.findTag = "enemy";
            Enable(false);
            Empty = true;           
        }        
        ControllerManager.Instance.cardCont.Invoke("AddCard", 1f);*/
    }


    public CardUI Enable(bool isActive)
    {
        cardBackGround.SetActive(isActive);        
        return this;
    }

    public CardUI SetParent(Transform parent)
    {
        this.parent = parent;
        return this;
    }

    public CardUI SetCardData(CardData cardData)
    {
        this.cardData = cardData;
        image.sprite = cardData.Sprite;
        Cost = cardData.Cost;
        Empty = false;
        return this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(hit.transform == null)
        {
            StartCoroutine("CardPosInit");
            return;
        }
        if(ControllerManager.Instance.uiCont.IsEnergyCheck(cardData.Cost)  == true)
        {
            if(hit.transform.tag.Equals("ray"))
            {
                
                ControllerManager.Instance.uiCont.Energy -= cardData.Cost;
                Character character = Instantiate(cardData.Cha, parent);
                character.cardData = cardData;
                character.tag = "my";
                character.charData.findTag = "enemy";
                character.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
                Enable(false);
                Empty = true;
                ControllerManager.Instance.cardCont.Invoke("AddCard", 1f);
            }
        }
        StartCoroutine("CardPosInit");
    }

    IEnumerator CardPosInit()
    {
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }
}

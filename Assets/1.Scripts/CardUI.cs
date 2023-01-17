using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private GameObject delayIcon;
    [SerializeField] private Image delayImage;
    [SerializeField] private TMP_Text delayText;

    void Start()
    {
        delayIcon.SetActive(false);
        btn.onClick.AddListener(OnButtonSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonSpawn()
    {
        if(delayImage.IsActive())
        {
            return;
        }
        delayIcon.SetActive(true);
        StartCoroutine(DelayImage(3));
        ControllerManager.Instance.spawn.Spawn();
    }

    IEnumerator DelayImage(float delay)
    {
        float max = delay;
        delayText.text = delay.ToString();
        while(true)
        {
            if(delay <= 0)
            {
                delayImage.fillAmount = 1f;
                delayIcon.SetActive(false);
                break;
            }
            delayImage.fillAmount = delay / max;
            delayText.text = string.Format("{0:0.0}", delay);
            delay -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

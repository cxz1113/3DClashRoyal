using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;
    public UIController uiCont;
    [SerializeField] CardController cardCont;
    // Start is called before the first frame update
    void Awake() => Instance = this;
}

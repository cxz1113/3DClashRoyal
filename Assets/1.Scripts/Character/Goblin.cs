using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : Character
{
    void Start()
    {
        charData.attRange = 1.5f;
        charData.findTag = "enemy";
    }

}

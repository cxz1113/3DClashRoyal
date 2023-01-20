using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Character
{
    void Start()
    {
        charData.attRange = 1.5f;
        charData.findTag = "enemy";
    }
}  

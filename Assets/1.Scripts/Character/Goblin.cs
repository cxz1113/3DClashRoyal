using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
    // Start is called before the first frame update
    void Start()
    {
        charData.attRange = 1.5f;
        charData.findTag = "enemy";
    }

}

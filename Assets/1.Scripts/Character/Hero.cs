using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    // Start is called before the first frame update
    void Start()
    {
        if (cardData.Pawn)
            charData.findTag = "enemy";
        else
            charData.findTag = "my";
    }
}

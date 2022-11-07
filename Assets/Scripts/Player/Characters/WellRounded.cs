using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellRounded : Player
{
    private void Awake()
    {
        maxHP += 5;
        speed += 5;
        harvesting += 8;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCollectibleScript : CollectibleSrcipt
{
    protected override void AlertManagerCollectibleWasPickedUp()
    {
        GetCollectibleManager().SuperCollectibleWasPickedUp(gameObject);
    }
}

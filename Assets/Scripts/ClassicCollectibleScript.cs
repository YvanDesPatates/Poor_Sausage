using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicCollectibleScript : CollectibleSrcipt
{
    protected override void AlertManagerCollectibleWasPickedUp()
    {
        GetCollectibleManager().CollectibleWasPickedUp(gameObject);
    }
}

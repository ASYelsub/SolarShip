using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Addition : P_Item
{
    public List<P_Item> requirements;

    public bool meetsBuildRequirement;

    public bool isBuilt;

    public C_Addition(ItemState itemState, int itemTypeID, int itemID) : base(itemState, itemTypeID, itemID)
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Where all the children item types are.
public class Items : MonoBehaviour{}
public class C_Grain : P_Item
{
    public C_Grain(ItemState itemState, int itemTypeID, int itemID)
        : base(itemState, itemTypeID, itemID)
    {
    }
}

public class C_Bucket : P_Item
{
    public C_Bucket(ItemState itemState, int itemTypeID, int itemID)
        : base(itemState, itemTypeID, itemID)
    {
    }
}
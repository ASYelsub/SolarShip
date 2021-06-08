using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Addition : P_Item
{
    //the six corners of the room
    Vector3[] corners;

    //the doors that are connected to the room
    List<C_Connector> doors;


    public C_Addition(ItemState itemState, int itemTypeID, int itemID) : base(itemState, itemTypeID, itemID)
    {
    }
}

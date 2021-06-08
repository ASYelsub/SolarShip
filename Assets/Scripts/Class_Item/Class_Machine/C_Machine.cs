using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A machine is something that can be opened and clicked around in OR something the player can go into
//from a chest to an alchemiter to a bed
//usually you put other items in the machine to do something to them.
public abstract class C_Machine : P_Item
{

    //placed in 3D space
    public GameObject machineObjectPrefab;
    //when in inventory
    public GameObject machineIconPrefab;
    public C_Machine(ItemState itemState, int itemTypeID, int itemID)
       : base(itemState, itemTypeID, itemID)
    {
    }
}

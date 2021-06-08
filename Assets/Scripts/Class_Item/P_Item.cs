using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class P_Item : MonoBehaviour
{
    //count of all items in game
    private int itemID;
    public int ItemID { get { return itemID; } set { itemID = value; } }

    //type of item
    private int itemTypeID;
    public int ItemTypeID { get { return itemTypeID; } set { itemTypeID = value; } }


    //if an item can be in a stack with itself, dependent on itemTypeID
    private bool canStack;
    

    public enum ItemState { inInventory, inHand, inWorld, inStorage}
    private ItemState iS;
    public ItemState IS { get{ return iS; } set { iS = value; } }


    //Specific to Item State is below this//


    //only used if item is in player's inventory
    private int invSlot;

    //only used if inWorld
    private Vector3 inWorldPosition;
    public Vector3 InWorldPosition { get { return inWorldPosition; } set { inWorldPosition = value; } }

    //only used if in player's hand
    private enum useState { overOtherObject, interactOtherObject, nothing}

    //only used if in inStorage
    private int storageSlot;
            //machine that item is stored in
    private C_Machine storedIn;


    public P_Item(ItemState itemState,int itemTypeID, int itemID)
    {
        this.iS = itemState;
        this.ItemTypeID = itemTypeID;
        this.ItemID = itemID;
    }

    public void TouchOtherItem3D()
    {

    }

    public void UnTouchOtherItem3D()
    {

    }

    public void SetInMachine()
    {

    }

    public void RemoveFromMachine()
    {

    }

   
}





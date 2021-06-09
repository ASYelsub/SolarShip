using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Room : C_Addition
{
    //the six corners of the room
    Vector3[] corners;

    //the doors that are connected to the room
    List<C_Connector> doors;

    public List<C_Machine> machines;

    

    public class MachineSlot
    {
        //probably four of these
        List<Vector3> machineSlotBase;

        public bool isFilled;
    }




    public CC_Room(ItemState itemState, int itemTypeID, int itemID) : base(itemState, itemTypeID, itemID)
    {
    }
}

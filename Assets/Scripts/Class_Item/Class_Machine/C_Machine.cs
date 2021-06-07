using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A machine is something that can be opened and clicked around in
//from a chest to an alchemiter
//usually you put other items in the machine to do something to them.
public class C_Machine : P_Item
{
    
    //Where you put items
    public class MachineSlot
    {
        enum machineSlotType {input,output,storage}

        machineSlotType thisMachineSlotType;

        public GameObject machineSlotPrefab;
    }

    public class MachineInterface
    {
        List<MachineSlot> machineSlots;
        bool hasText;
        string machineText;
        public GameObject machineInterfacePrefab;
    }

    [SerializeField]
    private MachineInterface thisInterface;

    //placed in 3D space
    public GameObject machineObjectPrefab;
    //when in inventory
    public GameObject machineIconPrefab;
    public C_Machine(ItemState itemState, int itemTypeID, int itemID)
       : base(itemState, itemTypeID, itemID)
    {
    }
}

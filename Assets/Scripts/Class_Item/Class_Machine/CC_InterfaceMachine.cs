using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_InterfaceMachine : C_Machine
{
    //Where you put items
    public class MachineSlot
    {
        enum machineSlotType { input, output, storage }

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

    public CC_InterfaceMachine(ItemState itemState, int itemTypeID, int itemID) : base(itemState, itemTypeID, itemID)
    {
    }
}

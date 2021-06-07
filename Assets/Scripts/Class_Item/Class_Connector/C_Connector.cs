using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Connector : P_Item
{
    public abstract class ConnectorSegment
    {
        float height;
        float width;
        float depth;
        Vector3 position;
        ConnectorSegment otherSegment1;
        ConnectorSegment otherSegment2;
        ConnectorDoor connectedDoor1;
        GameObject segmentPrefab;
    }
    public class ConnectorDoor
    {
        Vector3 topRight;
        Vector3 topLeft;
        Vector3 bottomRight;
        Vector3 bottomLeft;
        GameObject doorPrefab;
        bool isOpen;
        ConnectorSegment connectedSegment;
    }


    public ConnectorDoor door1;
    public ConnectorDoor door2;

    public int connectorLength;


    public C_Connector(ItemState itemState, int itemTypeID, int itemID) : base(itemState, itemTypeID, itemID)
    {
    }
}

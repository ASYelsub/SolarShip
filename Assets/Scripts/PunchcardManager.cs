﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchcardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject invSlotPrefab;
    [SerializeField]
    private GameObject canvas;

    LinkedList<P_Item> slots;
    //honestly the amount of punch card slots should be the same as the
    //amount of item types
    //but when a punch card is used the slot is now empty/different

    public bool punchCardIsExpanding;
    public void GeneratePunchCards(ItemGenerator IG)
    {
        punchCardIsExpanding = false;
        slots = IG.itemTypes;
        foreach (P_Item item in slots)
        {
            GameObject pC = Instantiate(invSlotPrefab, canvas.transform);
            RectTransform rt = pC.GetComponent<RectTransform>();
            rt.localPosition += new Vector3(0 , 45 - rt.sizeDelta.y/2.2f * item.ItemID);
            PunchCard ppp = pC.GetComponent<PunchCard>();
            ppp.onMake();
        }
    }
}

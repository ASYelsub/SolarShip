using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ItemGenerator IG;
    PunchcardManager PM;
    void Start()
    {
        IG = gameObject.GetComponent<ItemGenerator>();
        IG.GenerateItemTypes();
        PM = gameObject.GetComponent<PunchcardManager>();
        PM.GeneratePunchCards(IG);
    }

}

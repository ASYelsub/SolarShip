using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Holds all data and interacts with punchcard inventory prefab
public class PunchCard : MonoBehaviour
{
    [HideInInspector]
    public bool canPlace;
    [HideInInspector]
    public bool expanded;

    [Header("Components")]
    public GameObject slotParent;
    public GameObject invSlot;
    public GameObject invExpand;

    public GameObject punchCardImage;

    public GameObject punchCardNameBack;
    public GameObject punchCardName;
    public GameObject punchCardNameBack_CanPlace;
    public GameObject punchCardName_CanPlace;

    public GameObject punchCardChecksBack;
    public GameObject punchCardChecksBack_CanPlace;




   
    public void onMake()
    {
        canPlace = false;
        expanded = false;
        punchCardNameBack_CanPlace.SetActive(canPlace);
        punchCardName_CanPlace.SetActive(canPlace);
        punchCardChecksBack_CanPlace.SetActive(canPlace);
        invSlotTransform = invExpand.GetComponent<RectTransform>();
        deltaInit = invSlotTransform.sizeDelta;
        deltaFinal = deltaInit + new Vector3(0, 100, 0);
    }

    public void buttonInput(){
        if (expanded)
            StartCoroutine(collapseBack());
        else
            StartCoroutine(expandBack());
        expanded = !expanded;
    }

    private RectTransform invSlotTransform;
    private Vector3 deltaInit;
    private Vector3 deltaFinal;

    public IEnumerator expandBack()
    {
        
        float t = 0;

        while (t < 10)
        {
            invSlotTransform.sizeDelta = Vector3.Lerp(deltaInit, deltaFinal, t);
            t += .1f;
        }

        yield return null;
    }
    public IEnumerator collapseBack()
    {
        yield return null;
    }


}

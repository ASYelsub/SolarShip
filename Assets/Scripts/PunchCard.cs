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
    public GameObject invExpandFinal;

    public GameObject punchCardImage;

    public GameObject punchCardNameBack;
    public GameObject punchCardName;
    public GameObject punchCardNameBack_CanPlace;
    public GameObject punchCardName_CanPlace;

    public GameObject punchCardChecksBack;
    public GameObject punchCardChecksBack_CanPlace;

    public List<GameObject> invExpand2s;
    public List<GameObject> checkMarks;

    public float expandSpeed;

    PunchcardManager pcManager;
   
    public void onMake()
    {
        for (int i = 0; i < invExpand2s.Count; i++)
        {
            invExpand2s[i].SetActive(false);
        }
        for (int i = 0; i < checkMarks.Count; i++)
        {
            checkMarks[i].SetActive(false);
        }
        pcManager = FindObjectOfType<PunchcardManager>();
        canPlace = false;
        expanded = false;
        punchCardNameBack_CanPlace.SetActive(canPlace);
        punchCardName_CanPlace.SetActive(canPlace);
        punchCardChecksBack_CanPlace.SetActive(canPlace);
        invSlotTransform = invExpand.GetComponent<RectTransform>();
        deltaInit = invSlotTransform.sizeDelta;
        deltaFinal = invExpandFinal.GetComponent<RectTransform>().sizeDelta;
    }

    public void buttonInput(){
        if (!pcManager.punchCardIsExpanding)
        {
            pcManager.punchCardIsExpanding = true;
            if (expanded)
                StartCoroutine(collapseBack());
            else
                StartCoroutine(expandBack());
            expanded = !expanded;
            pcManager.punchCardIsExpanding = false;
        }
    }

    private RectTransform invSlotTransform;
    private Vector3 deltaInit;
    private Vector3 deltaFinal;

    public IEnumerator expandBack()
    {
        float t = 0;
        
        while (t < 1.5f)
        {
            invSlotTransform.sizeDelta = Vector3.Lerp(deltaInit, deltaFinal, t);
            t += expandSpeed * Time.deltaTime;
            yield return null;
        }


        for (int i = 0; i < invExpand2s.Count; i++)
        {invExpand2s[i].SetActive(true);}
        yield return null;
    }
    public IEnumerator collapseBack()
    {
        float t = 0;
        for (int i = 0; i < invExpand2s.Count; i++)
        {
            invExpand2s[i].SetActive(false);
        }
        while (t < 1.5f)
        {
            invSlotTransform.sizeDelta = Vector3.Lerp(deltaFinal, deltaInit, t);
            t += expandSpeed * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }


}

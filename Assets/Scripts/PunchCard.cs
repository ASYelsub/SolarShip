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
    public Image invSlot;
    public Image invExpand;

    public Image punchCardImage;

    public Image punchCardNameBack;
    public Text punchCardName;
    public Image punchCardNameBack_CanPlace;
    public Text punchCardName_CanPlace;

    public Image punchCardChecksBack;
    public Image punchCardChecksBack_CanPlace;




    private void Start()
    {
        punchCardNameBack_CanPlace.gameObject.SetActive(canPlace);
        punchCardName_CanPlace.gameObject.SetActive(canPlace);
        punchCardChecksBack_CanPlace.gameObject.SetActive(canPlace);
        invSlotTransform = invExpand.gameObject.GetComponent<RectTransform>();
        deltaInit = invSlotTransform.sizeDelta;
        deltaFinal = deltaInit + new Vector3(0, 10, 0);
    }

    public void buttonInput(){
        if (expanded)
            collapseBack();
        else
            expandBack();
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
    public void collapseBack()
    {

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    public Transform interactObj;

    [Range(0,180)]
    [SerializeField] private float cutoff = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cosAngle = Vector3.Dot((this.transform.position - interactObj.position).normalized, interactObj.forward);
        if (Mathf.Acos(cosAngle) * Mathf.Rad2Deg < cutoff)
        {
            Debug.Log("Looking");
        }
        else 
        {
            //Debug.Log("Not Looking");
        }
    }
}

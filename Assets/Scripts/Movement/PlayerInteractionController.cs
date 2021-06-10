using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [Header("Cutoff Values")]
    [Range(0, 180)]
    [SerializeField] private float visionCutoff = 20f; //in degrees

    [Range(0, 60)]
    [SerializeField] private float distanceCutoff = 20f; //The real unity unit measurement is the square root of this


    [Header("Make them Interactable")]
    [Header("Add Objects to this List to")]
    public List<Transform> interactObjects = new List<Transform>(); //storage of all interactable objects, not linked list for serializability


    //interior data storage for calculations
    private float cosAngle = 0;
    private Vector3 heading;
    private float distanceSquared;

    /// <summary>
    /// Each frame, check if the player is close enough to an object for look detection
    /// </summary>
    void Update()
    {
        //Loop through the interactable objects
        foreach (Transform interactObj in interactObjects)
        {
            //This is a distance calculation that omits calls to the vector3 class as well
            //as removes the square root calculation
            //The hope is that it is a very efficient calculation

            //form the heading vector
            heading.x = this.transform.position.x - interactObj.position.x;
            heading.y = this.transform.position.y - interactObj.position.y;
            heading.z = this.transform.position.z - interactObj.position.z;

            //do the distance calculation, without the square root
            distanceSquared = heading.x * heading.x + heading.y * heading.y + heading.z * heading.z;

            //check if the distance is within the cutoff value
            if (distanceSquared < distanceCutoff)
            {
                //Once we know the player is close enough we can check if they are looking at the object
                //We can do this by calculating the cosine of the angle between them
                //0 is looking perpendicular, 1 is looking directly at it, -1 is looking directly away
                cosAngle = Vector3.Dot((interactObj.position - this.transform.position).normalized, this.transform.forward);

                //then compare this to the vision cutoff we define in degrees
                //Rad2Deg is a constant so this multiplication to translate is fast
                if (Mathf.Acos(cosAngle) * Mathf.Rad2Deg < visionCutoff)
                {
                    //do something when looking at it
                    //TODO: make crosshair bigger
                    Debug.Log("Looking");
                }
                else
                {
                    //do something else
                    //TODO: Make crosshair smaller
                }
            }
        }
    }

    /// <summary>
    /// Adds the object interaction.
    /// </summary>
    /// <returns><c>true</c>, if object interaction was added, <c>false</c> otherwise.</returns>
    /// <param name="objToAdd">Object to add.</param>
    public bool AddObjectInteraction(Transform objToAdd)
    {
        int origSize = interactObjects.Count;
        interactObjects.Add(objToAdd);
        return origSize != interactObjects.Count;
    }
}

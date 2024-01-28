using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBTN : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public float yOffset = -50f; // Change this value to adjust the distance between the original and duplicated objects
    private GameObject lastClone;
    
    public void AdderBTN()
    {
      // Calculate the new position for the duplicated object
      Vector3 newPosition = objectToDuplicate.transform.position + new Vector3(0f, yOffset, 0f);
            
      if (lastClone != null)
      {
        newPosition = lastClone.transform.position + new Vector3(0f, yOffset, 0f);
      }

      // Instantiate a new copy of the object at the calculated position and the same rotation
      GameObject duplicatedObject = Instantiate(objectToDuplicate, newPosition, objectToDuplicate.transform.rotation);

      // Set the scale for the duplicated object
      //duplicatedObject.transform.localScale = new Vector3(1.082965675511211f, 1.082965675511211f, 1.082965675511211f);
      duplicatedObject.transform.localScale = new Vector3(1, 1, 1);

      // Parent the duplicated object to a specific GameObject
      duplicatedObject.transform.SetParent(objectToDuplicate.transform.parent);

      // Update the lastClone reference to the newly created clone
      lastClone = duplicatedObject;
    }
}

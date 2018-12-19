using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTargets : MonoBehaviour
{
    private static GameObject selectedObject;
    private static GameObject previousObject;
    private static Vector3 vrRetPos;

    void Start()
    {
        selectedObject = GameObject.Find("Player");
        if(selectedObject)
        {
            Debug.Log("Initializing game manager default target to: " + selectedObject.name);
            //temporarily for now
            selectedObject.GetComponent<CameraMouse>().selected = true;
        } else {
            Debug.LogError("Didn't find any player object, currently nothing is selected on game manager. Maybe place a Player onto the scene.");
        }


    }

    public static GameObject SelectedObject
    {
        get
        {
            return selectedObject;
        }

        set
        {
            if(value != null)
            {
                if(previousObject != selectedObject)
                {
                    //previousObject = false;
                    previousObject = selectedObject;
                }
                selectedObject = value;
                Debug.Log(value.name + " was selected");
            } else {
                selectedObject = null;
                Debug.Log("An object couldn't be set as an selected selected target. No worries");

            }
        }
    }

    public static Vector3 RetPos
    {
        get
        {
            return vrRetPos;
        }

        set
        {
            vrRetPos = value;
        }
    }

}

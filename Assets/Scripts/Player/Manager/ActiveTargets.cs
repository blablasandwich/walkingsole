using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTargets : MonoBehaviour
{
    private static GameObject selectedObject;
    private static GameObject previousObject;
    private static Vector3 vrRetPos;

    void Awake()
    {
        selectedObject = GameObject.Find("Player");
        previousObject = selectedObject;
        Debug.Log("previous: " + previousObject);
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
                if(previousObject != selectedObject && value.tag == "Player")
                {
                    previousObject.GetComponent<CameraMouse>().selected = false;
                    previousObject = selectedObject;

                    selectedObject = value;

                    selectedObject.GetComponent<CameraMouse>().selected = true;
                } else {
                    selectedObject = value.transform.root.gameObject;
                }

                Debug.Log(value.name + " was selected");
            } else {
                selectedObject = null;
               // Debug.Log("An object couldn't be set as an selected selected target. No worries");

            }
        }
    }

    public static GameObject PSelectedObject
    {
        get
        {
            return previousObject;
        }

        set
        {
            if(value != null)
            {
                Debug.Log("Previous Object shouldn't/can't be set");
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

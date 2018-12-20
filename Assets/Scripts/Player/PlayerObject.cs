using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerObject : InteractableObject
{
    //Function called from being pressed
    new public void DoAction()
    {
        //Pop up a menu or something
        Debug.Log(gameObject.name + " was Clicked");
    }
}

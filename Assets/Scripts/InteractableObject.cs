using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    UnityEvent interacted;

    void Awake()
    {
        if (interacted == null)
            interacted = new UnityEvent();

        interacted.AddListener(DoAction);
        Debug.Log("Wroks2");
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && ActiveTargets.SelectedObject == this.gameObject)
        {
            interacted.Invoke();
        }
    }

    void DoAction()
    {
        Debug.Log(gameObject.name + " Has done something.");
    }
}

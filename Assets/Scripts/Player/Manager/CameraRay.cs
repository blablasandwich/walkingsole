using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRay : MonoBehaviour
{
    public GameObject mainCamRoot;
    private RaycastHit hit;
    private Ray ray;
    public float maxRetDistance = 100.0f;
    private int layerMask;
    private RaycastResult gvrHit;
    void Start()
    {
        SetPossession(ActiveTargets.SelectedObject);

        //Aim at this specific target
        layerMask = 1 <<  LayerMask.NameToLayer("Interactable");
        gvrHit = GvrPointerInputModule.CurrentRaycastResult;
        //~ inverts bitmask to selectively aim at everything else besides player
        //layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("Previous: " + ActiveTargets.PSelectedObject);
        Debug.Log("Selected: " + ActiveTargets.SelectedObject);
        if(ActiveTargets.SelectedObject != gvrHit.gameObject && gvrHit.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * gvrHit.distance , Color.yellow);

            Debug.Log("New Selected: " + gvrHit.gameObject.name);
            ActiveTargets.SelectedObject = gvrHit.gameObject;
            ActiveTargets.RetPos = gvrHit.worldPosition;
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxRetDistance , Color.blue);
            ActiveTargets.SelectedObject = null;
        }

    }

    //Use this to possesss others
    public void SetPossession(GameObject other)
    {
        mainCamRoot.transform.SetParent(other.transform);
    }
}

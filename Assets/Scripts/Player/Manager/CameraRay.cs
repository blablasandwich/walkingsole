using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    public float maxRetDistance = 100.0f;
    private int layerMask;
    void Start()
    {


        //Aim at this specific target
        layerMask = 1 << LayerMask.NameToLayer("Player");

        //~ inverts bitmask to selectively aim at everything else besides player
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxRetDistance, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxRetDistance , Color.blue);
            Debug.Log(hit.point);
            ActiveTargets.RetPos = hit.point;
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance , Color.blue);
        }
    }
}

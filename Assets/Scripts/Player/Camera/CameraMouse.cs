using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    public GameObject head;
    public float speed = 1.0f;
    public float maxRayDistance = 10.0f;
    public bool selected = false;

    void Start()
    {
        Debug.Log(ActiveTargets.SelectedObject.name);
    }


    void FixedUpdate()
    {
        if(selected)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * maxRayDistance;
            //temp look at variable
            Vector3 ground = new Vector3(transform.position.x, 0, transform.position.z);
        	Plane playerPlane = new Plane(Vector3.up, ground);
            RaycastHit hit;

            //Aim at this specific target
            int layerMask = 1 << LayerMask.NameToLayer("Player");

            //~ inverts bitmask to selectively aim at everything else besides player
            layerMask = ~layerMask;

        	// Generate a ray from the cursor position
        	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        	float hitdist = 0.0f;

        	// Get the point along the ray that hits the calculated distance.
        	Vector3 targetBodyPoint = ActiveTargets.RetPos;
            Vector3 targetHeadPoint = ActiveTargets.RetPos;

            //temporary fix to keep body from tilting
            targetBodyPoint.y = transform.position.y;


        	// Determine the target rotation.  This is the rotation if the transform looks at the target point.
        	Quaternion targetBodyRotation = Quaternion.LookRotation(targetBodyPoint - transform.position);
            Quaternion targetHeadRotation = Quaternion.LookRotation(targetHeadPoint - head.transform.position);
            //targetBodyRotation.set(0, targetBodyRotation.rotation.y, 0);
        	// Smoothly rotate towards the target point.
        	transform.rotation = Quaternion.Slerp(transform.rotation, targetBodyRotation, speed * Time.deltaTime);
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, targetHeadRotation, speed * Time.deltaTime);



            if (Physics.Raycast(head.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(head.transform.position, head.transform.forward * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                if(ActiveTargets.SelectedObject != hit.transform.gameObject)
                {
                    ActiveTargets.SelectedObject = hit.transform.gameObject;
                }
            } else {
                Debug.DrawRay(head.transform.position, head.transform.TransformDirection(Vector3.forward) * 100, Color.white);
                Debug.Log("Did not Hit");

                ActiveTargets.SelectedObject = null;
            }
        }
    }

}

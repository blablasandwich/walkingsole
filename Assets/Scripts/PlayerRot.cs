using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRot : MonoBehaviour
{
    public Transform p;
    GameObject r;

    public GameObject body;
    public GameObject head;

    float smooth = 0.3f;
    float distance = 5.0f;
    float xVelocity = 0.0f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
       // p = GameObject.FindGameObjectWithTag("Body").transform;
      //  r = GameObject.Find("GvrReticlePointer");
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 lookDir = GvrPointerInputModule.CurrentRaycastResult.worldPosition - p.position;
        lookDir.y = 0; // keep only the horizontal direction
        p.rotation = Quaternion.LookRotation(lookDir);
        //  p.transform.rotation = new Quaternion(r.transform.rotation.w, r.transform.rotation.x, r.transform.rotation.y, r.transform.rotation.z);
        // p.transform.rotation.
        // float xAngle = Mathf.SmoothDampAngle(head.transform.eulerAngles.x, body.transform.eulerAngles.x, ref xVelocity, smooth);

        //  Vector3 position = head.transform.position;

        //   position += Quaternion.Euler(0, xAngle, 0) * new Vector3(0, 0, -distance);

        //body.transform.position = position;

    }
  //  GvrBasePointer.PointerRay
}

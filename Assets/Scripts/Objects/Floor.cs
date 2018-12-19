using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject body;
    public GameObject cube;
    public GameObject point;
    public GameObject cam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void test()
    {
        Debug.Log(point.GetComponent<GvrReticlePointer>().ReticleDistanceInMeters);


        player.transform.Translate(new Vector3(0, 0, point.GetComponent<GvrReticlePointer>().ReticleDistanceInMeters), body.transform);
        //player.transform.position = point.GetComponent<GvrReticlePointer>().PointerTransform.position;

        // = player.transform.forward + point.GetComponent<GvrReticlePointer>().ReticleDistanceInMeters;


    }


    public void exit()
        {
        Application.Quit();
        }

}

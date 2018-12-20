using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    private Transform body;
    public GameObject player;
    private GvrReticlePointer distance;

    void Start() {
       player = GameObject.FindGameObjectWithTag("Player");
       body = player.transform.GetChild(2).transform;
       distance = Camera.main.transform.GetChild(0).GetComponent<GvrReticlePointer>();
    }

    public void test() {
        player.transform.Translate(new Vector3(0, 0, distance.ReticleDistanceInMeters), body);
    }

    public void exit() {
        Application.Quit();
        }

}

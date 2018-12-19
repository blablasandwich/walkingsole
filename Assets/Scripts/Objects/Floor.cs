using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject player;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
     //   player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void test()
    {
        Debug.Log("test");
        player.transform.position = new Vector3 (cube.transform.position.x, player.transform.position.y, cube.transform.position.z); 
    }


    public void exit()
        {
        Application.Quit();
        }
}

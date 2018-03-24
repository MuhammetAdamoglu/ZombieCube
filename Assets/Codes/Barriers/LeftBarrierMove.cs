using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBarrierMove : MonoBehaviour {

    GameObject cube;
    Main main;
    float random;


	void Start () {
        cube = GameObject.Find("Cube");
        main = cube.GetComponent<Main>();
        random = Random.Range(14,17);
    }
	
	void Update () {

       

        if(transform.position.x<-random)
            transform.Translate(1, 0, 0, Space.World);

        if(transform.position.z<cube.transform.position.z)
            transform.Translate(-2, 0, 0, Space.World);

        transform.Translate(0, 0, -main.speed*Time.deltaTime, Space.World);


        if (transform.position.z < 0)
            Destroy(gameObject);
    }
}

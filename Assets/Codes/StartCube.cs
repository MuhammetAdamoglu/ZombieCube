using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCube : MonoBehaviour {

    Main main;
    GameObject cubeEye;

	void Start () {
        main = GetComponent<Main>();
        cubeEye = GameObject.Find("CubeEyes");
	}
	
	void Update () {

        if (main.start)
        {

            if (transform.position.z > 16)
            {
                main.stop = false;
            }
            else
            {
                transform.Translate(0, 0, main.speed * Time.deltaTime / 5, Space.World);
           
            }

          
            if (cubeEye.transform.rotation.y > 0)
            {
                cubeEye.transform.Rotate(0, -main.speed*2, 0);
            }
            else
            {
                cubeEye.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
           


        
    }
}

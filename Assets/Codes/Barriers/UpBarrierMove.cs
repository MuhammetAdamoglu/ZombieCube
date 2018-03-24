using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBarrierMove : MonoBehaviour
{

    GameObject cube;
    Main main;
    float random;


    void Start()
    {
        cube = GameObject.Find("Cube");
        main = cube.GetComponent<Main>();

    }

    void Update()
    {

     

        if (transform.position.y < 0)
            transform.Translate(0, 1, 0, Space.World);
        if (transform.position.z < cube.transform.position.z)
            transform.Translate(0, -5, 0, Space.World);

        transform.Translate(0, 0, -main.speed * Time.deltaTime, Space.World);


        if (transform.position.z < 0)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour {

    Main main;
	void Start () {

        main = GetComponent<Main>();
    }

    public bool left=false, right=false, up=false, down=false;

    private bool random = true;
    private float timer = 0,time,randomNum;

	void Update () {

        if (main.start)
        {


            if (random)
                time = Random.Range(1f, 3.5f);
            random = false;

            timer += Time.deltaTime;

            if (timer > time)
            {
                randomNum = Random.Range(1, 100);


                if (randomNum % 3 == 0)
                    LeftBarrier();
                else if(randomNum % 3 == 1)
                    RightBarrier();
                else if(randomNum % 3 == 2)
                    UpBarrier();
                /*else if(Random.Range(1, 50) %  == 2)
                    DownBarrier();*/

                random = true;
                timer = 0f;
            }
           
        }

	}

    private void LeftBarrier()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.name = "SideBarrier";

        cube.transform.localScale = new Vector3(30, 3, 3);
        cube.transform.position = new Vector3(-50, 1.5f, 50);

        cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();


        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.GetComponent<Rigidbody>().useGravity = false;

        cube.AddComponent<LeftBarrierMove>();
    }


    private void RightBarrier()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.name = "SideBarrier";

        cube.transform.localScale = new Vector3(30, 3, 3);
        cube.transform.position = new Vector3(50, 1.5f, main.BarrierDistance);

        cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();

        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.GetComponent<Rigidbody>().useGravity = false;

        cube.AddComponent<RightBarrierMove>();
    }

    private void DownBarrier()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.name = "SideBarrier";

        cube.transform.localScale = new Vector3(3, 30, 3);
        cube.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 50, main.BarrierDistance+10);

        cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();

        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.GetComponent<Rigidbody>().useGravity = false;

        cube.AddComponent<DownBarrierMove>();
    }

    private void UpBarrier()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.name = "SideBarrier";

        cube.transform.localScale = new Vector3(3, 30, 3);
        cube.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), -50, main.BarrierDistance+10);

        cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();

        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.GetComponent<Rigidbody>().useGravity = false;

        cube.AddComponent<UpBarrierMove>();
    }
}

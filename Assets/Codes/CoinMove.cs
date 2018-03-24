using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour {
    GameObject cube;
    Main main;

    private bool start=false;
    private Vector3 firstPosition,nowPosition;


    void Start () {
        cube = GameObject.Find("Cube");
        main = cube.GetComponent<Main>();
     

        firstPosition = transform.position;
    }

    private float firstSpeed;
	
	void Update () {

        nowPosition = transform.position;

        if (start)
        {
            firstSpeed = main.speed*Time.deltaTime;
        }  
        else
        {

            firstSpeed = main.speed * Time.deltaTime;
            ExitTheRoad();

            transform.eulerAngles = new Vector3(0,0, 0);
       
        }


        transform.Translate(0, 0, -firstSpeed, Space.World);

        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Destroy(gameObject);
            main.AddCoin(gameObject);
        }
    }

    private float y = -1;
    void ExitTheRoad()
    {

        y += 0.05f;

        if (nowPosition.y < 1f)
            transform.position = new Vector3(firstPosition.x, y, nowPosition.z);
        else
        {

            gameObject.AddComponent<BoxCollider>().size = new Vector3(1, 2, 1);
            start = true;
        }

    }
}

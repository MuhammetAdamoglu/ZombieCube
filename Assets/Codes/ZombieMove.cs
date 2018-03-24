using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    Rigidbody rb;
    Main main;
    GameObject cube;

    private Vector3 firstPosition,nowPosition,walk;
    private bool start = false;
    private float comeCloser,timer,senkronize;
    public float zombieSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cube = GameObject.Find("Cube");
        main = cube.GetComponent<Main>();

        firstPosition = transform.position;
    }


    void Update()
    {
        nowPosition = transform.position;

        if (start)
        {
         
            if (nowPosition.z - cube.transform.position.z < 8)
            {
                comeCloser = cube.transform.position.x - nowPosition.x;
            }

            LookAt(cube);
            Walk();

            zombieSpeed = (main.speed + 5) * Time.deltaTime;
        }
        else
        {
            ExitTheRoad();

            transform.eulerAngles = new Vector3(0, Mathf.Atan((cube.transform.position.x - transform.position.x) / (cube.transform.position.z - transform.position.z)) * 180 / Mathf.PI + 180, 0);

            zombieSpeed = main.speed * Time.deltaTime;
           
        }

        transform.Translate(comeCloser * main.attackSpeed * Time.deltaTime, 0, -zombieSpeed, Space.World);

        if (nowPosition.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }

    }

    private float rotation;
    void LookAt(GameObject obj)
    {
        rotation = Mathf.Atan((obj.transform.position.x - nowPosition.x) / (obj.transform.position.z - nowPosition.z)) * 180 / Mathf.PI + 180;

        if (obj.transform.position.z > nowPosition.z)
            rotation = 0;
            
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
    }

    void Walk()
    {
        timer += Time.deltaTime;
        if (timer > 0.3)
        {
            senkronize++;

            if (senkronize % 2 == 0)
                walk = new Vector3(0, 0, 4);
            else
                walk = new Vector3(0, 0, -4);

            rb.angularVelocity = walk;

            timer = 0f;
        }
    }


    private float y=-1;
    void ExitTheRoad()
    {

        y += 0.05f;
       
        if (transform.position.y < 1f)
            transform.position = new Vector3(firstPosition.x, y, nowPosition.z);
        else
        {
            
            gameObject.AddComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            start = true;
        }
           
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCube : MonoBehaviour {

    Main main;
    private float timer = 0;
    GameObject cubeEye;


    void Start()
    {
        main = GetComponent<Main>();
        cubeEye = GameObject.Find("CubeEyes");
    }

    private bool firstStage = true, secondStage=false, thirdStage=false, lastStage=false;

    void Update()
    {

        if(!main.start && !main.stop)
        {

            if (firstStage)
                FirstStage();
            else if (secondStage)
                SecondStage();
            else if (thirdStage)
                ThirdStage();
            else
                LastStage();

        }
    }

    private void FirstStage()
    {
        if (transform.position.z < -10)
        {
            firstStage = false;
            secondStage = true;

            transform.position = new Vector3(0,-2,-11);

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            transform.rotation = Quaternion.Euler(0, 10, 0);
        }
        else
            transform.Translate(0,0, -(main.speed+5)*Time.deltaTime,Space.World);
    }

    private void SecondStage()
    {

        secondStage = false;
        thirdStage = true;
    }

    private void ThirdStage()
    {

        if (transform.position.y > 6)
        {
            thirdStage = false;
            lastStage = true;
            
        }
        else
        {

            cubeEye.transform.rotation = Quaternion.Euler(0,180,0);

            timer += Time.deltaTime;
            if (timer > 1)
            {
                transform.position = new Vector3(0,(timer*main.speed/4)-2,10);

            }
        }
       
    }

    private void LastStage()
    {
        firstStage = true;
        secondStage = false;
        thirdStage = false;
        lastStage = false;

        timer = 0;

        main.stop = true;
    }
}

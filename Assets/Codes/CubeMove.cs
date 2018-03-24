using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {

    private new Rigidbody rigidbody;
    private GameObject cubeEyes;

    private Main main;

    private bool start = false;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        firstposition = transform.position;

        main = GetComponent<Main>();

        cubeEyes = GameObject.Find("CubeEyes");

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private float rotation;


    private Vector3 firstposition;
    private Vector3 nowposition;

    private Vector2 screenPosition;


    void Update () {
       

        if (!main.start)
        {
           
            if (main.stop)
            {
                transform.position = firstposition;
            }
            transform.Rotate(main.speed, 0, 0);
        }
        else
        {
            nowposition = transform.position;


            if(start)
                transform.position = new Vector3(nowposition.x, main.positionY, nowposition.z);

            isDead();

            screenPosition = Camera.main.WorldToScreenPoint(nowposition);
            Rotation();

            transform.Translate(rotation * Time.deltaTime/8, 0, 0, Space.World);
            transform.Rotate(main.speed, 0 , 0, Space.World);
           
           

        }
        


        CubeEyesMove();
    }

    private void CubeEyesMove()
    {
        cubeEyes.transform.position =new Vector3(transform.position.x,transform.position.y+main.scale.y/2,transform.position.z);
    }

    private void Rotation()
    {
        rotation = 0;
        if (Input.GetMouseButton(0))
        {      
            rotation = Input.mousePosition.x - screenPosition.x;

            if (rotation > 100)
                rotation = 100;
            else if (rotation < -100)
                rotation = - 100;
        }
    }


    private void isDead()
    {

        if (screenPosition.y < main.deadB || nowposition.x< main.deadL || nowposition.x > main.deadR)
        {
            main.start = false;
            start = false;
        }
    }

    private float crashPosition;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name== "Zombie")
        {
            crashPosition = nowposition.x - collision.transform.position.x;

            if (crashPosition > main.scale.x * (100 - main.crashPositionR) / 100)
            {
                transform.Rotate(0, main.speed * crashPosition/2, 0, Space.World);
            }
            else if(crashPosition < -main.scale.x * (100 - main.crashPositionL) / 100)
            {
                transform.Rotate(0, main.speed * crashPosition/2, 0, Space.World);
            }
            else
            {
                main.start = false;
                start = false;
            }
          
        }

        if (collision.gameObject.name == "Terrain" && main.start)
            start = true;


        if(collision.gameObject.name== "SideBarrier")
        {

            crashPosition = nowposition.x - collision.transform.position.x;

            if(crashPosition> collision.transform.localScale.x/2+ main.scale.x/2-0.5f)
            {
                transform.Rotate(0, main.speed * crashPosition / 2, 0, Space.World);
            }
            else if (crashPosition < -collision.transform.localScale.x/2 - main.scale.x/2 + 0.5f)
            {   
                transform.Rotate(0, main.speed * crashPosition / 2, 0, Space.World);
            }
            else
            {
                main.start = false;
                start = false;
            }

        }
    }

}

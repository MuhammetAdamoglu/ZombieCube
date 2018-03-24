using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    private GameObject terrain,zombie;

    public float speed, zombieSpeed, ZombieRainSpeedTime, CoinRainSpeedTime, attackSpeed;
    public float deadL, deadR, deadB;
    public float rebirthTime;
    public float crashPositionL, crashPositionR;

    public float zombieStartY;
    public float zombieStartZ;
    public float zombieStartX;

    public float positionY;

    public Vector3 scale;


    public bool stop,start,zombieStop;

    public float cameraPositionZ, PositionZ;

    public int coins;

    public float BarrierDistance;
    
    void Start () {

     

        stop = true;
        start = false;
        zombieStop = false;

        terrain = GameObject.Find("Terrain");
        zombie = GameObject.Find("Zombie1");

        coins = PlayerPrefs.GetInt("Coins");

        speed = 25;

        zombieSpeed = 18;
        attackSpeed = 2;

        ZombieRainSpeedTime = 0.3f;//sn
        CoinRainSpeedTime = 3f;//sn

        rebirthTime = 2;//sn

        deadL = terrain.transform.position.x - terrain.transform.localScale.x/2 - transform.localScale.x/2;
        deadR = terrain.transform.position.x + terrain.transform.localScale.x/2 + transform.localScale.x/2;
        deadB = 0;

        crashPositionL = 50;//%
        crashPositionR = 50;//%

        cameraPositionZ = Camera.main.transform.position.z;
        PositionZ = transform.position.z;

        zombieStartY = -2;
        zombieStartZ = 80;

        

        scale = transform.localScale;

        positionY = terrain.transform.localScale.y + scale.y / 2;

        BarrierDistance = 60;
    }


    private float timer = 0;
    private int id = 0;

    void Update () {
        StartGame();
    }


    public void AddCoin(GameObject obj)
    {
        if (obj.gameObject.name == "Coin")
        {
            PlayerPrefs.SetInt("Coins", ++coins);
        }
           
    }

    public void StartGame()
    {

        if (start)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {  
            GetComponent<Rigidbody>().useGravity = false;
        }

        if(stop)
            GameObject.Find("Menu").GetComponent<Canvas>().enabled = true;

    }
 
    public void Zombie_Cube(GameObject obj)
    {
        obj.name = "Zombie";

        zombieStartX = (terrain.transform.localScale.x / 2f) - (obj.transform.localScale.x / 2f);

        obj.transform.position = new Vector3(Random.Range(-zombieStartX, zombieStartX), zombieStartY, zombieStartZ);
        obj.transform.rotation = Quaternion.Euler(0, 180, 0);

        obj.AddComponent<ZombieMove>();
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();
    }

    public void Coins(GameObject obj)
    {
        obj.name = "Coin";

        zombieStartX = (terrain.transform.localScale.x / 2f) - (obj.transform.localScale.x / 2f);

        obj.transform.position = new Vector3(Random.Range(-zombieStartX, zombieStartX), zombieStartY, zombieStartZ);
        obj.transform.rotation = Quaternion.Euler(0, 180, 0);

        obj.AddComponent<CoinMove>();
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMove : MonoBehaviour {

    GameObject cube, zombie, coin;
    Main main;

    void Start() { 
        cube = GameObject.Find("Cube");
        main = cube.GetComponent<Main>();
    }

    

    float timerZombie = 0f, timerCoin = 0f;
    int random;
    void Update () {

        if (main.zombieStop)
            return;

        timerZombie += Time.deltaTime;
        timerCoin += Time.deltaTime;

        if (timerZombie > main.ZombieRainSpeedTime)
        {
            if (!main.start)
                return;


            random = Random.Range(1, 9);

            zombie = GameObject.Find("Zombie" + random);


            main.Zombie_Cube((GameObject)Instantiate(zombie));

            timerZombie = 0f;
        }

        if (timerCoin > main.CoinRainSpeedTime)
        {
            if (main.stop)
                return;

            coin = GameObject.Find("Coin");
            main.Coins((GameObject)Instantiate(coin));

            timerCoin = 0f;
        }

       

    }

}


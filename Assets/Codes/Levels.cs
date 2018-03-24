using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    Main main;

	void Start () {
        main = GetComponent<Main>();
	}

    private int coins;
	
	void Update () {

        coins = main.coins;

        if (coins < 3)
        {
            main.attackSpeed = 0.5f;

            main.ZombieRainSpeedTime=0.6f;
            main.CoinRainSpeedTime = 1;

        }
        else if (coins < 6)
        {
            main.attackSpeed = 0.7f;

            main.ZombieRainSpeedTime = 0.6f;
            main.CoinRainSpeedTime = 0.9f;

        }
        else if (coins < 12)
        {
            main.attackSpeed = 0.8f;

            main.ZombieRainSpeedTime = 0.6f;
            main.CoinRainSpeedTime = 0.9f;

        }
        else if (coins < 24)
        {
            main.attackSpeed = 1f;

            main.ZombieRainSpeedTime = 0.4f;
            main.CoinRainSpeedTime = 0.8f;

        }
        else if (coins < 48)
        {
            main.attackSpeed = 1.2f;

            main.ZombieRainSpeedTime = 0.4f;
            main.CoinRainSpeedTime = 0.8f;

        }
        else if (coins < 96)
        {
            main.attackSpeed = 1.3f;

            main.ZombieRainSpeedTime = 0.4f;
            main.CoinRainSpeedTime = 0.7f;
           
        }
        else if (coins < 192)
        {
            main.attackSpeed = 1.5f;

            main.ZombieRainSpeedTime = 0.3f;
            main.CoinRainSpeedTime = 0.6f;

        }
        else if (coins < 384)
        {
            main.attackSpeed = 1.6f;

            main.ZombieRainSpeedTime = 0.3f;
            main.CoinRainSpeedTime = 0.5f;

        }
        else if (coins < 768)
        {
            main.attackSpeed = 1.7f;

            main.ZombieRainSpeedTime = 0.3f;
            main.CoinRainSpeedTime = 0.4f;

        }
        else if (coins < 1500)
        {
            main.attackSpeed = 2f;

            main.ZombieRainSpeedTime = 0.2f;
            main.CoinRainSpeedTime = 0.3f;

        }
    }
}

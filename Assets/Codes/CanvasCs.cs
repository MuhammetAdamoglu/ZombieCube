using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCs : MonoBehaviour {

    Button play;
    Text score;

    Main main;

	void Start () {

        main = GameObject.Find("Cube").GetComponent<Main>();

        GameObject canvasObject = GameObject.Find("Menu");
        Transform buttonTr = canvasObject.transform.Find("ButtonPlay");
        play = buttonTr.GetComponent<Button>();

        GameObject canvasObjectScore = GameObject.Find("Score");
        Transform textTr = canvasObjectScore.transform.Find("Tv_Score");
        score = textTr.GetComponent<Text>();

        play.onClick.AddListener(() => Play());

        
    }
	
    private void Play()
    {
        GameObject.Find("Cube").GetComponent<Main>().start = true;
        GameObject.Find("Cube").GetComponent<Main>().stop = false;
        GameObject.Find("Cube").GetComponent<Main>().coins = PlayerPrefs.GetInt("Coins");

        GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
    }

	void Update () {

        score.text = "Score " + main.coins;
    }
}

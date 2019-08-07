using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /*
        Giocatore e fine partita
    */
    public GameObject player;
    public GameObject endTrigger;
    private Vector3 initialPosition;

    /*
        Stato della partita
    */
    public bool hasStarted, hasLost, hasWon = false;
    private int points;
    private GameObject[] coins;

    /* 
        Testi a schermo
    */
    public GameObject uiWinText, uiLostText, uiStartText;
    public Text uiPointsText;

    void Start()
    {
        uiPointsText.text = "";
        initialPosition = player.transform.position;
        coins = GameObject.FindGameObjectsWithTag("Points");
        resetGame();
    }

    void Update()
    {
        if (!hasStarted) {
            checkPlayerReady();
        }

        checkResetInput();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void victorySequence () 
    {
        player.SetActive(false);
        uiWinText.SetActive(true);
    }

    void defeatSequence()
    {
        player.SetActive(false);
        uiLostText.SetActive(true);
    }

    void checkPlayerReady()
    {
        bool pressEnter = Input.GetKeyDown(KeyCode.Return);
        if (pressEnter && !hasStarted)
        {
            hasStarted = true;
            player.SetActive(true);
            uiStartText.SetActive(false);
        }
    }

    void checkResetInput() {
        bool pressR = Input.GetKeyDown(KeyCode.R);
        if (pressR) {
            resetGame();
        }
    }

    void resetGame () {
        player.transform.position = initialPosition;
        hasStarted = false;
        player.SetActive(false);
        uiWinText.SetActive(false);
        uiLostText.SetActive(false);
        uiStartText.SetActive(true);

        points = 0;
        updatePoints();

        resetCoins();
    }

    void resetCoins () {
        foreach (GameObject coin in coins) {
            coin.SetActive(true);
        }
    }

    void updatePoints () {
        if (points == 0) {
            uiPointsText.text = "";
        } else {
            uiPointsText.text = "Punti: " + points;
        }
    }

    void addToPoints(int morePoints) {
        points = points + morePoints;
        updatePoints();
    }
}

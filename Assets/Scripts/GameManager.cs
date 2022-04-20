using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gamePlayUI;
    public GameObject spawner;
    public GameObject backgroundParticle;


    // tehd‰‰n scriptist‰ staattinen jotta siihen voi kurkottaa muualta
    public static GameManager gameManager;
    public bool gameStarted = false;

    Vector3 originalCamPos;


    public GameObject player;

    int lives = 2;
    int score = 0;

    public Text scoreText;
    public Text livesText;


    void Awake()
    {
        gameManager = this;
    }


    void Start()
    {
        //kameran alkuper‰inen paikka
        originalCamPos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        spawner.SetActive(true);
        backgroundParticle.SetActive(true);
    }

    public void GameOver()
    {
        // pelaaja pois n‰kyvist‰
        player.SetActive(false);

        // odotetaan 1.5 sekuntia ja ladataan taso uudestaan
        Invoke("ReloadLevel", 1.5f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            livesText.text = "Lives : " + lives;
            //print("lives :" + lives);
        }

    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score;
        //print("Score : " + score); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }


    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            //satunnainen paikka johon kamera siirret‰‰n
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCamPos.z);

            //odotetaan kehyksen loppuun asti 
            yield return null;

        }

        Camera.main.transform.position = originalCamPos;
    }



}

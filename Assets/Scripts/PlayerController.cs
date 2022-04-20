using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public GameObject particle;

    float playerYPos;

    void Start()
    {
        //  playerYPos saa arvokseen Pelaajan sijainnin Y -akselilla
        playerYPos = transform.position.y;
    }

    
    void Update()
    {
        if (GameManager.gameManager.gameStarted)
        {

            if (!particle.activeInHierarchy)
            {
                particle.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                // player vaihtaa paikkaa
                PositionSwitch();
            }
        }            
    }

    void PositionSwitch()
    {
        playerYPos = -playerYPos;
        // x ja z arvot pysyvät samoina, y vaihtuu
        transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //restart level 
            //SceneManager.LoadScene("Game");
            //GameManager.gameManager.GameOver()
            GameManager.gameManager.UpdateLives();

            GameManager.gameManager.Shake();

        }
    }



}

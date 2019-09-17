using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallControl : MonoBehaviour
{
    Rigidbody2D physic;
    public Text countText;
    public Text scoreText;
    public Text gameOverText;

    bool isGameOver = false;
    
    int batScore=0;
    int bat1Score=0;
    float returnMenuTime;
    float replayTimer;
    
    void Start()
    {
        physic = this.GetComponent<Rigidbody2D>();
        physic.velocity = new Vector2(3, 3);
        countText.enabled = false;
        gameOverText.enabled = false;
        
    }

    
    void FixedUpdate()
    {
        if (isGameOver==false)
        {
            scoreControl();
        }
        
        GameOverControl();
        if (isGameOver == true)
        {
            returnMenuTime += Time.deltaTime;
            if (returnMenuTime >= 2.5)
            {
                SceneManager.LoadScene(0);
            }
            
            
        }
    }
    void scoreControl()
    {
        if (transform.position.x >= 9)
        {

            replayTimer += Time.deltaTime;
            countText.enabled = true;
            if (replayTimer >= 1)
            {
                batScore++;
                scoreText.text = batScore + " - " + bat1Score;
                countText.enabled = false;
                transform.position = new Vector3(-2.23f, 0.78f);
                
                replayTimer = 0;
            }


        }
        if (transform.position.x <= -13)
        {

            replayTimer += Time.deltaTime;
            countText.enabled = true;
            if (replayTimer >= 1)
            {
                bat1Score++;
                scoreText.text = batScore + " - " + bat1Score;
                countText.enabled = false;
                physic.velocity = new Vector2(-3, -3);
                transform.position = new Vector3(-2.23f, 0.78f);
                replayTimer = 0;
            }
        }
    }


    void GameOverControl()
    {
        if (batScore >= 5)
        {
            isGameOver = true;
            gameOverText.enabled = true;
            gameOverText.text = "Winner is Player 1!";
        }
        if (bat1Score >= 5)
        {
            isGameOver = true;
            gameOverText.enabled = true;
            gameOverText.text = "Winner is Player 2!";
        }
    }

}

    

    


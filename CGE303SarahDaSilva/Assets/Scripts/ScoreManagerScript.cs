using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour
{
    //notice public static variables can be accessed from any script
    //but cannot be seen in the Inspector
    public static bool gameOver;
    public static bool won;
    public static int score;

    //Set this in the Inspector
    public TMP_Text textbox;
    public int scoreToWin;

    //Set initial values for variables in Start()

    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score:" + score;
        }
        if (score >= scoreToWin)
        {
            won = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win!\nPress R to Try Again";
            }
            else
            {
                textbox.text = "You lose!\nPress R to Try Again";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    //Create a variable to keep track of whether the trigger zone is active
    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            //Deactivate the trigger zone
            active = false;

            //Add 1 to the score when the player enters the trigger zone
            ScoreManagerScript.score++;
            gameObject.SetActive(false);

        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

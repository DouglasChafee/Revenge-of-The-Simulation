using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public LevelCompleteScreen LevelCompleteScreen;
    public string ItemText = "You recieved the TripleShot Powerup!";  // \n Press Right Click to Shoot Three Times
    public bool entered = false;
    public CharBoolDoor getPlayer;

    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
            if (entered == false)
            {
                if(PlayerCombat.killedBoss == true)
                {
                    Screen();
                }
                
            }
		}
	}

    void Screen()
    {
        LevelCompleteScreen.Setup(ItemText);
        //int index = Random.Range(0, 3);
        entered = true;
    }
}

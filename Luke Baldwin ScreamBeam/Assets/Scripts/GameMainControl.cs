using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainControl : MonoBehaviour
{

    //Calculates current number of Asteroids
    public int numberOfDifferentAsteroids;
    public int levelnumber = 1;
    public GameObject asteroid;

    public void UpdateNumberOfAsteroidsinScene(int change)
    {
        numberOfDifferentAsteroids += change;

        //Checks to see if there are any asteroids in scene
        if (numberOfDifferentAsteroids <= 0)
        {
            Invoke("StartNewLevel", 3f);
        }
    }
    void StartNewLevel()
    {

        levelnumber++;

        //Moves onto next level and spawns new asteroids
        for (int i = 0; i < levelnumber * 2; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(23f, -23f), 13f);
            Instantiate(asteroid, spawnPosition, Quaternion.identity);
            numberOfDifferentAsteroids++;

        }
    }

        public bool CheckForHighestScore (int score)
        {

            int currentHighScore = PlayerPrefs.GetInt("highscoregotten");
            if (score > currentHighScore) {
                return true;
            }
            return false;
    }
}
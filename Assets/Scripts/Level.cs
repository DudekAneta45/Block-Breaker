using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    //parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes
    [SerializeField] int numberOfBalls;

    //cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void CountBalls()
    {
        numberOfBalls++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <=0)
        {
            sceneloader.LoadNextScene();
        }
    }

    public void BallDestroyed()
    {
        numberOfBalls--;
        if(numberOfBalls == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}

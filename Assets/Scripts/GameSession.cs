using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] public int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update ()
    {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

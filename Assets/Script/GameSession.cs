using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int spiritScore = 0;
    [SerializeField] Text scoreText;

    [SerializeField] int playerMaxHearts = 5;
    [SerializeField] int playerLives = 3;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = spiritScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives > playerMaxHearts) {
            playerLives = playerMaxHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerMaxHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }

            if (i < playerLives) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void IncreaseScore (int pointsToAdd) {
        spiritScore += pointsToAdd;
        scoreText.text = spiritScore.ToString();
    }

    public void ProcessPlayerDeath() {
        if(playerLives > 1) {
            RemoveLives();
        } else {
            ResetGame();
        }
    }

    public void RemoveLives() {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ResetGame() {
        SceneManager.LoadScene(1); // `1` index is here for Main Menu
        Destroy(gameObject);
    }
    
}

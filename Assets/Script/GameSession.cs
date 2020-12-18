using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int spiritScore = 0;
    [SerializeField] Text scoreText;

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

    }

    public void IncreaseScore (int pointsToAdd) {
        spiritScore += pointsToAdd;
        scoreText.text = spiritScore.ToString();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] int spiritValue = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<GameSession>().IncreaseScore(spiritValue);
        Destroy (gameObject);    
    }
}

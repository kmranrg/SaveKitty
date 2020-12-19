using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GateLevel3 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        SceneManager.LoadScene(1); // `1` index is here for Main Menu
        Destroy(gameObject);
    }
}

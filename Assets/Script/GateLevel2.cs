using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GateLevel2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentSceneIndex + 1 );
    }
}

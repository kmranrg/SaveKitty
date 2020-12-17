using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentSceneIndex + 1 );
    }

    public void FadeAnimation() {
        animator.SetTrigger("Fade");
    }

    public void ExitGame() {
        Application.Quit();
    }
}

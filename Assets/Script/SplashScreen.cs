using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public void PlayLogoSound() {
        FindObjectOfType<AudioManager>().Play("LogoSound");
    }
}

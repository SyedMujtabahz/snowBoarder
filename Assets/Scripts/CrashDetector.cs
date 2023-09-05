using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float ReloadDelay = 1f;

    [SerializeField]
    ParticleSystem CrashEffect;

    [SerializeField]
    AudioClip crashsffx;

    bool hasCrashed;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {   
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableCOntrols();
            CrashEffect.Play();
            //GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().PlayOneShot(crashsffx);
            Invoke("ReloadScene", ReloadDelay);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}

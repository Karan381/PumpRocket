using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionHandler : MonoBehaviour
{
    [SerializeField]float loadDelay = .8f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successP;
    [SerializeField] ParticleSystem crashP;

    Mover movingSystem;
    AudioSource audioSource;

    bool isTransition = false;

    private void Start()
    {
        movingSystem = GetComponent<Mover>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransition) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        successP.Play();
        audioSource.Stop();  
        audioSource.PlayOneShot(success);
        movingSystem.enabled = false;
        Invoke("NextLevel", loadDelay);
        isTransition = true;    
    }

    void StartCrashSequence()
    {
        crashP.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        movingSystem.enabled = false;
        Invoke("ReloadScene", loadDelay);
        isTransition = true; 
    }

    
    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}


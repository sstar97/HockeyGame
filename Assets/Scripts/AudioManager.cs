using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip PuckCollision;
    public AudioClip Goal;
    public AudioClip music;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            audioSource.PlayOneShot(music);
        }
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }
}

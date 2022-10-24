using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] private AudioClip takeDamageClip;
    [SerializeField] [Range(0f, 1f)] float takeDamageVolume = 1f;

    void Awake()
    {
        ManageSingleton();
    }

    //Responsible for keeping just one AudioPlayer for the game,
    //that persists across all the screens
    private void ManageSingleton()
    {
        //Gets all then instances of this script (class)
        int instanceCount = FindObjectsOfType(GetType()).Length;
        //If the second instance of this script appears,
        //destroys it
        if (instanceCount > 1)
        {
            //Disable it to prevent other areas of the game to access
            //it the moment we are about to destroy it
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //If this is the first instance of this script then mark
        //it to not be destroyed when switching scenes
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //Plays the shooting sound effect
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    //Plays the sound effect that a ship received damage
    public void PlayTakeDamageClip()
    {
        PlayClip(takeDamageClip, takeDamageVolume);
    }

    private void PlayClip(AudioClip soundClip, float soundVolume)
    {
        if (soundClip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;

            //Plays a sound at the position of the audio listener (Camera) with
            //the specified audio volume
            AudioSource.PlayClipAtPoint(soundClip, cameraPosition, soundVolume);
        }
    }
}

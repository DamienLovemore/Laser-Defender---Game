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

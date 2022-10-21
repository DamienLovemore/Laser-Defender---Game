using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health  = 50;
    [SerializeField] private ParticleSystem hitEffect;

    //To apply the camera shake to just the player
    [SerializeField] private bool applyCameraShake;
    private CameraShake cameraShakeHandler;

    private AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShakeHandler = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    //When an entity triggers (makes contact) with another, we do the collision damage
    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        //If the entity that it collided have a Damage Dealer component (enemy),
        //destroy the other entity and make this actual entity take damage
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayTakeDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    //Responsible for making the player takes damage, and dies when its
    //health reaches zero
    private void TakeDamage(int damageAmount)
    {
        int newHealth;

        //Calculates the new health after taking the damage.
        //(Also makes sure that the health does not go negative)
        newHealth = Mathf.Clamp(health - damageAmount, 0, int.MaxValue);

        //Updates health value
        health = newHealth;
        //If it runs out of health, then it should die
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    //When the entity dies, it plays the explosion animation
    private void PlayHitEffect()
    {
        //Verifies if the explosion entity is added in this entity
        if(hitEffect != null)
        {
            //Creates the explosion effect
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroys the explosion object after the time that
            //it should already plays its effect
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera()
    {
        //If the script that handles the camera shaking is added to the camera
        //and this entity is the player and not the enemy
        if ((cameraShakeHandler != null) && (applyCameraShake))
        {
            cameraShakeHandler.Play();
        }
    }
}

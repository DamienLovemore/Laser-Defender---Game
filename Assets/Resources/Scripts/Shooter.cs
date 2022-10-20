using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] private bool useAI;
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.1f;

    private bool isFiring;
    private Coroutine firingCoroutine;

    void Start()
    {
        //if it is a enemy it should always be firing
        if(useAI)
        {
            isFiring = true;
        }
    }
    
    void Update()
    {
        Fire();
    }

    //Method responsible for setting the value indicating if the user
    //is firing or not, from other scripts
    public void SetIsFiring(bool isFiring)
    {
        this.isFiring = isFiring;
    }

    //Shoots projectiles while the space key is being pressed (held down)
    private void Fire()
    {
        //If the player is helding down the fire button
        if ((isFiring) && (firingCoroutine == null))
        {
             firingCoroutine = StartCoroutine(FireContinuously());
        }
        //If the player has stopped holding the fire button
        else if((!isFiring) && (firingCoroutine != null))
        {
            StopCoroutine(firingCoroutine);
            //Says to the script that it can create a new coroutine
            //to fire continuously (it should have just one)
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            //Creates a new bullet and store its reference
            GameObject newBullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //Makes the bullet goes up at the specified speed
            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            if (bulletRB != null)
            {
                bulletRB.velocity = transform.up * projectileSpeed;
            }

            //Destroys it after its lifetime has expired (so it won't keep going forward forever)
            Destroy(newBullet, projectileLifetime);

            float timeNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeNextProjectile = Mathf.Clamp(timeNextProjectile, minimumFiringRate, float.MaxValue);

            //Waits for a amount of time before being able to fire again
            yield return new WaitForSeconds(timeNextProjectile);
        }
    }
}

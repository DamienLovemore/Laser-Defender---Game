using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health  = 50;

    //When an entity triggers (makes contact) with another, we do the collision damage
    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        //If the entity that it collided have a Damage Dealer component (enemy),
        //destroy the other entity and make this actual entity take damage
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

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
}

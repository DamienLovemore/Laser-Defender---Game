using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    //Method responsible for returning how much damage 
    //this entity can do
    public int GetDamage()
    {
        int returnValue;

        returnValue = damage;

        return returnValue;
    }

    //Tells the game object that it is attached that that
    //something hitted it, and it must be destroyed
    public void Hit()
    {
        Destroy(gameObject);
    }
}

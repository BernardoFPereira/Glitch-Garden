using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
    public float hitPoints = 50f;

    public void DealDamage (float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            //Optinally trigger death animation
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

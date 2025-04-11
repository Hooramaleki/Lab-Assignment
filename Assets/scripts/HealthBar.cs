using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //declaring the health as public so i can change or see it
    public int health = 5 ;

    public AudioSource explosion;
    public SpriteRenderer sr;
    public Collider2D col;




    public void Damage(int damage)
    {
        //reducing health by taking damage
        health -= damage ;

        if (health <= 0)
        {
            kill();
        }
    }
    public void kill()
    {
        //we pllay the explosion sound effect
        //we disable visuals and collider so its hidden and bullets no longer collide with this enemy
        //we destroy the game object after 5 sec so the explosion sound is finished playing. 
        // because if we dont delay, the audio wont be heard and will be destroyed too.

        explosion.Play();
        sr.enabled = false;
        col.enabled = false;

        Destroy(gameObject, 5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageOnCollision : MonoBehaviour
{
    public int damagePoint = 1;

    public AudioSource explosion;
    public SpriteRenderer sr;
    public Collider2D col;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        HealthBar killable = other.GetComponent<HealthBar>() ;

        if(killable != null)
        {
            killable.Damage(damagePoint);

            explosion.Play();
            sr.enabled = false;
            col.enabled = false;

            Destroy(gameObject, 5);
        }
    }
}

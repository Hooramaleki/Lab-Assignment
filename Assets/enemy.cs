using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject bullet;
    public float timebetweenShots = 3f;

    public SpriteRenderer sr;
    public AudioSource shootingSound;

    float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining += Time.deltaTime;
        //If enough time has passed and visuals is enabled.
        //visual enabled means it is not destroyed. we check by checking if sr is enabled or not.
        if (timeRemaining > timebetweenShots && sr.enabled)
        {
            var newBullet = Instantiate(bullet, transform.position + new Vector3(0.6f,0,0), transform.rotation);
            newBullet.transform.position = transform.position;
            shootingSound.Play();

            timeRemaining = 0;
        }
        
    }
}

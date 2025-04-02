using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public float speedDecrease;

    public float minSpeed;

  


    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;

        speed -= speedDecrease * Time.deltaTime;
        if (speed < minSpeed )
            speed = minSpeed;

        if (Mathf.Abs(transform.position.x) > 15)
        {
            Destroy(gameObject);
        }
    }
}

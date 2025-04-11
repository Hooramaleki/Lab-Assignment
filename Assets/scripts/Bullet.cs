using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;


    


    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;



        if (Mathf.Abs(transform.position.x) > 15)
        {
            Destroy(gameObject);
        }
    }
}

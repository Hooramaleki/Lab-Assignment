using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    //we define a speed just to place it in an upcoming vector in our code in order to make it easier to understand
    public float speed = 2f;


    public Vector3 inputVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //we defined an x & y to move the spaceship in diffrent directions.
        //both horizontal and vertical directions are defined here.
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        //we assign this so we can see it in the game and read the values
        inputVector = new Vector3(inputX, inputY, 0);

        //to know how many seconds the last frame took? for example it takes 0.066... for 60fps
        float dt = Time.deltaTime;

        //if W and D is held at the same time the inputvector will be (1,1,0) for a velocity of (speed,speed,0)

        transform.position = transform.position + inputVector *speed *dt;
    }

}

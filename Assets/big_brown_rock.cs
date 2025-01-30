using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_brown_rock : MonoBehaviour
{

    //we define a speed just to place it in an upcoming vector in our code in order to make it easier to understand
    public float speed =-1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //to know how many seconds the last frame took? for example it takes 0.066... for 60fps
        float dt = Time.deltaTime;


        //vector is a previously defined class that makes adding positions possible
        //defining the movement of the rock to the left in a straight line by adding a vector of (speed ,0,0) 
        //the "speed" inside of vector3' parantasis is refering to the variable of speed that we defined earlier
        //just to make it look neat and simple and clear
        //adding deltaTime to make sure it runs the same on every system
        //move x units multiply by dt seconds
        //(delta time: multiplying the speed by the numbers of a seconds in a frame)
        transform.position = transform.position + new Vector3(speed ,0,0) * Time.deltaTime ;
    }
}

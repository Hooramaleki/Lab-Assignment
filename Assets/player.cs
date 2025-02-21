using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    //the bullet prefab to spawn. variables which are used for shooting
    public GameObject playershootPrefab;
    private float timeUntilReloaded = 0;
    public float fireRate = 3;
    public float rapidFireRate = 6;
    public float spreadAngle = 30;
    public float doubleDistance = 0.3f;


    //player speed
    public float speed = 2f;


    //offset to spawn bullets
    public Vector3 shootOffset;


    //shooting mode
    public SelectMode ShootMode = SelectMode.Default;


    //defining diffrent types of shooting
    public enum SelectMode
    {
        Default = 0,
        Rapid = 2,
        Spread = 1,
        Double = 3,

    }

    public Vector3 inputVector = Vector3.zero;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking if player collected a powerup
        if (collision.CompareTag("PowerUp"))
        {
            //changing the shooting mode and collecting the power up.
            PowerUp powerUp = collision.GetComponent<PowerUp>();
            ShootMode = powerUp.powerUpMode;
            powerUp.Collected();

        }
    }


    // Update is called once per frame
    void Update()
    {
        //Switching between different shooting modes when pressing E.
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (ShootMode)
            {
                case SelectMode.Default:
                    ShootMode = SelectMode.Double;
                    break;

                case SelectMode.Double:
                    ShootMode = SelectMode.Rapid;
                    break;

                case SelectMode.Rapid:
                    ShootMode = SelectMode.Spread;
                    break;

                case SelectMode.Spread:
                    ShootMode = SelectMode.Default;
                    break;

                default:
                    break;


            }
        }


        //as long as space is held and is not reloading, the player shoots
        if (Input.GetKey(KeyCode.Space) && timeUntilReloaded <= 0)
        {

            //Using correct shooting mode
            switch (ShootMode)
            {
                case SelectMode.Default:
                    DefaultShootingBehaviour();
                    break;

                case SelectMode.Double:
                    DoubleShootingBehaviour();
                    break;

                case SelectMode.Rapid:
                    RapidShootingBehaviour();
                    break;

                case SelectMode.Spread:
                    SpreadShootingBehaviour();
                    break;

                default:
                    break;
            }

        }


        //calculating time remaining until gun is reloaded
        if (timeUntilReloaded > 0) 
        {
            timeUntilReloaded -= Time.deltaTime;
        }


        //we defined an x & y to move the spaceship in diffrent directions.
        //both horizontal and vertical directions are defined here.
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        //we assign this so we can see it in the game and read the values
        inputVector = new Vector3(inputX, inputY, 0);

        //we ue debug.log to show the output of vector in consule
        Debug.Log(inputVector.magnitude);

        //to know how many seconds the last frame took? for example it takes 0.066... for 60fps
        float dt = Time.deltaTime;

        //if W and D is held at the same time the inputvector will be (1,1,0) for a velocity of (speed,speed,0)
        transform.position = transform.position + inputVector * speed * dt;

    }



    void DefaultShootingBehaviour()
    {
        ///Spawn 1 bullet at the offset position
        Instantiate(playershootPrefab, transform.position + shootOffset, transform.rotation);
        timeUntilReloaded = 1 / fireRate; // Calculates how many seconds between shots
    }

    void SpreadShootingBehaviour()
    {

        // Converts rotation from quaternion to 3 angles in degerees around x,y and z
        Vector3 eulerRotation = transform.rotation.eulerAngles;


        //calculating rotation of bullets
        Instantiate(playershootPrefab, transform.position + shootOffset,
            Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z + spreadAngle));

        Instantiate(playershootPrefab, transform.position + shootOffset,
            Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z));

        Instantiate(playershootPrefab, transform.position + shootOffset,
            Quaternion.Euler(eulerRotation.x, eulerRotation.y, eulerRotation.z - spreadAngle));

        timeUntilReloaded = 1 / fireRate; // Calculates how many seconds between shots


    }

    void RapidShootingBehaviour()
    {
        //Spawn 1 bullet with faster fire rate
        Instantiate(playershootPrefab, transform.position + shootOffset, transform.rotation);
        timeUntilReloaded = 1 / rapidFireRate; // Calculates how many seconds between shots
    }

    void DoubleShootingBehaviour()
    {
        //Spawn 2 bullets, one above and one below
        Instantiate(playershootPrefab, transform.position + shootOffset + Vector3.up * doubleDistance, transform.rotation);
        Instantiate(playershootPrefab, transform.position + shootOffset - Vector3.up * doubleDistance, transform.rotation);
        timeUntilReloaded = 1 / (fireRate * 2); // Calculates how many seconds between shots

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // the power up mode
    public player.SelectMode powerUpMode;

    //remove the power up when collected
    public void Collected()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipper : MonoBehaviour
{
    public void FlipCharacter(bool isMovingRight)
    {
        if (isMovingRight)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

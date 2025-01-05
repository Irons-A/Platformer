using UnityEngine;

public class EnemyFlipper : MonoBehaviour
{
    private Quaternion _defaultRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion _flippedRotation = Quaternion.Euler(0, 180, 0);

    public void FlipCharacter(bool isMovingRight)
    {
        if (isMovingRight)
        {
            transform.rotation = _defaultRotation;
        }
        else
        {
            transform.rotation = _flippedRotation;
        }
    }
}

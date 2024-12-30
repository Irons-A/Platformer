using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariablesHandler : MonoBehaviour
{
    private int _score = 0;

    public void AddScore(int score)
    {
        _score += score;
    }
}

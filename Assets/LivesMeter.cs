using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesMeter : MonoBehaviour
{
    public int health = 5;

    public void MinusHealth()
    {
        SetLives(--health);
    }
    
    void SetLives(int lives)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(lives > i);
        }
    }
}

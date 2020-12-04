using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.rotation = Quaternion.LookRotation(player.transform.position);
    }
}

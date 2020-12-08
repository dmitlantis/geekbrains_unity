using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Debug.Log("explosion");
            GetComponent<Rigidbody>().AddExplosionForce(100, other.transform.position, 1 , 1, ForceMode.Impulse);
        }
    }
}

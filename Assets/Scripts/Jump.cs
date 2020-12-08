using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jumper());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Jumper()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
        }
    }
}

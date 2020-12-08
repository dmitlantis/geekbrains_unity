using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    private Coroutine m_Courutine;
    // Start is called before the first frame update
    void Start()
    {
        m_Courutine = StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
       transform.rotation = Quaternion.LookRotation(player.transform.position);
       
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Vector3 targetDir = player.transform.position - transform.position;
            Vector3 startDir = transform.position;
            targetDir.y = 2;
            startDir.y = 3;
            Vector3 direction = Vector3.RotateTowards(startDir, targetDir,
                2, 0.0F);
            GameObject bull = Instantiate(bullet, startDir, Quaternion.identity);
            bull.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        }
    }
}

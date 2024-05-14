using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirectFly : MonoBehaviour
{
    int rndSpeed;
    void Start()
    {
        rndSpeed = Random.Range(3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * rndSpeed * Time.deltaTime);
    }
}

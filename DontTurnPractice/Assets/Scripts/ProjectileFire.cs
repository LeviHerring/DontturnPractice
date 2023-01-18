using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    //Reference to the projectile prefab
    public GameObject projectilePrefab;

    
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses the fire button
        //call the shoot function
        if(Input.GetButtonDown("Fire1"))
        {
            //Call the shoot fuction
            Shoot();
        }
    }

    void Shoot()
    {
       GameObject projectileGamebody = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Destroy(projectileGamebody, 3f);
    }
}

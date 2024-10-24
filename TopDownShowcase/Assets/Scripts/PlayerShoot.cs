using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //0.016667 = 60fps
        //If you click
        if (Input.GetButtonDown("Fire1") && timer > shootDelay)
        {
            timer = 0;
           //Shoot where cursor is
           Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //normalize the vector
            mouseDir.Normalize();
            //spawn bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //Pushh the bullet toward the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] float laserSpeed;

    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Projectile();
    }

    // The onward movement of laser projectile
    private void Projectile()
    {
        rb2d.velocity = transform.up * Time.deltaTime * laserSpeed;
    }
}

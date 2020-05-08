using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] float laserSpeed;
    [SerializeField] float minXTeleportBound;
    [SerializeField] float maxXTeleportBound;
    [SerializeField] float minYTeleportBound;
    [SerializeField] float maxYTeleportBound;
    [SerializeField] float destroyTime;

    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Terminate());
    }

    // Update is called once per frame
    void Update()
    {
        Projectile();
        Teleport();
    }

    // The onward movement of laser projectile
    private void Projectile()
    {
        rb2d.velocity = transform.up * Time.deltaTime * laserSpeed;
    }

    // Teleports the laser if it's moving out of camera view
    private void Teleport()
    {
        if (transform.position.x <= minXTeleportBound || transform.position.x >= maxXTeleportBound)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        else if (transform.position.y <= minYTeleportBound || transform.position.y >= maxYTeleportBound)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    // Countdown to destruction
    private IEnumerator Terminate()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject.gameObject);
    }


}

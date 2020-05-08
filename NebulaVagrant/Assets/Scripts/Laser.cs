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
    [SerializeField] float destructionCountdown;
    [SerializeField] int damage;

    Rigidbody2D rb2d;
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        StartCoroutine(Terminate());
        StartCoroutine(CollisionAdjustment());
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

    // Countdown to destruction... symphony of extinction lol =))
    private IEnumerator Terminate()
    {
        yield return new WaitForSeconds(destructionCountdown);
        Destroy(gameObject);
    }

    // This coroutine adjusts the behaviour between player's collider and laser's collider.
    // at the moment of shooting, there should be no collision between laser and player.
    // afterwards the player is vulnerable toward lasers.
    private IEnumerator CollisionAdjustment()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(0.1f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.Damage(damage);
            Destroy(gameObject);
        }
    }

}

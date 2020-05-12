using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    [SerializeField] float xForceBound;
    [SerializeField] float yForceBound;

    [SerializeField] int bigValue;
    [SerializeField] int mediumValue;
    [SerializeField] int smallValue;

    [SerializeField] int bigDamage;
    [SerializeField] int mediumDamage;
    [SerializeField] int smallDamage;

    int value, damage;

    float randomXForce, randomYForce;

    float bigMass = 5f;
    float mediumMass = 3.5f;
    float smallMass = 1.75f;

    bool isBig, isMedium, isSmall;

    Rigidbody2D rb2d;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

        Evaluate();
        PushIntoView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // After spawning, meteors should find their way in camera view.
    private void PushIntoView()
    {
        randomXForce = Random.Range(1, xForceBound);
        randomYForce = Random.Range(1, yForceBound);

        switch(gameObject.tag)
        {
            case "1": 
                rb2d.AddForce(new Vector2(randomXForce, -randomYForce), 
                    ForceMode2D.Impulse); break;

            case "2": 
            case "3":
                rb2d.AddForce(new Vector2(-randomXForce, -randomYForce),
                    ForceMode2D.Impulse); break;

            case "4":
            case "5":
                rb2d.AddForce(new Vector2(-randomXForce, randomYForce),
                    ForceMode2D.Impulse); break;

            case "6":
            case "7":
                rb2d.AddForce(new Vector2(randomXForce, randomYForce),
                    ForceMode2D.Impulse); break;

            case "8":
                rb2d.AddForce(new Vector2(randomXForce, -randomYForce),
                    ForceMode2D.Impulse); break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if a laser collides with meteor
        if (collision.gameObject.tag == "Laser")
        {
            if (isBig)
            {
                player.Score(bigValue);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            else if (isMedium)
            {
                player.Score(mediumValue);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

            else
            {
                player.Score(smallValue);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        // if the player collides with meteor
        else if (collision.gameObject.tag == "Player")
        {
            if (isBig)
            {
                player.Damage(bigDamage);
            }

            else if (isMedium)
            {
                player.Damage(mediumDamage);
            }

            else
            {
                player.Damage(smallDamage);
            }
        }
    }

    // Meteor self-destruction
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    // Sets values depending on what kind of meteor it is (Mass factor)
    private void Evaluate()
    {
        if(rb2d.mass == bigMass)
        {
            isBig = true;
            isMedium = false;
            isSmall = false;

            value = bigValue;
            damage = bigDamage;
        }

        else if(rb2d.mass == mediumMass)
        {
            isMedium = true;
            isBig = false;
            isSmall = false;

            value = mediumValue;
            damage = mediumDamage;
        }

        else if(rb2d.mass == smallMass)
        {
            isSmall = true;
            isBig = false;
            isMedium = false;

            value = smallValue;
            damage = smallDamage;
        }
    }


}

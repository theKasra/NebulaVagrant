using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float minXTeleportBound;
    [SerializeField] float maxXTeleportBound;
    [SerializeField] float minYTeleportBound;
    [SerializeField] float maxYTeleportBound;
    [SerializeField] int score = 0;
    [SerializeField] int health = 100;
    [SerializeField] float fuelConsume;
    [SerializeField] float refuelAmount;
    [SerializeField] float waitForRefuel;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider fuelBar;
    [SerializeField] Laser laser;
    [SerializeField] Text scoreText;

    float rotation;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
        RotateWithMouse();
        Teleport();
        Fire();
    }

    // This method moves the player based on fuel mechanism
    private IEnumerator Move()
    {
        if(fuelBar.value > 0)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))
                    * Time.deltaTime * movementSpeed);
                FuelConsume();
            }

            else
            {
                Refuel();
            }
        }

        else if(fuelBar.value == 0)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            yield return new WaitForSeconds(waitForRefuel);
            Refuel();
        }
        
    }

    // With the value of Mouse movement on X axis, this method rotates the player.
    private void RotateWithMouse()
    {
        if(Input.GetAxis("Mouse X")!=0)
        {
            rotation = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
            transform.Rotate(new Vector3(0, 0, 1)* -rotation);
        }
    }

    // Shoots a laser projectile
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, transform.position, transform.rotation);
        }
    }

    // Teleports the player if it's moving out of camera view
    private void Teleport()
    {
        if(transform.position.x <= minXTeleportBound || transform.position.x >= maxXTeleportBound)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        else if(transform.position.y <= minYTeleportBound || transform.position.y >= maxYTeleportBound)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    // Adding to score
    public void Score(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log("ouch");
        // Use a slider to indicate health bar and update it with every damage
    }

    private void FuelConsume()
    {
        fuelBar.value -= fuelConsume;
    }

    private void Refuel()
    {
        fuelBar.value += refuelAmount;
    }

}

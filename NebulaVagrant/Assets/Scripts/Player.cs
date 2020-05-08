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
    [SerializeField] float score = 0;
    [SerializeField] Laser laser;
    [SerializeField] Text scoreText;

    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateWithMouse();
        Teleport();
        Fire();
    }

    // This method moves the player
    // idea: charge bar for moving
    private void Move()
    {
        if (Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))
                * Time.deltaTime * movementSpeed);
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
    // You gain score by shooting meteors and enemy spaceships, each have their own score value.
    // Fix this part later.
    public void Score(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

}

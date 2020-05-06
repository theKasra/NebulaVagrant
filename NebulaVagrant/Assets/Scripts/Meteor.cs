using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    [SerializeField] float xForceBound;
    [SerializeField] float yForceBound;

    float randomXForce, randomYForce;


    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PushIntoView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PushIntoView()
    {
        randomXForce = Random.Range(0, xForceBound);
        randomYForce = Random.Range(0, yForceBound);

        switch(gameObject.tag)
        {
            case "1": 
                rb2d.AddForce(new Vector2(randomXForce, -randomYForce), 
                    ForceMode2D.Impulse); break;

            case "2": 
                //rb2d.AddForce(new Vector2(-randomXForce, -randomYForce),
                    //ForceMode2D.Impulse); break;

            case "3":
                rb2d.AddForce(new Vector2(-randomXForce, -randomYForce),
                    ForceMode2D.Impulse); break;

            case "4":
                //rb2d.AddForce(new Vector2(-randomXForce, randomYForce),
                    //ForceMode2D.Impulse); break;

            case "5":
                rb2d.AddForce(new Vector2(-randomXForce, randomYForce),
                    ForceMode2D.Impulse); break;

            case "6":
                //rb2d.AddForce(new Vector2(randomXForce, randomYForce),
                    //ForceMode2D.Impulse); break;

            case "7":
                rb2d.AddForce(new Vector2(randomXForce, randomYForce),
                    ForceMode2D.Impulse); break;

            case "8":
                rb2d.AddForce(new Vector2(randomXForce, -randomYForce),
                    ForceMode2D.Impulse); break;
        }
    }

}

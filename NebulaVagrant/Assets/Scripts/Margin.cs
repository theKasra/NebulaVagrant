using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Margin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Shredding the lasers when they get out of camera view
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
        }
    }
}

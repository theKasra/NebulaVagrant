using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{

    // Destroying everything getting too far from the main camera view
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}

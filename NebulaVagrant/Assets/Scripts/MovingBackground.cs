using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] float xValue;
    [SerializeField] float yValue;

    Material material;
    Vector2 offset;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            xValue = player.GetAxisHorizontal();
            yValue = player.GetAxisVertical();
            offset = new Vector2(xValue, yValue);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }
}

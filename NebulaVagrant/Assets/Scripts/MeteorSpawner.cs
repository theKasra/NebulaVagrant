using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] Meteor[] meteors;
    [SerializeField] float xPosBound, yPosBound;
    [SerializeField] float spawnDelay;

    int randomMeteorIndex, sidePicker;
    float randomXPos, randomYPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Spawns the meteors                      ^ y
    //                                         |
    // Visual outlook for the cases:    ---5---|---1---
    //                                  |      |      |
    //                                  4      |      3
    //                                  |=============| => x
    //                                  |      |      |
    //                                  8      |      6
    //                                  |      |      |
    //                                  ---7---|---2---
    // I mean... it works -_-
    private IEnumerator Spawn()
    {
        while(true)
        {
            randomMeteorIndex = Random.Range(0, meteors.Length);
            sidePicker = Random.Range(1, 8);
            randomXPos = Random.Range(0, xPosBound);
            randomYPos = Random.Range(0, yPosBound);

            switch(sidePicker)
            {
                case 1: Instantiate(meteors[randomMeteorIndex], 
                    new Vector2(randomXPos, yPosBound), Quaternion.identity); break;

                case 2:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(randomXPos, -yPosBound), Quaternion.identity); break;

                case 3:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(xPosBound, randomYPos), Quaternion.identity); break;

                case 4:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(-xPosBound, randomYPos), Quaternion.identity); break;

                case 5:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(-randomXPos, yPosBound), Quaternion.identity); break;

                case 6:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(xPosBound, -randomYPos), Quaternion.identity); break;

                case 7:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(-randomXPos, -yPosBound), Quaternion.identity); break;

                case 8:
                    Instantiate(meteors[randomMeteorIndex],
                new Vector2(-xPosBound, -randomYPos), Quaternion.identity); break;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}

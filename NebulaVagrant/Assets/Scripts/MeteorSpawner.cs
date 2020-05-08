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
    // Visual outlook for the cases:    ---1---|---2---
    //                                  |      |      |
    //                                  8      |      3
    //                                  |=============| => x
    //                                  7      |      4
    //                                  |      |      |
    //                                  ---6---|---5---
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
                case 1: Meteor meteor1 = Instantiate(meteors[randomMeteorIndex], 
                    new Vector2(-randomXPos, yPosBound), Quaternion.identity);
                    meteor1.tag = "1"; break;

                case 2:
                    Meteor meteor2 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(randomXPos, yPosBound), Quaternion.identity);
                    meteor2.tag = "2"; break;

                case 3:
                    Meteor meteor3 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(xPosBound, randomYPos), Quaternion.identity);
                    meteor3.tag = "3"; break;

                case 4:
                    Meteor meteor4 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(xPosBound, -randomYPos), Quaternion.identity);
                    meteor4.tag = "4"; break;

                case 5:
                    Meteor meteor5 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(randomXPos, -yPosBound), Quaternion.identity);
                    meteor5.tag = "5"; break;

                case 6:
                    Meteor meteor6 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(-randomXPos, -yPosBound), Quaternion.identity);
                    meteor6.tag = "6"; break;

                case 7:
                    Meteor meteor7 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(-xPosBound, -yPosBound), Quaternion.identity);
                    meteor7.tag = "7"; break;

                case 8:
                    Meteor meteor8 = Instantiate(meteors[randomMeteorIndex],
                new Vector2(-xPosBound, randomYPos), Quaternion.identity);
                    meteor8.tag = "8"; break;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}

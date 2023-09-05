using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MoveDown : MonoBehaviour
{
    public float bottomBoundZ = -10;
    public float startPositionZ = 10f;
    public float resetPosition = 30;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Fait avancer le sol.
        transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);

        /*
        //D�truit les objets lorsqu'il d�passe le bottomBoundZ.
        if (transform.position.z < bottomBoundZ)
        {
            transform.position = new Vector3(0, 0, startPositionZ);
            
        }*/

        if(transform.position.z < startPositionZ - resetPosition)
        {
            transform.position = startingPosition;
        }

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MoveDown : MonoBehaviour
{
    public float bottomBoundZ = -10;
    private float repeatWidth;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2f;
    }

    // Update is called once per frame
    void Update()
    {

        //Fait avancer le sol.
        transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);

        /*
        //Détruit les objets lorsqu'il dépasse le bottomBoundZ.
        if (transform.position.z < bottomBoundZ)
        {
            transform.position = new Vector3(0, 0, startPositionZ);
            
        }*/

        if(transform.position.z < startingPosition.z - 50)
        {
            transform.position = startingPosition;
        }

    }

}

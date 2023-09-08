using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MoveDown : MonoBehaviour
{
    private float bottomBoundZ = -20;
    private float repeatWidth = 500;
    private float speedDown = 2;
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

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speedDown * Time.deltaTime);
        //transform.Translate(new Vector3(0, 0, -2) * Time.deltaTime);


        //détruit les objets lorsqu'il dépasse le bottomboundz.
        if (transform.position.z < bottomBoundZ && gameObject != GameObject.Find("Ground"))
        {
            Destroy(gameObject);

        }

        if (gameObject == GameObject.Find("Ground"))
        if(transform.position.z < startingPosition.z - 50)
        {
            transform.position = startingPosition;
        }

    }

}

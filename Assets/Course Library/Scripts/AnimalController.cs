using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimalController : MonoBehaviour
{

    public float speed = 15.0f;
    private float maxBound = 20.0f;
    private bool isGoingRightDown = false;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Détecte si on atteint la limite maximale et fait faire une rotation à l'animal.
        
        if (transform.position.x < -maxBound)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            isGoingRightDown = true;

        }
        else if (transform.position.x > maxBound)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            isGoingRightDown = false;
        }

        //Ajuste la trajectoire de l'animal.
        if (isGoingRightDown) {
            transform.Translate(new Vector3(0.75f, 0, 1) * speed * Time.deltaTime);

        } else
        {
            transform.Translate(new Vector3(-0.75f, 0, 1) * speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }


}

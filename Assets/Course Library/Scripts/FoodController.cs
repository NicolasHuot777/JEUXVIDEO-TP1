using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class FoodController : MonoBehaviour
{
    private float speed = 10.0f;
    private float topBound = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fait avancer les objets.
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Détruit les objets lorsqu'il dépasse le bottomBoundZ.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        //Détecte une potentielle colission.
       
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée");
         Destroy(gameObject);
        if (other.gameObject.CompareTag("Animal"))
        {
            other.gameObject.SendMessage("Manger");
        }
    }
}

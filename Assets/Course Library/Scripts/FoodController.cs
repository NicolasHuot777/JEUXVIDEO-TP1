using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class FoodController : MonoBehaviour
{
    private float speed = 40.0f;
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

        //D�truit les objets lorsqu'il d�passe le bottomBoundZ.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        //D�tecte une potentielle colission.
       
    }
    public void OnTrigger(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Debug.Log(collision.gameObject);
            Destroy(gameObject);
            collision.gameObject.SendMessage("Manger");
        }
    }
}

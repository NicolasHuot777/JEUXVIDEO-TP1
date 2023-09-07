using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    private float horizontalSpeed = 2.0f;
    private float rotationSpeed = 50.0f;
    private float xRange = 17.0f;
    private float yRange = 40f;
    public GameObject pizzaPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Si le joueur dépasse la limite maximale à gauche.
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //Si le joueur dépasse la limite maximale à droite.
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Le joueur de déplace horizontalement.
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + horizontalInput * horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        transform.Rotate(0,horizontalInput * Time.deltaTime * rotationSpeed, 0);

        if (transform.rotation.y > yRange)
        {
            transform.Rotate(0, -horizontalInput * Time.deltaTime * rotationSpeed, 0);

        }
        if (transform.rotation.y < yRange)
        {
            transform.Rotate(0, -horizontalInput * Time.deltaTime * rotationSpeed, 0);
        }

        //Si on appui sur space une prefab pizza est générée aux coordonnées du joueur.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), pizzaPrefab.transform.rotation);
        }
    }

}

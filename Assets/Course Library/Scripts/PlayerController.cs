using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public GameObject pizzaPrefab;
    public AudioClip deadSong;
    public AudioClip pizzaSong;
    private AudioSource playerAudio;
    private float horizontalSpeed = 4.0f;
    private float rotationSpeed = 50.0f;
    private float xRange = 17.0f;
    private float yRangeLeft = 40f;
    private float yRangeRight = 320f;
    private float halfCercle = 180f;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Le joueur de déplace horizontalement.
        horizontalInput = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + horizontalInput * horizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //Le joueur rotationne selon son deplacent entre -40 et 40
        transform.Rotate(0, Time.deltaTime * rotationSpeed * horizontalInput, 0);
        if (transform.eulerAngles.y > yRangeLeft && transform.eulerAngles.y < halfCercle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRangeLeft, transform.eulerAngles.z);
        }
        if (transform.eulerAngles.y < yRangeRight && transform.eulerAngles.y > halfCercle)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRangeRight, transform.eulerAngles.z);
        }


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

        //Si on appui sur space une prefab pizza est générée aux coordonnées du joueur.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), pizzaPrefab.transform.rotation);
            playerAudio.PlayOneShot(pizzaSong, 0.2f);
        }

        if (GameOverTrigger.isGameOver)
        {
            playerAnim.SetTrigger("Death_01");
            playerAudio.PlayOneShot(deadSong, 0.2f);
        }
    }
}

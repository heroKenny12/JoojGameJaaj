using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("CharConfig")]
    [SerializeField]
    private float playerVelocity = 1f;
    [SerializeField]
    private float rotateVelocity = 1f;
    private Rigidbody rigidbody;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject shieldPosition;
    private GameObject shieldClone;
    //Definindo variaveis de rotação
    private Quaternion rotateRight;
    private Quaternion rotateLeft;
    private Quaternion rotateUp;
    private Quaternion rotateDown;
    private Quaternion rotateDgRight;
    private Quaternion rotateDgLeft;
    private Quaternion rotateDgDownLeft;
    private Quaternion rotateDgDownRight;
    void Start()
    {
        //Atribuindo rotações 
        rotateDgDownLeft = Quaternion.Euler(0f, -140f, 0f);
        rotateDgDownRight = Quaternion.Euler(0f, 140f, 0f);
        rotateDgLeft = Quaternion.Euler(0f, -45f, 0f);
        rotateDgRight = Quaternion.Euler(0f, 45f, 0f);
        rotateUp = Quaternion.Euler(0f, 0f, 0f);
        rotateDown = Quaternion.Euler(0f, 180f, 0f);
        rotateLeft = Quaternion.Euler(0f, -90f, 0f);
        rotateRight = Quaternion.Euler(0f, 90f, 0f); 
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector3(horizontal * playerVelocity, rigidbody.velocity.y, vertical * playerVelocity);
        if(Input.GetMouseButton(0) && shieldClone == null)
        {
            shieldClone = Instantiate(shield, shieldPosition.transform);
            Destroy(shieldClone, 1f);
        }
        if (Input.GetMouseButton(1))
        {
            playerVelocity = 25f;
            GetComponent<Animator>().SetBool("Running", true);
            GetComponent<Animator>().SetBool("Walking", false);
        }
        else
        {
            playerVelocity = 15f;
            GetComponent<Animator>().SetBool("Running", false);
            GetComponent<Animator>().SetBool("Walking", true);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            while(transform.rotation != rotateRight)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            while (transform.rotation != rotateLeft)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            while (transform.rotation != rotateUp)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            while (transform.rotation != rotateDown)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            while (transform.rotation != rotateDgRight)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            while (transform.rotation != rotateDgLeft)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            while (transform.rotation != rotateDgDownLeft)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            while (transform.rotation != rotateDgDownRight)
            {
                transform.Rotate(0f, rotateVelocity * Time.deltaTime, 0f);
            }
        } else
        {
            GetComponent<Animator>().SetBool("Running", false);
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }
}

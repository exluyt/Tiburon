using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtenemos el componente Rigidbody
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; // Bloqueamos el movimiento en el eje Z y la rotación en todos los ejes
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Obtenemos el input horizontal (A, D, Left Arrow, Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Obtenemos el input vertical (W, S, Up Arrow, Down Arrow)

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0); // Creamos un vector de movimiento

        rb.velocity = movement * speed; // Aplicamos el movimiento al Rigidbody
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "boton") // Si el objeto con el que colisionamos tiene el tag "Objeto"
        {
            Debug.Log("Has tocado un objeto");
        }
    }
}

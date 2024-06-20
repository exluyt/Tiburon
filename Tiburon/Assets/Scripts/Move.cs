using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
     public float speed = 5.0f; // Velocidad de movimiento
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Obtenemos el input horizontal (A, D, Left Arrow, Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Obtenemos el input vertical (W, S, Up Arrow, Down Arrow)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // Creamos un vector de movimiento
    
        rb.velocity = movement * speed; // Aplicamos el movimiento al Rigidbody2D
    }
}

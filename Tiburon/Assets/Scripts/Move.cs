using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento
    public GameObject blockPrefab; // Prefab del bloque
    public float blockDistance = 1.0f; // Distancia delante del jugador donde se creará el bloque
    public Transform sphere; // Referencia a la esfera
    private Rigidbody rb;
    private float lastMoveHorizontal; // Almacenamos la dirección del último movimiento

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtenemos el componente Rigidbody
        rb.constraints = RigidbodyConstraints.FreezeRotation; //Bloqueamos la rotación en todos los ejes
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal =
            Input.GetAxis("Horizontal"); // Obtenemos el input horizontal (A, D, Left Arrow, Right Arrow)
        float moveVertical = 0; // Inicializamos moveVertical a 0

        // Si se presiona la tecla de arriba, aumentamos moveVertical
        if (Input.GetAxis("Vertical") > 0)
        {
            moveVertical += 1;
        }
        if (Input.GetAxis("Vertical") < 0) // Si se presiona la tecla de abajo, disminuimos moveVertical
        {
            moveVertical -= 1;
        }
        

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical); // Creamos un vector de movimiento

        rb.velocity = movement * speed; // Aplicamos el movimiento al Rigidbody

        if (moveHorizontal != 0) // Si el personaje se está moviendo horizontalmente
        {
            lastMoveHorizontal = Mathf.Sign(moveHorizontal); // Almacenamos la dirección del último movimiento
            transform.eulerAngles = new Vector3(0, lastMoveHorizontal > 0 ? 180 : 0, 0); // Giramos el personaje
        }

        if (Input.GetKeyDown(KeyCode.J)) // Si se presiona la tecla J
        {
            Vector3 blockPosition =
                transform.position +
                new Vector3(blockDistance * lastMoveHorizontal * 2, 0, 0); // Calculamos la posición del bloque
            blockPosition.y =
                transform.position
                    .y; // Ajustamos la posición en el eje Y del bloque para que sea la misma que la del personaje
            GameObject block = Instantiate(blockPrefab, blockPosition, Quaternion.identity); // Creamos el bloque
            Destroy(block, 0.2f); // Destruimos el bloque 0.5 segundos después
        }
    }
}
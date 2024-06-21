using UnityEngine;
using UnityEngine.Timeline;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que se moverá el enemigo
    private Transform player; // Referencia al jugador
    private bool isAtacking = false; // Variable para saber si el enemigo está atacando

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscamos al jugador por su tag
    }

    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) >
            1.5f) // Si la distancia entre el jugador y el enemigo es mayor a 1.5
        {
            Move(); // Movemos al enemigo
        }
        else // Si la distancia entre el jugador y el enemigo es menor a 1.5
        {
            if (!isAtacking) // Si el enemigo no está atacando
            {
                isAtacking = true; // Cambiamos la variable a true
                //Attack(); // Llamamos a la función Attack después de 1 segundo
            }
        }
    }

    public void Move()
    {
        if (player != null && !isAtacking) // Si el jugador existe
        {
            Vector3 direction =
                (player.position - transform.position).normalized; // Calculamos la dirección hacia el jugador
            direction.y = 0; // Ignoramos el movimiento en el eje Y
            Vector3 movement = direction * speed * Time.deltaTime; // Calculamos el movimiento
            transform.position += movement; // Movemos el enemigo hacia el jugador
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject
            .CompareTag("block")) // Si el objeto con el que el enemigo ha colisionado tiene el tag "TriggerTag"
        {
            Destroy(gameObject); // Destruimos el enemigo
        }
    }
}
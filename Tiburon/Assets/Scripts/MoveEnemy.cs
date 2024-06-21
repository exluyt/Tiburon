using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que se moverá el enemigo
    private Transform player; // Referencia al jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscamos al jugador por su tag
    }

    void Update()
    {
        if (player != null) // Si el jugador existe
        {
            Vector3 direction = (player.position - transform.position).normalized; // Calculamos la dirección hacia el jugador
            Vector3 movement = direction * speed * Time.deltaTime; // Calculamos el movimiento
            transform.position += new Vector3(movement.x, movement.y, 0); // Movemos el enemigo hacia el jugador
        }
    }
}

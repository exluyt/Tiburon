using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemigo") // Si el objeto con el que el bloque ha colisionado tiene el tag "Enemigo"
        {
            Destroy(collision.gameObject); // Destruimos el objeto con el que el bloque ha colisionado
        }
    }
}
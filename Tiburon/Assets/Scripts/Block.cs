using UnityEngine;

public class Block : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject
            .CompareTag("enemigo")) // Si el objeto con el que el bloque está en contacto tiene el tag "enemigo"
        {
            Debug.Log("El bloque está en contacto con el enemigo.");

            Rigidbody
                enemyRb = other.gameObject.GetComponent<Rigidbody>(); // Obtenemos el componente Rigidbody del enemigo
            if (enemyRb != null) // Si el enemigo tiene un componente Rigidbody
            {
                enemyRb.useGravity = false; // Desactivamos la gravedad
            }

            // Desactivamos el objeto
            other.gameObject.SetActive(false);

            // Destruimos el objeto
            Destroy(other.gameObject);

            Debug.Log("El objeto ha sido destruido.");
        }
    }
}
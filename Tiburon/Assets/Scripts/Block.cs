using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent != null &&
            collision.gameObject.transform.parent.tag ==
            "enemigo") // Si el objeto con el que el bloque ha colisionado es hijo de un objeto con el tag "Enemigo"
        {
            Destroy(collision.gameObject.transform.parent
                .gameObject); // Destruimos el objeto padre con el que el bloque ha colisionado
        }
    }
    
   
}
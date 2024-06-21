using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float xPosition = 0; // Posición en el eje X donde se crearán los enemigos
    public int maxEnemies = 10; // Máximo número de enemigos a crear
    public float minSpawnTime = 1f; // Tiempo mínimo entre spawns
    public float maxSpawnTime = 5f; // Tiempo máximo entre spawns

    void Start()
    {
        StartCoroutine(SpawnEnemies()); // Iniciamos la coroutinea
    }

    IEnumerator SpawnEnemies()
    {
        GameObject emptyObject = GameObject.Find("Spawn"); // Encuentra el objeto vacío en la escena
        float yPosition = emptyObject.transform.position.y; // Obtiene la posición en el eje Y del objeto vacío

        float[] zPositions = new float[] { 6, 3, 0}; // Posiciones en el eje Z donde se crearán los enemigos

        for (int i = 0; i < maxEnemies; i++) // Para cada enemigo hasta maxEnemies
        {
            float zPosition =
                zPositions
                    [Random.Range(0, zPositions.Length)]; // Escogemos una posición en el eje Z de manera aleatoria
            Vector3
                enemyPosition =
                    new Vector3(transform.position.x, yPosition,
                        zPosition); // Creamos un vector de posición para el enemigo manteniendo la posición en X del objeto que crea los enemigos y la posición en Y del objeto vacío
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity); // Creamos el enemigo

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime); // Calculamos un tiempo de spawn aleatorio
            yield return
                new WaitForSeconds(spawnTime); // Esperamos el tiempo de spawn antes de crear el próximo enemigo
        }
    }
}
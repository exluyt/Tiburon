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
        float[] yPositions = new float[] { -5, -7, -9 }; // Posiciones en el eje Y donde se crearán los enemigos

        for (int i = 0; i < maxEnemies; i++) // Para cada enemigo hasta maxEnemies
        {
            float yPosition = yPositions[Random.Range(0, yPositions.Length)]; // Escogemos una posición en el eje Y de manera aleatoria
            Vector3 enemyPosition = new Vector3(transform.position.x, yPosition, transform.position.z); // Creamos un vector de posición para el enemigo manteniendo la posición en X y Z del objeto que crea los enemigos
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity); // Creamos el enemigo

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime); // Calculamos un tiempo de spawn aleatorio
            yield return new WaitForSeconds(spawnTime); // Esperamos el tiempo de spawn antes de crear el próximo enemigo
        }
    }
}
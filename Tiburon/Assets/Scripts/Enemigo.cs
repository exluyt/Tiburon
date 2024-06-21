using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private GameObject enemyPre;
    [SerializeField] private int maxEne = 209;
    
    private Transform player; // Referencia al jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscamos al jugador por su tag

        StartCoroutine(SpawnCorrutine());
    }

    private IEnumerator SpawnCorrutine()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < maxEne; i++)
        {
            SpawnEne();
            yield return new WaitForSeconds(1);
        }
    }
    
    private void SpawnEne() => Instantiate(enemyPre, spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity);

   
}
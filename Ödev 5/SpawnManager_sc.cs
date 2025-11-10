using System.Collections;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]  // Bunla private olsa bile görebiliriz. 
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject TripleShotBonusPrefab;


    [SerializeField]
    bool stopSpawning = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            StartCoroutine(SpawnEnemyRoutine());
            StartCoroutine(SpawnBonusRoutine());
    }

    // Update is called once per frame
    void Update()
    {
          
    }

IEnumerator SpawnEnemyRoutine(){
    while(stopSpawning == false){
        Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f),
                                                    7.4f,
                                                    0);
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.transform.parent = enemyContainer.transform;  // Senin parentın aslında enemy container 
        yield return new WaitForSeconds(5.0f);  // 5 sn beklemek için 
    }
}

IEnumerator SpawnBonusRoutine()
{
    while(stopSpawning == false)
    {
        

        Vector3 position = new Vector3(Random.Range(-9.18f, 9.18f),
                                                    7.7f,
                                                    0);
        GameObject TripleShotBonus = Instantiate(TripleShotBonusPrefab, position, Quaternion.identity);   
        int waitTime = Random.Range(3,8);
        Debug.Log("Üçlü atış bekleme süresi: " +waitTime);
        yield return new WaitForSeconds((float) waitTime);

    }
}

public void OnPlayerDeath(){

        stopSpawning = true;
     }       
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public  GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int xxPos;
    public int zzPos;
    public int xxxPos;
    public int zzzPos;
    public int xxxxPos;
    public int zzzzPos;
    public int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        //x=-121 and -55; z= -39 and -69; y= 35
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {
            xPos = Random.Range(-120, -55);
            zPos = Random.Range(-77, -12);
            Instantiate(theEnemy, new Vector3(xPos, 29, zPos), Quaternion.identity);

            xxPos = Random.Range(-175, -133);
            zzPos = Random.Range(24, 80);
            Instantiate(theEnemy, new Vector3(xxPos, 29, zzPos), Quaternion.identity);

            xxxPos = Random.Range(-95, 37);
            zzzPos = Random.Range(236, 287);
            Instantiate(theEnemy, new Vector3(xxxPos, 29, zzzPos), Quaternion.identity);

            xxxxPos = Random.Range(-18, 67);
            zzzzPos = Random.Range(88, 90);
            Instantiate(theEnemy, new Vector3(xxxxPos, 29, zzzzPos), Quaternion.identity);

            yield return new WaitForSeconds(0.01f);
            enemyCount ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject[] Item;

    public float interval;
    public float range = 48.0f;
    public int spawncheck = 0;
    private int objectindex = 0;
    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            if (spawncheck%10 == 0)
            {                                
                interval -= 0.2f;
                if (interval <= 0.1f)
                    interval = 0.1f;
                GameObject.Find("GameManager").GetComponent<EnemyHealthController>().HPUP();
            }            

            if(spawncheck%3 == 0)
            {                
               
                Instantiate(Item[Random.Range(0, 5)], new Vector3(Random.Range(-range, range), 2, Random.Range(-range, range)), Quaternion.Euler(-90.0f, 0, 0));

            }

            if (spawncheck % 4 == 0)
                transform.position = new Vector3(-60, transform.position.y, Random.Range(-range, range));

            else if (spawncheck % 4 == 1)
                transform.position = new Vector3(60, transform.position.y, Random.Range(-range, range));

            else if (spawncheck % 4 == 2)
                transform.position = new Vector3(Random.Range(-range, range), transform.position.y, -60);

            else if (spawncheck % 4 == 3)
                transform.position = new Vector3(Random.Range(-range, range), transform.position.y, 60);

            Instantiate(Enemy[Random.Range(0, 3)], transform.position, transform.rotation);
            spawncheck++;
            yield return new WaitForSeconds(interval);

        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
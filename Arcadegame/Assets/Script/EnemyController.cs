using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject hitEffectPrefab = null;
    public GameObject hpBarPrefab;
    public Vector3 hpBaroffset = new Vector3(0, 2.0f, 0);

    private Canvas UIcanvas;
    public Slider healthBar;

    private int health;
    private int Inithealth;
    public int Enemytype;
    private Transform _transform;
    private Transform PlayerTransform;
    private NavMeshAgent nvAgent;
    

    // Use this for initialization
    void Start()
    {
        if (Enemytype == 1)
            Inithealth = GameObject.Find("GameManager").GetComponent<EnemyHealthController>().rabbithp;
        else if (Enemytype == 2)
            Inithealth = GameObject.Find("GameManager").GetComponent<EnemyHealthController>().slimehp;
        else if (Enemytype == 3)
            Inithealth = GameObject.Find("GameManager").GetComponent<EnemyHealthController>().bathp;



        healthBar.maxValue = Inithealth;
        health = Inithealth;        
        _transform = this.gameObject.GetComponent<Transform>();
        PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        nvAgent.destination = PlayerTransform.position;
        healthBar.value = health;
    }
        

    private void OnTriggerEnter(Collider hitCollider)
    {        
        if (hitCollider.gameObject.tag == "Bullet")
            health -= GameObject.FindWithTag("Player").GetComponent<Player>().BulletDamage;

        if (hitCollider.gameObject.tag == "Explosion")
            health -= GameObject.FindWithTag("Player").GetComponent<Player>().ExplosionDamage;

        if (hitCollider.gameObject.tag == "Superpower")
            health = 0;

        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Score").GetComponent<Score>().ScoreUP();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().PowerBarUp();
        }
    }
}




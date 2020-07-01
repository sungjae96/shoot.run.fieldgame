using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int ItemType;
    public GameObject Itemeffect;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (ItemType == 1)
                GameObject.FindWithTag("Player").GetComponent<Player>().SpeedUp();

            else if (ItemType == 2)
                GameObject.FindWithTag("Player").GetComponent<Player>().DamageUP();

            else if (ItemType == 3)
            {
                if (GameObject.FindWithTag("Player").GetComponent<Player>().Bulletthrough == true)
                    GameObject.FindWithTag("Player").GetComponent<Player>().DamageUP();
                else
                    GameObject.FindWithTag("Player").GetComponent<Player>().bulletthroughtrue();
            }

            else if (ItemType == 4)
            {
                if (GameObject.FindWithTag("Player").GetComponent<Player>().Explosioncheck == true)
                    GameObject.FindWithTag("Player").GetComponent<Player>().ExplosionDamageUP();
                else
                    GameObject.FindWithTag("Player").GetComponent<Player>().Explosiontrue();
            }

            else if (ItemType == 5)
                GameObject.FindWithTag("Player").GetComponent<Damage>().healthUP();

            Vector3 effectposition = transform.position;

            effectposition.y = 0;

            Instantiate(Itemeffect, effectposition, transform.rotation);
            Destroy(this.gameObject);
        }
           
    }
}

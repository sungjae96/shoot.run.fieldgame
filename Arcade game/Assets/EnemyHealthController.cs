using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int bathp;
    public int slimehp;
    public int rabbithp;

    // Start is called before the first frame update
    void Start()
    {
        bathp = 25;
        rabbithp = 50;
        slimehp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPUP()
    {
        bathp += 25;
        rabbithp += 50;
        slimehp += 100;
    }
}

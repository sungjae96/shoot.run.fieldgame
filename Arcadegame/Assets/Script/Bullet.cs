﻿using UnityEngine;
using System.Collections;

// 총알 클래스: 무엇이든 이 총알에 닿으면 총알은 효과를 표시하며 사라짐
public class Bullet : MonoBehaviour
{

    private static readonly	float bulletMoveSpeed = 10.0f;	// 1초 동안 총알이 나아가는 거리
	public GameObject hitEffectPrefab = null;				// 닿은 효과 프리팹
    public GameObject ExplosionPrefab = null;

    private void Start()
    {

    }

    //	매 프레임마다 호출되는 함수
    private	void Update()
    {
        // 이동처리

        // 1초 동안 이동량: Vector3에 transform.rotation을 곱하면 그 방향으로 꺾임
        // 이때, Vector3는 Z+방향을 정면으로 여김
        // Vector3.forward는 new Vector3( 0f, 0f, 1f)와 같음
        // 그 밖의 사항은 아래에 표시한 웹 페이지를 참조
        Vector3 vecAddPos = (Vector3.forward * bulletMoveSpeed);

        // 이동량, 회전량에는 Time.deltaTime을 곱해서 실행 환경(프레임률)에 따른 차이를 해결
		transform.position	+= ((transform.rotation	* vecAddPos) * Time.deltaTime);
	}

    // Collider가 어떤 물체에 닿으면 호출되는 함수: 자신의 GameObject에 Collider(IsTrigger를 
    // ON으로 하여)와 Rigidbody를 적용하면 호출 가능한 상태가 됨
	private	void OnTriggerEnter(Collider hitCollider)
    {
        // 히트(닿았을 때) 효과가 있는지 검사
		if (null != hitEffectPrefab)
        {
            // 자신의 위치에서 히트 효과를 연출
			Instantiate(hitEffectPrefab, transform.position, transform.rotation);
		}

        if (hitCollider.gameObject.tag == "Enemy" && GameObject.FindWithTag("Player").GetComponent<Player>().Explosioncheck == true)
        {
            Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }

        if (GameObject.FindWithTag("Player").GetComponent<Player>().Bulletthrough == false)
        {
            Destroy(gameObject);
        }

        if (hitCollider.gameObject.tag != "Enemy" && hitCollider.gameObject.tag != "Explosion" && hitCollider.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }

        


    }		
}

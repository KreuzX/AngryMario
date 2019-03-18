using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : CoinGettableBlock
{
    public Material hitBlockMaterial;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Renderer _renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();

        _rigidbody.isKinematic = true;
    }

    /// <summary>
    /// OnCollisoinEnter블록의 Rigidbody컴포넌트의 속성을 참조합니다.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockRadius"))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _collider.isTrigger = false;
            StartCoroutine(HitReaction());
        }
    }

    /// <summary>
    /// 충돌한 지점에 폭발 물리를 적용합니다.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Rock"))
        {
            _rigidbody.AddExplosionForce(1000.0f, collision.transform.position, 10.0f);
        }
    }

    /// <summary>
    /// OnTriggerEnter가 호출되면 코인 생성, 머티리얼 교체 그리고 사라짐을 처리합니다.
    /// </summary>
    /// <returns></returns>
    private IEnumerator HitReaction()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(coin, transform.position, Quaternion.identity);
        _renderer.sharedMaterial = hitBlockMaterial;
        yield return new WaitForSeconds(5.0f);
        _collider.isTrigger = true;
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}

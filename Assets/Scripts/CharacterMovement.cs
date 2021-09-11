using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : UpgradedMonoBehaviour
{
    private Animator animator;

    public GameObject armoredParticleEffect;
    public GameObject doubleParticleEffect;
    public GameObject scoreParticleEffect;

    private float angle = 0;
    public float maxAngle = 40;
    public float minAngle = -40;
    public float turnSpeed = 20;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        angle += movementManager.movementDirectionVector.x >  0 ? turnSpeed : -turnSpeed;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinController.AddToTempCoin(1);
            Destroy(Instantiate(scoreParticleEffect, transform.position, Quaternion.identity), 1f);
        }
        else if (collision.CompareTag("DoubleCoin"))
        {
            StartCoroutine(DoubleScored());
            Destroy(Instantiate(doubleParticleEffect, transform.position, Quaternion.identity), 1f);
        }
        else if (collision.CompareTag("Armored"))
        {
            gameStateController.TransitionToState(gameStateController.OverState);
            Destroy(gameObject);
            Destroy(Instantiate(armoredParticleEffect, transform.position, Quaternion.identity), 3f);
        }
    }

    public IEnumerator DoubleScored()
    {
        animator.SetTrigger("blue");
        coinController.IsDoubleCoin = true;
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("white");
        coinController.IsDoubleCoin = false;
    }
}

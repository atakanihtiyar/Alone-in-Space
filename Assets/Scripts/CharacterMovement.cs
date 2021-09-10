using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GameStateController gameStateController;

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
        gameStateController = GameStateController.Instance;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        angle += MovementManager.Instance.movementDirectionVector.x >  0 ? turnSpeed : -turnSpeed;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            CoinController.Instance.AddToTempCoin(1);
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
        CoinController.Instance.IsDoubleCoin = true;
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("white");
        CoinController.Instance.IsDoubleCoin = false;
    }
}

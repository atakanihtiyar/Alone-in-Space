using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : UpgradedMonoBehaviour
{
    private Animator animator;

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
        if (collision.CompareTag("DoubleCoin"))
        {
            StartCoroutine(DoubleScored());
        }
        else if (collision.CompareTag("Armored"))
        {
            Destroy(gameObject);
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

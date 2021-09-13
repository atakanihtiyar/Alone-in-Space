using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for character movement
/// </summary>
public class CharacterMovement : UpgradedMonoBehaviour
{
    private Animator animator;

    private float angle = 0;
    private float maxAngle = 40;
    private float minAngle = -40;
    private float turnSpeed = 20;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        angle += movementManager.MovementDirectionVector.x >  0 ? turnSpeed : -turnSpeed;
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

    private IEnumerator DoubleScored()
    {
        animator.SetTrigger("blue");
        coinController.isDoubleCoinActive = true;
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("white");
        coinController.isDoubleCoinActive = false;
    }
}

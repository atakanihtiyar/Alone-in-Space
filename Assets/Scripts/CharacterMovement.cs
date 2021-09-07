using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GameManager gameManager;

    private Animator animator;

    public GameObject armoredParticleEffect;
    public GameObject doubleParticleEffect;
    public GameObject scoreParticleEffect;

    private float angle = 0;
    public float maxAngle = 40;
    public float minAngle = -40;
    public float acceleration = 20;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        angle += gameManager.isGoingRight ? acceleration : -acceleration;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shape"))
        {
            Shape hitShape = collision.gameObject.GetComponent<Shape>();
            
            if (gameManager.currentGameState == GameState.PlayPattern)
            {
                Pattern pattern = hitShape.transform.parent.transform.parent.GetComponent<Pattern>();
                pattern.deactivatedShapes.Add(hitShape.gameObject);
                hitShape.gameObject.SetActive(false);
            }
            if (gameManager.currentGameState == GameState.PlayAbsoluteRandom)
            {
                Destroy(hitShape.transform.parent.gameObject);
            }
        }
    }

    public IEnumerator DoubleScored()
    {
        animator.SetTrigger("blue");
        gameManager.isDoubleScore = true;
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("white");
        gameManager.isDoubleScore = false;
    }
}

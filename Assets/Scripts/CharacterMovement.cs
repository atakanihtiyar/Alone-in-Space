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

    private bool isGoingRight;
    private float angle = 0;
    public float maxAngle;
    public float minAngle;
    public float acceleration;

    void Start()
    {
        gameManager = GameManager.instance;

        animator = GetComponent<Animator>();

        isGoingRight = gameManager.isGoingRight;
        if (isGoingRight)
            angle = 40;
        else
            angle = -40;
    }

    void Update()
    {
        if (gameManager.currentGameState == GameState.PlayAbsoluteRandom || gameManager.currentGameState == GameState.PlayPattern || gameManager.currentGameState == GameState.mainMenu)
        {
            isGoingRight = gameManager.isGoingRight;

            if (isGoingRight)
            {
                if (angle < maxAngle)
                    angle += acceleration;
            }
            else
            {
                if (angle > minAngle)
                    angle -= acceleration;
            }
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shape"))
        {
            Shape hitShape = collision.gameObject.GetComponent<Shape>();
            if (hitShape.myShapeType == ShapeType.armored)
            {
                gameManager.GameOver();
                Destroy(gameObject);
                Destroy(Instantiate(armoredParticleEffect, hitShape.transform.position, Quaternion.identity), 3f);
            }
            else if (hitShape.myShapeType == ShapeType.doubleScore)
            {
                StartCoroutine(DoubleScored());
                Destroy(Instantiate(doubleParticleEffect, hitShape.transform.position, Quaternion.identity), 1f);
            }
            else if (hitShape.myShapeType == ShapeType.score)
            {
                gameManager.AddScore(1);
                Destroy(Instantiate(scoreParticleEffect, hitShape.transform.position, Quaternion.identity), 1f);
            }


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

    private IEnumerator DoubleScored()
    {
        animator.SetTrigger("blue");
        gameManager.isDoubleScore = true;
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("white");
        gameManager.isDoubleScore = false;
    }
}

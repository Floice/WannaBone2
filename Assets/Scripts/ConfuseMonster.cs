using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfuseMonster : MonoBehaviour
{
    public Transform player;
    public float scanRadius = 1.6f;
    public float moveSpeed = 1.5f;
    public float stopDistance = 0.5f;
    public GameObject replacementPrefab;
    public List<GameObject> targets;
    public Sprite newSprite;
    private bool isMoving = false;

    private void Update()
    {
        ScanForTargets();
    }

    private void ScanForTargets()
    {
        foreach (GameObject target in targets)
        {
            if (target != null && IsTargetInRange(target))
            {
                isMoving = true;
                MoveTowardsPlayer(target);
                break;
            }
        }
    }

    private bool IsTargetInRange(GameObject target)
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        return distance <= scanRadius;
    }

    private void MoveTowardsPlayer(GameObject target)
    {
        if (target != null && isMoving)
        {
            Vector2 direction = player.position - target.transform.position;
            float distance = direction.magnitude;

            if (distance > stopDistance)
            {
                target.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Stop moving
                isMoving = false;

                // Change sprite
                SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = newSprite;
                }

                // Destroy current target
                Destroy(target);

                // Instantiate replacementPrefab at target's position
                if (replacementPrefab != null)
                {
                    Instantiate(replacementPrefab, target.transform.position, Quaternion.identity);
                }
            }
        }
    }
}


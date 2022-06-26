using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintOutLayerFix : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void FixedUpdate()
    {
        spriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y / 0.16f);
    }
}

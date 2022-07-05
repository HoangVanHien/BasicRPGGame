using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintOutLayerFix : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderer = new List<SpriteRenderer>();

    private void FixedUpdate()
    {
        foreach (SpriteRenderer sr in spriteRenderer)
        {
            sr.sortingOrder = -Mathf.RoundToInt(transform.position.y / 0.16f) * 2 + 1;
        }
    }
}

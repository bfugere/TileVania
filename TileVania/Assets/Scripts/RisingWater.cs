using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [Tooltip ("Game Units per Second")]
    [SerializeField] float risingWaterSpeed = 0.2f;

    void Update()
    {
        float yMove = risingWaterSpeed * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
}

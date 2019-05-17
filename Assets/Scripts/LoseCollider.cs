using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour {

    Level level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        level = FindObjectOfType<Level>();
        level.BallDestroyed();
    }
}

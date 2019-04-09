using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        print("hit" + col.name + "!");
        Destroy(gameObject);
    }
}

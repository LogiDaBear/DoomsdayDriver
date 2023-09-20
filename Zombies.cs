using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField] Color32 hasZombieColor = new Color32 (1, 0, 0, 1);
    [SerializeField] Color32 noZombieColor = new Color32 (1, 0, 0, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasRaider;
    bool hasZombie;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision has happened!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boosted" && hasZombie)
        {
            Debug.Log("Boosted!");
            hasZombie = false;
            spriteRenderer.color = noZombieColor;
        }
        if (other.tag == "Zombie" && !hasZombie)
        {
            Debug.Log("10 points");
            hasZombie = true;
            spriteRenderer.color = hasZombieColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Raider")
        {
            Debug.Log("+5 Health");
            hasRaider = true;
        }
        // Debug.Log("Trigger activated!");
    }
}

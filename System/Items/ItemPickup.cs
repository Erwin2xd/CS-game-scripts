using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private float radius = 2f;
    public Transform player;
    private bool hasInteracted = false;
    public Item item;
    float distance;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(player != null)
            distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            if (!hasInteracted)
            {
                Interract();
                hasInteracted = true;
            }
        }
        else
            hasInteracted = false;
    }
    private void Interract()
    {
        PickUp();
    }
    private void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
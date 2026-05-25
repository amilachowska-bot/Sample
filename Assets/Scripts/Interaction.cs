using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public GameObject target;
    public List<GameObject> inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        target = other.gameObject;
        // other.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        if (target != null)
        {
            inventory.Add(target);
            target.SetActive(false);
            target = null;
        }
        else if (inventory.Count > 0)
        {
            GameObject item = inventory.First();
            inventory.Remove(item);
            item.transform.position = transform.position;
            item.SetActive(true);
        }
    }
}

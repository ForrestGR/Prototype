using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;


public class ButtonScript : MonoBehaviour
{
    public GameObject bridge;
    public NavMeshSurface navSurface;

    private void Start()
    {
        bridge.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridge.SetActive(true);
            navSurface.BuildNavMesh();
        }
    }
}
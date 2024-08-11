using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Animations;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private AIDestinationSetter aIDestinationSetter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PLAYER");

        if (player != null) {
            aIDestinationSetter.target = player.transform;
        } else {
            Debug.LogWarning("No GameObject tagged 'Player' found in the scene.");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}

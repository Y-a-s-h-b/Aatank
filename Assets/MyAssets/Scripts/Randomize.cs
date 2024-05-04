using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    public List<GameObject> gameObjectsList;

    void Start()
    {
        // Check if the list is empty
        if (gameObjectsList.Count == 0)
        {
            Debug.LogWarning("No GameObjects in the list.");
            return;
        }

        // Get a random index
        int randomIndex = Random.Range(0, gameObjectsList.Count);

        // Enable the GameObject at the random index
        gameObjectsList[randomIndex].SetActive(true);
    }
}

using System.Collections;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    private void Start() {
        InvokeRepeating("LightningActive", 0.1f, 2);
    }

    private void LightningActive()
    {
        // Generate a random number between 0 and 3 (inclusive)
        int randomChance = Random.Range(0, 4);

        // If the random number is 0, activate the lightning and start the coroutine to deactivate it after 2 seconds
        if (randomChance == 0)
        {
            StartCoroutine(ActivateLightning());
        }
    }

    private IEnumerator ActivateLightning()
    {
        lightning.SetActive(true);
        yield return new WaitForSeconds(2); // Wait for 2 seconds
        lightning.SetActive(false);
    }
}


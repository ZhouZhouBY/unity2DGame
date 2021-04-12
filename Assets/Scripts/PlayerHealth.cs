using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathVFXPrefab;
    public GameObject deathVFXPrefab2;
    int trapsLayer;

    // Start is called before the first frame update
    void Start()
    {
        trapsLayer = LayerMask.NameToLayer("Traps");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == trapsLayer)
        {
            Instantiate(deathVFXPrefab2, transform.position, transform.rotation);
            Instantiate(deathVFXPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(-45, 90)));
            gameObject.SetActive(false);
            AudioManager.PlayDeathAudio();

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.PlayerDied();
        }
    }
}

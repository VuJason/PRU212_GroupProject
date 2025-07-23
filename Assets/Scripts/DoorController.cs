using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator[] doorAnimators;
    private GameObject[] enemies;
    private bool doorClosed = false;

    public void SetEnemies(GameObject[] spawnedEnemies)
    {
        enemies = spawnedEnemies;
    }

    private void Update()
    {
        if (doorClosed && enemies != null && AllEnemiesDefeated())
        {
            foreach (Animator anim in doorAnimators)
            {
                anim.SetTrigger("Open");
            }

            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !doorClosed)
        {
            foreach (Animator anim in doorAnimators)
            {
                anim.SetTrigger("Close");
            }

            doorClosed = true;
        }
    }

    private bool AllEnemiesDefeated()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null) return false;
        }
        return true;
    }

}

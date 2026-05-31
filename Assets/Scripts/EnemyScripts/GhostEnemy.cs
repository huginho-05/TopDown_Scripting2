using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}

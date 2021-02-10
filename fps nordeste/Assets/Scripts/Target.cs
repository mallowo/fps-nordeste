using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float shield = 100f;

    private float xMin = 0f;
    private float xMax = 100f;
    
    public void TakeDamage (float damage)
    {
        if (shield >= 1f)
        {
            shield -= damage;
        }

        else
        {
            health -= damage;
        }
        
        shield = Mathf.Clamp(shield, xMin, xMax);

        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

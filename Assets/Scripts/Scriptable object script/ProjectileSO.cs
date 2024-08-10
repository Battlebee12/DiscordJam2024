using UnityEngine;

[CreateAssetMenu()]
public class ProjectileSO : ScriptableObject
{
    public GameObject prefab;  // The prefab of the projectile
    public float lifetime = 2f;  // How long the projectile lasts before being destroyed
    public float speed = 10f;  // The speed of the projectile
    public int damage = 10;  // The amount of damage the projectile does
}
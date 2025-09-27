using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public ParticleSystem water;
    public Transform growCastOrigin;
    
    [Header("Growth Casting")]
    public float castDistance = 5f;
    public float coneAngle = 30f;
    public int rayCount = 8;
    
    void Update()
    {
        bool upsideDown = Vector3.Dot(transform.up, Vector3.up) < 0f;
        if (upsideDown)
        {
            if (!water.isPlaying) water.Play();
            PerformGrowthCast();
        }
        else water.Stop();
    }
    
    void PerformGrowthCast()
    {
        Vector3 forward = -growCastOrigin.up; // Down direction when upside down
        
        for (int i = 0; i < rayCount; i++)
        {
            float angle = (360f / rayCount) * i;
            Vector3 direction = Quaternion.AngleAxis(angle, forward) * 
                               Quaternion.AngleAxis(coneAngle, growCastOrigin.right) * forward;
            
            if (Physics.Raycast(growCastOrigin.position, direction, out RaycastHit hit, castDistance))
            {
                hit.collider.gameObject.SendMessage("Grow", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrowableFlower : MonoBehaviour
{
    public int stages = 3;
    public int countsToNextStage = 7;

    private int currentStage = 1;
    private int currentCounts = 0;
    private Vector3 diff;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle collided bay bee");
        if (other.CompareTag("water")) Grow();
    }

    public void Grow()
    {
        if (currentCounts < countsToNextStage)
            currentCounts++;
        else if (currentStage < stages)
        {
            transform.localScale += diff;
            currentStage++;
            currentCounts = 0;
        }
    }


    private bool originalKinematic;
    private CollisionDetectionMode originalCollisionMode;


    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        originalKinematic = rb.isKinematic;
        originalCollisionMode = rb.collisionDetectionMode;

        transform.localScale /= stages;
        diff = transform.localScale;
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Entered socket");
    }
    
    void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Exited socket - restoring physics");
        
        // Force restore original rigidbody settings
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = originalKinematic;
        rb.collisionDetectionMode = originalCollisionMode;
        
        // Ensure colliders are enabled
        var boxCollider = GetComponent<BoxCollider>();
        if (boxCollider) boxCollider.enabled = true;
    }
}

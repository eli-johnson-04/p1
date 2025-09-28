using UnityEngine;

public class GrowableFlower : MonoBehaviour
{
    public int stages = 3;
    public int countsToNextStage = 7;

    private int currentStage = 1;
    private int currentCounts = 0;
    private Vector3 diff;
    
    void OnParticleCollision(GameObject other)
    {
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale /= stages;
        diff = transform.localScale;
    }
}

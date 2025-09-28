using UnityEngine;

public class GrowableFlower : MonoBehaviour
{
    public int stages = 3;
    public int countsToNextStage = 7;

    private int currentStage = 1;
    private int currentCounts = 0;
    private Vector3 diff;

    public AudioSource growSource;

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
            growSource.Play();
            currentCounts = 0;
        }
    }

    void Start()
    {
        transform.localScale /= stages;
        diff = transform.localScale;
    }
}

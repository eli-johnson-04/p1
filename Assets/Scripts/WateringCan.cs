using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public ParticleSystem water;
    
    void Update()
    {
        bool upsideDown = Vector3.Dot(transform.up, Vector3.up) < 0f;
        if (upsideDown)
        {
            if (!water.isPlaying) water.Play();
            // Debug.Log("hello vro im da watercan i am ready to water");
        }
        else water.Stop();
    }
}
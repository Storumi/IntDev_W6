using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrail : MonoBehaviour
{

    ParticleSystem myParticles;

    // Start is called before the first frame update
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        var emission = myParticles.emission;
        emission.enabled = false;
        //myParticles.Stop();
    }

    public void StartTrail(){
        var emission = myParticles.emission;
        emission.enabled = true;
    }

    public void StopTrail(){
        var emission = myParticles.emission;
        emission.enabled = false;
    }
}

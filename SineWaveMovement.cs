using UnityEngine;
using System.Collections;

public class SineWaveMovement : BaseMovement
{
    [SerializeField]
    private GameObject trail; // just for fun
    [SerializeField]
    private float frequency = 0.8f;
    [SerializeField]
    private float wavelength = 1.5f;

    protected override float GetY()
    {
        // try and mess with some of the values here to see what dif results you get...
        return Mathf.Sin(2 * Mathf.PI * Time.time * frequency) * wavelength;
    }

    protected override void Move()
    {
        base.Move();
        StartCoroutine(CreateTrail());
    }

    private IEnumerator CreateTrail()
    {
        if (trail != null)
        {
            var tObj = Instantiate(trail, cachedTransform.position, cachedTransform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(tObj);
        }
    }
}


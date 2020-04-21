using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Renderer cubeColour;
    public Renderer lightColour;
    private Lights mainScript;
    private GameObject lookFor;
    private Vector3 velocity;
    private float maxVelocity = 2f;
    private float maxForce = 1f;

    void Start()
    {
        cubeColour = GetComponent<MeshRenderer>();
        cubeColour.material.color = Color.magenta;
        mainScript = FindObjectOfType<Lights>();
        velocity = Vector3.zero;
        TargetChoose();
    }

    void Update() {
        if (lightColour.material.color != Color.green ||
            (Vector3.Distance(this.transform.position, lookFor.transform.position) <= 0.2))
        {
            TargetChoose();
        }
        MoveToTarget(); }

    void TargetChoose()
    {
        // lookFor = mainScript.prefab[Random.Range(0, mainScript.prefab.length)];
        lightColour = lookFor.GetComponent<Renderer>();
    }

    void MoveToTarget()
    {
        var desiredVelocity = lookFor.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVelocity;
        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        velocity = Vector3.ClampMagnitude(velocity + steering, maxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }
}

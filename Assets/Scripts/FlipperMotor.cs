using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class FlipperMotor : MonoBehaviour
{
    public float flipSpeed = 6000f;   // deg/s
    public float motorForce = 6000f;
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = true;
    }

    void FixedUpdate()
    {
        JointMotor m = hinge.motor;

        if (Input.GetKey(KeyCode.Space))
            m.targetVelocity =  -flipSpeed;   // up-stroke
        else
            m.targetVelocity = flipSpeed;   // return-stroke

        m.force = motorForce;
        hinge.motor = m;
    }
}

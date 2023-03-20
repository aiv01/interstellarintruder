using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadierStats : ScriptableObject
{
    public float visDist = 5.0f;
    public float nearDist = 2.0f;
    public float visAngle = 40.0f;
    public float rangeDist = 7.0f;
    public float meleeDist = 1.0f;
    public float speed;
    public float chaseSpeed;
    public float rotationSpeed = 2.0f;
}

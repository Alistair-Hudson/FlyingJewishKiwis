using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileFormulae
{
    private static float gravity = -Physics.gravity.y; //We are assuming gravity is always in the y direction

    public static float HorizontalVelocity(float initalVelocity, float angleRadians)
    {
        return initalVelocity * Mathf.Sin(angleRadians);
    }

    public static float VerticalVelocity(float initalVelocity, float angleRadians, float time)
    {
        return initalVelocity * Mathf.Cos(angleRadians) - gravity * time;
    }

    public static float TimeOfFlight(float initalVelocity, float angleRadians)
    {
        float time = 2 * VerticalVelocity(initalVelocity, angleRadians, 0);
        time = time / gravity;
        return time;
    }

    public static float TimeOfFlight(float verticalVelocity)
    {
        return 2 * verticalVelocity / gravity;
    }

    public static float HorizontalDisplacement(float initalVelocity, float angleRadians, float time)
    {
        return HorizontalVelocity(initalVelocity, angleRadians) * time;
    }

    public static float HorizontalDisplacement(float horizontalVelocity, float time)
    {
        return horizontalVelocity * time;
    }

    public static float VerticalDisplacement(float initalVelocity, float angleRadians, float time)
    {
        return VerticalVelocity(initalVelocity, angleRadians, 0) * time - 0.5f * gravity * time * time;
    }

    public static float VerticalDisplacement(float verticalVelocity, float time)
    {
        return verticalVelocity * time - 0.5f * gravity * time * time;
    }

    public static float MaxiumHeight(float initalVelocity, float angleRadians)
    {
        float height = initalVelocity * initalVelocity * Mathf.Sin(angleRadians) * Mathf.Sin(angleRadians);
        height = height / (2 * gravity);
        return height;
    }

    public static float Range(float initalVelocity, float angleRadians)
    {
        float range = initalVelocity * initalVelocity * Mathf.Sin(2 * angleRadians);
        range = range / gravity;
        return range;
    }
}

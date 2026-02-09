# Tower Defence Example

This is a playable example of a tower defence game.

This demonstrates:

* SpriteShapes in a top-down 2D context, including accessing the points along a spline from a script for gameplay (See `RoadPosition` and `FollowRoad`)
* ScriptableObjects for authoring data about gameplay (see `SpawnPattern`)
* Editor scripting for visualising and validating data in MonoBehaviours (See the `Editor` folder)

Units are spawned by a `SpawnPoint`. They travel between the points on the provided `SpriteShape` in straight lines. The `UnityEngine.U3D.Spline` class does not provide convenient methods for interpolating points along the Spline. If you wished to implement this, you could either implement the maths for Bezier curves yourself or you may be able to make use of the `UnityEngine.Splines` package ([API reference](https://docs.unity3d.com/Packages/com.unity.splines@2.4/api/UnityEngine.Splines.SplineContainer.html#UnityEngine_Splines_SplineContainer_Evaluate_System_Single_Unity_Mathematics_float3__Unity_Mathematics_float3__Unity_Mathematics_float3__)).
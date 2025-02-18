using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace HelloCube
{
    // An authoring component is just a normal MonoBehavior.
    public class RotationSpeedAuthoring : MonoBehaviour
    {
        public float DegreesPerSecond = 360.0f;

        // In baking, this Baker will run once for every RotationSpeedAuthoring instance in an entity subscene.
        // (Nesting an authoring component's Baker class is simply an optional matter of style.)
        class Baker : Baker<RotationSpeedAuthoring>
        {
            //override the baker function with this scripts authoring class (monobehavior)
            public override void Bake(RotationSpeedAuthoring authoring)
            {
                // The entity will be moved so you declare the flags for it
                var entity = GetEntity(TransformUsageFlags.Dynamic | TransformUsageFlags.NonUniformScale);
                
                //Declare the components of the Rotation speed entity you want to declare
                AddComponent(entity, new RotationSpeed
                {
                    RadiansPerSecond = math.radians(authoring.DegreesPerSecond)
                });
            }
        }
    }

    public struct RotationSpeed : IComponentData
    {
        public float RadiansPerSecond;
    }
}

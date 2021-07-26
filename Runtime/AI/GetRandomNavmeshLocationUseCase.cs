using UnityEngine;
using UnityEngine.AI;

namespace CleanCore.AI
{
    public class GetRandomNavmeshLocationUseCase
    {
        /// <summary>
        /// Retrun a random navmesh point
        /// </summary>
        /// <param name="_radius"></param>
        /// <returns></returns>
        public Vector3 RandomNavmeshLocation(float _radius, Transform transform)
        {
            Vector3 randomDirection = Random.insideUnitSphere * _radius;
            randomDirection += transform.position;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _radius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
    }
}
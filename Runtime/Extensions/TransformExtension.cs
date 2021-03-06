using UnityEngine;

namespace CleanCore.Extensions
{
    public static class TransformExtension
    {
        #region Move

        /// <summary>
        /// Move a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveTowards(this Transform transform, Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        /// <summary>
        /// Move a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveTowards(this Transform transform, Transform target, float speed)
        {
            MoveTowards(transform, target.position, speed);
        }

        /// <summary>
        /// Move with lerp a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveLerpTo(this Transform transform, Vector3 target, float speed)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }

        /// <summary>
        /// Move with lerp a transform to a target
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        public static void MoveLerpTo(this Transform transform, Transform target, float speed)
        {
            MoveLerpTo(transform, target.position, speed);
        }

        #endregion

        #region Utils

        /// <summary>
        /// Rotate the transform to the target direction
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="axis"></param>
        public static void LookAt(this Transform transform, Transform target, Vector3 axis)
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

            Quaternion LookAtRotationOnly_Y = Quaternion.Euler( 
                axis.x == 0 ? transform.rotation.eulerAngles.x : LookAtRotation.eulerAngles.x,
                axis.y == 0 ? transform.rotation.eulerAngles.y : LookAtRotation.eulerAngles.y,
                axis.z == 0 ? transform.rotation.eulerAngles.z : LookAtRotation.eulerAngles.z);

            transform.rotation = LookAtRotationOnly_Y;
        }

        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            return transform;
        }

        #endregion

        #region Distance Comparations

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimumDistance(this Transform transform, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(transform.position, otherVector) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherTransform"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimumDistance(this Transform transform, Transform otherTransform, float distance)
        {
            if (Vector3.Distance(transform.position, otherTransform.position) < distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherVector"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimumOrEqualDistance(this Transform transform, Vector3 otherVector, float distance)
        {
            if (Vector3.Distance(transform.position, otherVector) <= distance)
                return true;

            return false;
        }

        /// <summary>
        /// Return true if the distance between vectors is less than determined
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="otherTransform"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool MinimumOrEqualDistance(this Transform transform, Transform otherTransform, float distance)
        {
            if (Vector3.Distance(transform.position, otherTransform.position) <= distance)
                return true;

            return false;
        }

        #endregion
    }
}
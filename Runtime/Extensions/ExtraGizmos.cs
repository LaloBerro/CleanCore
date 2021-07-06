using UnityEngine;

namespace CleanCore.Extensions
{
    public static class ExtraGizmos
    {
        public static Color DefaultColor { get; set; }
        public static Matrix4x4 matrix => Gizmos.matrix;

        private static Color oldColor;

        static ExtraGizmos()
        {
            DefaultColor = Color.white;
        }

        private static void SwapColor(Color? c)
        {
            oldColor = Gizmos.color;
            Gizmos.color = c ?? DefaultColor;
        }

        private static void RestoreColor()
        {
            Gizmos.color = oldColor;
        }

        #region points and lines

        public static void DrawPoint(Vector3 position, Color? color = null, float scale = 1.0f)
        {
            SwapColor(color);
            Gizmos.DrawRay(position + Vector3.up * (scale * 0.5f), -Vector3.up * scale);
            Gizmos.DrawRay(position + Vector3.right * (scale * 0.5f), -Vector3.right * scale);
            Gizmos.DrawRay(position + Vector3.forward * (scale * 0.5f), -Vector3.forward * scale);
            RestoreColor();
        }

        public static void DrawLine(Vector3 from, Vector3 to, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawLine(from, to);
            RestoreColor();
        }

        public static void DrawRay(Ray r, Color? color)
        {
            SwapColor(color);
            Gizmos.DrawLine(r.origin, r.origin + r.direction);
            RestoreColor();
        }

        public static void DrawRay(Vector3 from, Vector3 direction, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawLine(from, from + direction);
            RestoreColor();
        }

        #endregion

        #region 3D shapes

        public static void DrawWireSphere(Vector3 center, float radius = 1, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawWireSphere(center, radius);
            RestoreColor();
        }

        public static void DrawSphere(Vector3 center, float radius = 1, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawSphere(center, radius);
            RestoreColor();
        }

        public static void DrawWireCube(Vector3 center, Vector3? size = null, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawWireCube(center, size ?? Vector3.one);
            RestoreColor();
        }

        public static void DrawCube(Vector3 center, Vector3? size = null, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawCube(center, size ?? Vector3.one);
            RestoreColor();
        }

        public static void DrawLocalCube(Transform transform, Vector3? size = null, Color? color = null, Vector3? center = null)
        {
            SwapColor(color);

            Vector3 c = center ?? Vector3.zero;
            Vector3 sizeV = size ?? Vector3.one;

            Vector3 lbb = transform.TransformPoint(c - sizeV * 0.5f);
            Vector3 rbb = transform.TransformPoint(c + new Vector3(sizeV.x, -sizeV.y, -sizeV.z) * 0.5f);

            Vector3 lbf = transform.TransformPoint(c + new Vector3(sizeV.x, -sizeV.y, sizeV.z) * 0.5f);
            Vector3 rbf = transform.TransformPoint(c + new Vector3(-sizeV.x, -sizeV.y, sizeV.z) * 0.5f);

            Vector3 lub = transform.TransformPoint(c + new Vector3(-sizeV.x, sizeV.y, -sizeV.z) * 0.5f);
            Vector3 rub = transform.TransformPoint(c + new Vector3(sizeV.x, sizeV.y, -sizeV.z) * 0.5f);

            Vector3 luf = transform.TransformPoint(c + sizeV * 0.5f);
            Vector3 ruf = transform.TransformPoint(c + new Vector3(-sizeV.x, sizeV.y, sizeV.z) * 0.5f);

            Gizmos.DrawLine(lbb, rbb);
            Gizmos.DrawLine(rbb, lbf);
            Gizmos.DrawLine(lbf, rbf);
            Gizmos.DrawLine(rbf, lbb);

            Gizmos.DrawLine(lub, rub);
            Gizmos.DrawLine(rub, luf);
            Gizmos.DrawLine(luf, ruf);
            Gizmos.DrawLine(ruf, lub);

            Gizmos.DrawLine(lbb, lub);
            Gizmos.DrawLine(rbb, rub);
            Gizmos.DrawLine(lbf, luf);
            Gizmos.DrawLine(rbf, ruf);

            Gizmos.color = oldColor;
        }

        public static void DrawLocalCube(Matrix4x4 space, Vector3? size = null, Color? color = null, Vector3? center = null)
        {
            SwapColor(color);

            Vector3 c = center ?? Vector3.zero;
            Vector3 sizeV = size ?? Vector3.one;

            Vector3 lbb = space.MultiplyPoint3x4(c - sizeV * 0.5f);
            Vector3 rbb = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, -sizeV.y, -sizeV.z) * 0.5f);

            Vector3 lbf = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, -sizeV.y, sizeV.z) * 0.5f);
            Vector3 rbf = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, -sizeV.y, sizeV.z) * 0.5f);

            Vector3 lub = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, sizeV.y, -sizeV.z) * 0.5f);
            Vector3 rub = space.MultiplyPoint3x4(c + new Vector3(sizeV.x, sizeV.y, -sizeV.z) * 0.5f);

            Vector3 luf = space.MultiplyPoint3x4(c + sizeV) * 0.5f;
            Vector3 ruf = space.MultiplyPoint3x4(c + new Vector3(-sizeV.x, sizeV.y, sizeV.z) * 0.5f);

            Gizmos.DrawLine(lbb, rbb);
            Gizmos.DrawLine(rbb, lbf);
            Gizmos.DrawLine(lbf, rbf);
            Gizmos.DrawLine(rbf, lbb);

            Gizmos.DrawLine(lub, rub);
            Gizmos.DrawLine(rub, luf);
            Gizmos.DrawLine(luf, ruf);
            Gizmos.DrawLine(ruf, lub);

            Gizmos.DrawLine(lbb, lub);
            Gizmos.DrawLine(rbb, rub);
            Gizmos.DrawLine(lbf, luf);
            Gizmos.DrawLine(rbf, ruf);

            RestoreColor();
        }

        public static void DrawFrustum(Vector3 center, float fov, float maxRange = 100, float minRange = 0.1f, float aspect = 16 / 9, Color? color = null)
        {
            SwapColor(color);
            Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect);
            RestoreColor();
        }

        public static void DrawBounds(Bounds bounds, Color? color = null)
        {
            SwapColor(color);

            Vector3 center = bounds.center;

            float x = bounds.extents.x;
            float y = bounds.extents.y;
            float z = bounds.extents.z;

            Vector3 ruf = center + new Vector3(x, y, z);

            Vector3 rub = center + new Vector3(x, y, -z);

            Vector3 luf = center + new Vector3(-x, y, z);

            Vector3 lub = center + new Vector3(-x, y, -z);

            Vector3 rdf = center + new Vector3(x, -y, z);

            Vector3 rdb = center + new Vector3(x, -y, -z);

            Vector3 lfd = center + new Vector3(-x, -y, z);

            Vector3 lbd = center + new Vector3(-x, -y, -z);

            Gizmos.DrawLine(ruf, luf);
            Gizmos.DrawLine(ruf, rub);
            Gizmos.DrawLine(luf, lub);
            Gizmos.DrawLine(rub, lub);

            Gizmos.DrawLine(ruf, rdf);
            Gizmos.DrawLine(rub, rdb);
            Gizmos.DrawLine(luf, lfd);
            Gizmos.DrawLine(lub, lbd);

            Gizmos.DrawLine(rdf, lfd);
            Gizmos.DrawLine(rdf, rdb);
            Gizmos.DrawLine(lfd, lbd);
            Gizmos.DrawLine(lbd, rdb);

            RestoreColor();
        }

        public static void DrawRectangle(Vector3 center, Vector3 size, Vector3 dir, Color? color)
        {
            SwapColor(color);

            Vector3 up = center + (dir * (size.y / 2f));
            Vector3 down = center - (dir * (size.y / 2f));

            Vector3 right = center + (dir.Orthonormal() * (size.x / 2f));
            Vector3 left = center - (dir.Orthonormal() * (size.x / 2f));

            float magnitudeA = (up - center).magnitude;
            float magnitudeB = (right - center).magnitude;

            float magnitudeX = Mathf.Sqrt(Mathf.Pow(2, magnitudeA) + Mathf.Pow(2, magnitudeB));

            Vector3 upRight = center + (up - right).normalized * magnitudeX;
            Vector3 upLeft = center + (up - left).normalized * magnitudeX;
            Vector3 downRight = center + (down - right).normalized * magnitudeX;
            Vector3 downLeft = center + (down - left).normalized * magnitudeX;

            Gizmos.DrawLine(up, down);
            Gizmos.DrawLine(right, left);

            Gizmos.DrawLine(upLeft, upRight);
            Gizmos.DrawLine(downRight, upRight);
            Gizmos.DrawLine(upLeft, downLeft);
            Gizmos.DrawLine(downLeft, downRight);
        }

        public static void DrawRectangleRotated(Bounds bounds, Quaternion rotation, Color? color = null)
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(bounds.center, rotation, Gizmos.matrix.lossyScale);
            Gizmos.matrix = rotationMatrix;

            SwapColor(color);

            Vector3 center = bounds.center;

            float x = bounds.extents.x;
            float y = bounds.extents.y;
            float z = bounds.extents.z;

            Vector3 ruf = new Vector3(x, y, z);

            Vector3 rub = new Vector3(x, y, -z);

            Vector3 luf = new Vector3(-x, y, z);

            Vector3 lub = new Vector3(-x, y, -z);

            Vector3 rdf = new Vector3(x, -y, z);

            Vector3 rdb = new Vector3(x, -y, -z);

            Vector3 lfd = new Vector3(-x, -y, z);

            Vector3 lbd = new Vector3(-x, -y, -z);

            Gizmos.DrawLine(ruf, luf);
            Gizmos.DrawLine(ruf, rub);
            Gizmos.DrawLine(luf, lub);
            Gizmos.DrawLine(rub, lub);

            Gizmos.DrawLine(ruf, rdf);
            Gizmos.DrawLine(rub, rdb);
            Gizmos.DrawLine(luf, lfd);
            Gizmos.DrawLine(lub, lbd);

            Gizmos.DrawLine(rdf, lfd);
            Gizmos.DrawLine(rdf, rdb);
            Gizmos.DrawLine(lfd, lbd);
            Gizmos.DrawLine(lbd, rdb);

            RestoreColor();
        }

        public static void DrawCylinder(Vector3 start, Vector3? end = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 endPoint = end ?? (start + Vector3.up);
            Vector3 up = (endPoint - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

            //Radial circles
            DrawCircle(start, up, radius, color);
            DrawCircle(endPoint, -up, radius, color);
            DrawCircle((start + endPoint) * 0.5f, up, radius, color);

            //Side lines
            Gizmos.DrawLine(start + right, endPoint + right);
            Gizmos.DrawLine(start - right, endPoint - right);

            Gizmos.DrawLine(start + forward, endPoint + forward);
            Gizmos.DrawLine(start - forward, endPoint - forward);

            //Start endcap
            Gizmos.DrawLine(start - right, start + right);
            Gizmos.DrawLine(start - forward, start + forward);

            //End endcap
            Gizmos.DrawLine(endPoint - right, endPoint + right);
            Gizmos.DrawLine(endPoint - forward, endPoint + forward);

            RestoreColor();
        }

        public static void DrawCone(Vector3 position, Vector3? direction = null, float angle = 45, Color? color = null)
        {
            SwapColor(color);

            Vector3 dir = direction ?? Vector3.up;
            float length = dir.magnitude;

            Vector3 _forward = dir;
            Vector3 _up = Vector3.Slerp(_forward, -_forward, 0.5f);
            Vector3 _right = Vector3.Cross(_forward, _up).normalized * length;

            dir = dir.normalized;

            Vector3 slerpedVector = Vector3.Slerp(_forward, _up, angle / 90.0f);

            float dist;
            Plane farPlane = new Plane(-dir, position + _forward);
            Ray distRay = new Ray(position, slerpedVector);

            farPlane.Raycast(distRay, out dist);

            Gizmos.DrawRay(position, slerpedVector.normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, -_up, angle / 90.0f).normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, _right, angle / 90.0f).normalized * dist);
            Gizmos.DrawRay(position, Vector3.Slerp(_forward, -_right, angle / 90.0f).normalized * dist);

            DrawCircle(position + _forward, dir, (_forward - (slerpedVector.normalized * dist)).magnitude, color);
            DrawCircle(position + (_forward * 0.5f), dir, ((_forward * 0.5f) - (slerpedVector.normalized * (dist * 0.5f))).magnitude, color);

            RestoreColor();
        }

        public static void DrawCapsule(Vector3 start, Vector3? end = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 endPoint = end ?? (start + Vector3.up);

            Vector3 up = (endPoint - start).normalized * radius;
            Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
            Vector3 right = Vector3.Cross(up, forward).normalized * radius;

            float height = (start - endPoint).magnitude;
            float sideLength = Mathf.Max(0, (height * 0.5f) - radius);
            Vector3 middle = (endPoint + start) * 0.5f;

            start = middle + ((start - middle).normalized * sideLength);
            endPoint = middle + ((endPoint - middle).normalized * sideLength);

            //Radial circles
            DrawCircle(start, up, radius, color);
            DrawCircle(endPoint, -up, radius, color);


            //Side lines
            Gizmos.DrawLine(start + right, endPoint + right);
            Gizmos.DrawLine(start - right, endPoint - right);

            Gizmos.DrawLine(start + forward, endPoint + forward);
            Gizmos.DrawLine(start - forward, endPoint - forward);

            for (int i = 1; i < 26; i++)
            {

                //Start endcap
                Gizmos.DrawLine(Vector3.Slerp(right, -up, i / 25.0f) + start, Vector3.Slerp(right, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(-right, -up, i / 25.0f) + start, Vector3.Slerp(-right, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(forward, -up, i / 25.0f) + start, Vector3.Slerp(forward, -up, (i - 1) / 25.0f) + start);
                Gizmos.DrawLine(Vector3.Slerp(-forward, -up, i / 25.0f) + start, Vector3.Slerp(-forward, -up, (i - 1) / 25.0f) + start);

                //End endcap
                Gizmos.DrawLine(Vector3.Slerp(right, up, i / 25.0f) + endPoint, Vector3.Slerp(right, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(-right, up, i / 25.0f) + endPoint, Vector3.Slerp(-right, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(forward, up, i / 25.0f) + endPoint, Vector3.Slerp(forward, up, (i - 1) / 25.0f) + endPoint);
                Gizmos.DrawLine(Vector3.Slerp(-forward, up, i / 25.0f) + endPoint, Vector3.Slerp(-forward, up, (i - 1) / 25.0f) + endPoint);
            }

            RestoreColor();
        }

        public static void Draw3DArrow(Vector3 position, Vector3 direction, float? coneSize = 0.333f, Color? color = null)
        {
            SwapColor(color);

            Gizmos.DrawRay(position, direction);
            DrawCone(position + direction, -direction * coneSize, 15, color);

            RestoreColor();
        }

        public static void DrawStrokeBox(Vector3 center, Vector3 size, Color color)
        {
            Color backgroundColor = color;

            Gizmos.color = backgroundColor;
            Gizmos.DrawWireCube(center, size);

            backgroundColor.a = 0.2f;

            Gizmos.color = backgroundColor;
            Gizmos.DrawCube(center, size);

            RestoreColor();
        }

        #endregion

        #region meshes

        public static void DrawMesh(Mesh mesh, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawMesh(mesh, position, r, s);
            RestoreColor();
        }

        public static void DrawMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawMesh(mesh, submeshIndex, position, r, s);
            RestoreColor();
        }

        public static void DrawWireMesh(Mesh mesh, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawWireMesh(mesh, position, r, s);
            RestoreColor();
        }

        public static void DrawWireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            SwapColor(color);
            Quaternion r = rotation ?? Quaternion.identity;
            Vector3 s = scale ?? Vector3.one;
            Gizmos.DrawWireMesh(mesh, submeshIndex, position, r, s);
            RestoreColor();
        }

        #endregion

        #region 2D shapes

        public static void DrawCircle(Vector3 position, Vector3? up = null, float radius = 1.0f, Color? color = null)
        {
            SwapColor(color);

            Vector3 upVector = (!up.HasValue || up.Value == Vector3.zero ? Vector3.up : up.Value).normalized * radius;

            Vector3 forward = Vector3.Slerp(upVector, -upVector, 0.5f);
            Vector3 right = Vector3.Cross(upVector, forward).normalized * radius;

            Matrix4x4 matrix = new Matrix4x4
            {
                [0] = right.x,
                [1] = right.y,
                [2] = right.z,
                [4] = upVector.x,
                [5] = upVector.y,
                [6] = upVector.z,
                [8] = forward.x,
                [9] = forward.y,
                [10] = forward.z
            };

            Vector3 lastPoint = position + matrix.MultiplyPoint3x4(new Vector3(Mathf.Cos(0), 0, Mathf.Sin(0)));
            Vector3 nextPoint = Vector3.zero;

            for (int i = 0; i < 91; i++)
            {
                nextPoint.x = Mathf.Cos((i * 4) * Mathf.Deg2Rad);
                nextPoint.z = Mathf.Sin((i * 4) * Mathf.Deg2Rad);
                nextPoint.y = 0;

                nextPoint = position + matrix.MultiplyPoint3x4(nextPoint);

                Gizmos.DrawLine(lastPoint, nextPoint);
                lastPoint = nextPoint;
            }

            RestoreColor();
        }

        public static void DrawPlanarArrow(Vector3 pos, Vector3 direction, float arrowheadLength = 0.25f, float angle = 20.0f, Color? color = null)
        {
            SwapColor(color);

            Gizmos.DrawRay(pos, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + angle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - angle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(pos + direction, right * arrowheadLength);
            Gizmos.DrawRay(pos + direction, left * arrowheadLength);

            RestoreColor();
        }

        #endregion

        #region misc

        public static void DrawIcon(Vector3 center, string name, bool allowScaling = true)
        {
            Gizmos.DrawIcon(center, name, allowScaling);
        }

        public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder = 0, int rightBorder = 0, int topBorder = 0, int bottomBorder = 0, Material mat = null)
        {
            Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat);
        }
        #endregion
    }
}
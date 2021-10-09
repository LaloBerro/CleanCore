using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace CleanCore.EditorExtensions.CustomTools
{
	public class UpdateThisPackageTool : Editor
	{
        private static AddRequest Request;

        [MenuItem("Custom Editor/Update Clean Core package",priority = 0)]
        public static void Add()
        {
            Debug.Log("Updating Clean Core");
            Request = Client.Add("https://github.com/LaloBerro/CleanCore.git");
            EditorApplication.update += Progress;
        }

        private static void Progress()
        {
            if (Request.IsCompleted)
            {
                if (Request.Status == StatusCode.Success)
                    Debug.Log("Updated: " + Request.Result.name + " to version: " + Request.Result.version);
                else if (Request.Status >= StatusCode.Failure)
                    Debug.Log(Request.Error.message);

                EditorApplication.update -= Progress;
            }
        }
    }
}
using UnityEngine;

namespace CleanCore.Scenes
{
	[CreateAssetMenu(fileName = "SceneData", menuName = "SceneData")]
	public class SceneDataSO : ScriptableObject
	{
		[SerializeField] private SceneData sceneData;

		public SceneData SceneData {get => sceneData;}
	}
}
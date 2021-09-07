using UnityEngine;

namespace CleanCore.Scenes
{
	[CreateAssetMenu(fileName = "SceneData", menuName = "Scenes/SceneData")]
	public class SceneDataSO : ScriptableObject
	{
		[Header("Reference")]
		[SerializeField] private SceneData sceneData;

		public SceneData SceneData {get => sceneData;}
	}
}
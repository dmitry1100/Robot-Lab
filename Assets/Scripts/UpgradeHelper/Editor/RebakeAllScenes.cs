using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

namespace UpgradeHelper
{
	public static class RebakeAllScenes
	{
		[MenuItem("Upgrade helper/Bake All Scenes")]
		public static void Bake()
		{
			List<string> sceneNames = SearchFiles(Application.dataPath, "*.unity");
			foreach (string f in sceneNames)
			{
				var scene = EditorSceneManager.OpenScene(f);

				// Rebake navmesh data
				UnityEditor.AI.NavMeshBuilder.BuildNavMesh();

				EditorSceneManager.SaveScene( scene );
			}
		}

		static List<string> SearchFiles(string dir, string pattern)
		{
			List<string> sceneNames = new List<string>();
			foreach (string f in Directory.GetFiles(dir, pattern, SearchOption.AllDirectories))
			{
				sceneNames.Add(f);
			}
			return sceneNames;
		}
	}
}

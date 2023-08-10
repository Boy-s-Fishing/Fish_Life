using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaltwaterFish {

	public class ShoalManager : MonoBehaviour
	{

		public Terrain terrain;
		public GameObject fishPrefab;
		public Vector3 goal1;
		public Vector3 goal2;
		public Vector3 goalActual;
		public int waterLevel;
		public float surfaceOffset = 0.1f;
		public Vector3 spawnLimits = new Vector3(1, 1, 1);
		public Vector3 swimLimits = new Vector3(5, 5, 5);
		public int numFish = 1;
		public Shoal[] allFish;
		[Header("Fish Settings")]
		[Range(0.0f, 5.0f)]
		public float minSpeed = 0.1f;
		[Range(0.0f, 5.0f)]
		public float maxSpeed = 0.2f;
		public static float terrainY;
		public float terrainHeight;
		float spawnTerrainHeight;
		public bool restrictToSurface = false;
		//public GameObject goalSphere;

		void Start()
		{

			terrainY = terrain.transform.position.y;
			goal1 = this.transform.position;
			allFish = new Shoal[numFish];
			for (int i = 0; i < numFish; i++)
			{
				Vector3 pos = this.transform.position + new Vector3(Random.Range(-spawnLimits.x, spawnLimits.x), 0, Random.Range(-spawnLimits.z, spawnLimits.z));
				spawnTerrainHeight = Terrain.activeTerrain.SampleHeight(pos) + terrainY;
				pos.y = Random.Range(spawnTerrainHeight, (waterLevel - surfaceOffset));
				if (pos.y < (spawnTerrainHeight))
				{
					//Debug.Log("too low");
					pos.y = spawnTerrainHeight + 0.2f;

				}
				if (pos.y > waterLevel - 0.2f)
				{
					pos.y = waterLevel - 0.2f;
					//Debug.Log("too high");
				}
				//Debug.Log(pos + "Terrain-" + terrainHeight);
				var Fish = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
				allFish[i] = Fish.GetComponent<Shoal>();
				//allFish[i] = (GameObject) Instantiate (fishPrefab,pos,Quaternion.identity);
				//allFish[i].GetComponent<Shoal>().manager = this;
				allFish[i].manager = this;
			}
		}
		void Update()
		{
			//goalSphere.transform.position = goal1;
		}

		public void NewGoal()
		{
			goal1 = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), 0, Random.Range(-swimLimits.z, swimLimits.z));
			terrainHeight = Terrain.activeTerrain.SampleHeight(goal1) + terrainY;
			goal1.y = Random.Range(terrainHeight, (waterLevel - surfaceOffset));
			
			if (goal1.y > waterLevel)
			{
				goal1.y = waterLevel - surfaceOffset;
			}
			if (goal1.y < terrainHeight)
			{
				goal1.y = terrainHeight + 0.2f;
			}
			if(restrictToSurface)
			{
				goal1.y = waterLevel - surfaceOffset;
			}
			for (int i = 0; i < allFish.Length; i++)
			{
				allFish[i].SetGoal(goal1);
			}
			
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaltwaterFish {

	public class Shoal : MonoBehaviour
	{

		public float speed;
		public ShoalManager manager;
		public float rotSpeed = 1f;
		private int water;
		private Vector3 goalPosition;
		public bool hitting = false;
		Vector3 fishTransform;
		float fishTerrainHeight;
		float fishHeightAboveTerrain;
		float terrainy;
		float goalDistance;
		public float size = 1f;
		bool goalSet = false;
		float rayCastOffset = 0.1f;
		float timer = 0f;
		//public GameObject goalSphere;

		void Start()
		{
			water = manager.waterLevel;
			speed = Random.Range(manager.minSpeed, manager.maxSpeed);
			goalPosition = manager.transform.position;
			if (manager.restrictToSurface)
			{
				goalPosition.y = manager.waterLevel - manager.surfaceOffset;
			}
		}

		void Update()
		{
			//goalSphere.transform.position = goalPosition;
			timer += Time.deltaTime;

			if (goalSet == false)
			{
				manager.NewGoal();
				goalSet = true;
			}
			
			terrainy = manager.terrain.transform.position.y;
			fishTerrainHeight = Terrain.activeTerrain.SampleHeight(this.transform.position) + terrainy;
			fishHeightAboveTerrain = this.transform.position.y - fishTerrainHeight;
			
			Shoal[] gos;
			gos = manager.allFish;
			Vector3 vavoid = Vector3.zero;
			float nDistance;

			goalDistance = Vector3.Distance(this.transform.position, goalPosition);
			if (goalDistance < 0.3f || (manager.terrainHeight > (manager.waterLevel - manager.surfaceOffset)) || timer > 10f)
			{
				manager.NewGoal();
				timer = 0f;
			}

            foreach (Shoal go in gos)
            {
                if (go.gameObject != this.gameObject)
                {
                    nDistance = Vector3.Distance(go.transform.position, this.transform.position);

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                }
            }

            fishTransform = this.transform.position + new Vector3(0,-rayCastOffset,0);
			//fishTransform.y -= 0.1f;

			//Vector3 direction = manager.goalActual + vavoid- this.transform.position;
			if (manager.restrictToSurface)
			{
				goalPosition.y = manager.waterLevel - manager.surfaceOffset;
			}
			Vector3 direction = goalPosition + vavoid - this.transform.position;
			RaycastHit hit;

			Vector3 forward = transform.TransformDirection(Vector3.forward);
			Vector3 left = transform.TransformDirection(Vector3.left);
			Vector3 right = transform.TransformDirection(Vector3.right); 
            
            Debug.DrawRay(fishTransform, forward * size, Color.red);
            Debug.DrawRay(fishTransform, left * (size/2), Color.green);
			Debug.DrawRay(fishTransform, right * (size/2), Color.blue);
			
			if (Physics.Raycast(fishTransform, forward, out hit, size) || (Physics.Raycast(fishTransform, right, out hit, size/2)) || (Physics.Raycast(fishTransform, left, out hit, size/2)))
				hitting = true;
			else
				hitting = false;

			if (Physics.Raycast(transform.position, forward, out hit, size))
			{
				goalPosition = this.transform.position - this.transform.forward * 2;
			}

			if (Physics.Raycast(fishTransform, right, out hit, size / 4))
			{
				goalPosition = this.transform.position - this.transform.right * -2;
				Debug.Log("Hit right");
			}

			if (Physics.Raycast(fishTransform, left, out hit, size / 4))
			{
				goalPosition = this.transform.position - this.transform.right * 2;
				Debug.Log("Hit left");
			}


			if (fishHeightAboveTerrain < 0.2f)
			{
				//Debug.Log("Hit bottom");
				transform.Translate(Vector3.up * 0.3f * Time.deltaTime);
			}

			if (transform.position.y > (water - manager.surfaceOffset))
			{
				transform.Translate(Vector3.down * 0.3f * Time.deltaTime);
			}

			if (Random.Range(0, 1000) < 10)
			{
				speed = Random.Range(manager.minSpeed, manager.maxSpeed);
			}
				transform.Translate(0, 0, Time.deltaTime * speed);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
				Debug.Log("Moving forward");
			
			if (transform.position.y > goalPosition.y)
			{
				//Debug.Log("moving down");
				transform.Translate(Vector3.down * 0.1f * Time.deltaTime);
			}
		}

		public void SetGoal(Vector3 position)
		{
			goalPosition = position;
		}
	}	
}

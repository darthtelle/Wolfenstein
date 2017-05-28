using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public enum ParentType
	{
		Player,
		Walls,
		Doors,
		Treasure,
	};

#if UNITY_EDITOR

	public void GenerateLevel(Texture2D levelTexture, PrefabDataList prefabList)
	{
		Color32[] pixels = levelTexture.GetPixels32();

		int width = levelTexture.width;
		int height = levelTexture.height;

		for(int yIndex = 0; yIndex < height; yIndex++)
		{
			for(int xIndex = 0; xIndex < width; xIndex++)
			{
				int index = xIndex + (yIndex * width);

				Vector3 position = new Vector3(xIndex - (width * 0.5f), 0.0f, yIndex - (height * 0.5f));
				SpawnObjectEditor(pixels[index], position, prefabList);
			}
		}

		SetupLevel();
	}

	public void ResetLevel()
	{
		for(int childIndex = gameObject.transform.childCount - 1; childIndex >= 0; --childIndex)
		{
			bool generatedObject = false;

			for(int typeIndex = 0; typeIndex < System.Enum.GetNames(typeof(ParentType)).Length; typeIndex++)
			{
				if(string.Equals(gameObject.transform.GetChild(childIndex).name, ((ParentType)typeIndex).ToString()))
				{
					generatedObject = true;
					break;
				}
			}

			if(generatedObject == false)
			{
				continue;
			}

			GameObject levelObject = gameObject.transform.GetChild(childIndex).gameObject;

			for(int innerIndex = levelObject.transform.childCount - 1; innerIndex >= 0; --innerIndex)
			{
				DestroyImmediate(levelObject.transform.GetChild(innerIndex).gameObject);
			}

			DestroyImmediate(levelObject);
		}
	}

	private GameObject SpawnObjectEditor(Color32 colour, Vector3 position, PrefabDataList m_PrefabList)
	{
		if(colour.a <= 0)
		{
			return null;
		}

		for(int prefabIndex = 0; prefabIndex < m_PrefabList.GetDataList.Length; prefabIndex++)
		{
			if(m_PrefabList.GetDataList[prefabIndex].m_Colour.Equals(colour))
			{
				// Find the parent object to attach the prefab to.
				Transform parentObject = gameObject.transform.Find(m_PrefabList.GetDataList[prefabIndex].m_Parent.ToString());
				if(parentObject == null)
				{
					// If the parent can't be found, create one.
					parentObject = new GameObject(m_PrefabList.GetDataList[prefabIndex].m_Parent.ToString()).transform;
					parentObject.SetParent(gameObject.transform);
				}

				// Instantiate the prefab at the position.
				GameObject prefabObject = (GameObject)Instantiate(m_PrefabList.GetDataList[prefabIndex].m_Prefab, position, Quaternion.identity, parentObject);
				return prefabObject;
			}
		}

		return null;
	}

	private void SetupLevel()
	{
		GameObject doorObject = gameObject.transform.Find(ParentType.Doors.ToString()).gameObject;

		for(int doorIndex = 0; doorIndex < doorObject.transform.childCount; doorIndex++)
		{
			RaycastHit hit;
			if((Physics.Raycast(doorObject.transform.GetChild(doorIndex).position, Vector3.left, out hit, 1.0f)) && (hit.collider.gameObject.CompareTag("Wall")))
			{
				Debug.Log("There is a wall on my left.");
			}
			else if((Physics.Raycast(doorObject.transform.GetChild(doorIndex).position, Vector3.forward, out hit, 1.0f)) && (hit.collider.gameObject.CompareTag("Wall")))
			{
				Debug.Log("There is a wall on my forward.");

				doorObject.transform.GetChild(doorIndex).Rotate(Vector3.up, 90.0f);
			}
		}
	}

#endif
}
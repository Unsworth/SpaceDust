using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockFormation
{
	public Vector2[] positions;
}

public enum ObjectType
{
	HardRock,
	BreakableRock,
	Dust,
	EnemySimple,
	EnemyDirectShot,
	EnemyLaneJumper,
	EnemyMultiShot,
}

public class ObjectFormation
{
	public ObjectType[] objectType;
	public Vector2[] positions;
	public float spawnTime;

}

//example rock formation, rock at (0,0), (0,1), (0,3), (0,4), (2,1), (2,2), (2,3)
//	[x][ ][ ]
//  [x][ ][x]
//  [x][ ][x]
//  [x][ ][x]
//  [ ][ ][x]

public class ObjectSpawner : MonoBehaviour
{

	float spawnTime;
	List<RockFormation> rockFormations;
	List<ObjectFormation> objectFormations;
	List<GameObject> objects;
	public GameObject hardRock;
	public GameObject dust;
	public GameObject breakableRock;
	public GameObject enemySimple;
	public GameObject enemyDirectShot;
	public GameObject enemyLaneJumper;
	public GameObject enemyMultiShot;
	int formationNumber = 0;
	int formationSize = 0;
	int formationCount = 0;
	// Use this for initialization
	void Start ()
	{

		spawnTime = Time.time + 3.0f;
		rockFormations = new List<RockFormation> ();
		objectFormations = new List<ObjectFormation> ();
		objects = new List<GameObject> ();
		objects.Add (hardRock);
		objects.Add (breakableRock);
		objects.Add (dust);
		objects.Add (enemySimple);
		objects.Add (enemyDirectShot);
		objects.Add (enemyLaneJumper);
		objects.Add (enemyMultiShot);



		string xmlText = System.IO.File.ReadAllText (Application.dataPath + "/UnitFormations.xml");
		TinyXmlReader reader = new TinyXmlReader (xmlText);
		while (reader.Read()) {
			if (reader.isOpeningTag) {
				if(reader.tagName == "formation" && reader.isOpeningTag)
				{
					ObjectFormation formation01 = new ObjectFormation ();
					while(reader.Read ("formation"))
					{
						if(reader.isOpeningTag)
						{
							if(reader.tagName == "size" && reader.isOpeningTag)
							{
								formationSize = int.Parse(reader.content);
								formation01.positions = new Vector2 [formationSize];
								formation01.objectType = new ObjectType[formationSize];

							}
							if(reader.tagName == "spawnTime" && reader.isOpeningTag)
							{
								formation01.spawnTime = float.Parse (reader.content);
							}

							if(reader.tagName == "object" && reader.isOpeningTag)
							{
								formation01.positions [formationCount] = Vector2.zero;

								while(reader.Read ("object"))
								{
									if(reader.isOpeningTag)
									{
										if(reader.tagName == "type" && reader.isOpeningTag)
										{
											switch(reader.content)
											{
												case "HardRock":
												{
													formation01.objectType[formationCount] = ObjectType.HardRock;
													break;
												}
												case "BreakableRock":
												{
													formation01.objectType[formationCount] = ObjectType.BreakableRock;
													break;
												}
												case "Dust":
												{
													formation01.objectType[formationCount] = ObjectType.Dust;
													break;
												}
												case "EnemySimple":
												{
													formation01.objectType[formationCount] = ObjectType.EnemySimple;
													break;
												}
												case "EnemyDirectShot":
												{
													formation01.objectType[formationCount] = ObjectType.EnemyDirectShot;
													break;
												}
												case "EnemyLaneJumper":
												{
													formation01.objectType[formationCount] = ObjectType.EnemyLaneJumper;
													break;
												}
												case "EnemyMultiShot":
												{
													formation01.objectType[formationCount] = ObjectType.EnemyMultiShot;
													break;
												}
												default :
												{
													//Breakable object in case we mess up
													formation01.objectType[formationCount] = ObjectType.BreakableRock;
													break;
												}
											}
										}
										if(reader.tagName == "x" && reader.isOpeningTag)
										{
											formation01.positions[formationCount].x = int.Parse(reader.content);
										}
										if(reader.tagName == "y" && reader.isOpeningTag)
										{
											formation01.positions[formationCount].y = int.Parse(reader.content);
											formationCount++;
										}
									}
								}
								formationCount = 0;
								objectFormations.Add (formation01);
							}
						}
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{

		float random = Random.Range (-2, 2);
		random *= 2;

		if (Time.time > spawnTime) {

			for (int j = 0; j < objectFormations[formationNumber].positions.Length; j++) {
				GameObject clone = Instantiate (objects [(int)objectFormations [formationNumber].objectType [j]], new Vector3 (12 + objectFormations [formationNumber].positions [j].x, objectFormations [formationNumber].positions [j].y, 0), Quaternion.identity) as GameObject;
				clone.rigidbody2D.velocity = new Vector2 (-6, 0);
			}

		
			spawnTime = Time.time + objectFormations[formationNumber].spawnTime;
			formationNumber++;
			formationNumber %= objectFormations.Count;
		}

	}
}

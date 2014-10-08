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
}

public class ObjectFormation
{
	public ObjectType[] objectType;
	public Vector2[] positions;

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
							if(reader.tagName == "object" && reader.isOpeningTag)
							{
								formation01.positions [formationCount] = Vector2.zero;

								while(reader.Read ("object"))
								{
									if(reader.isOpeningTag)
									{
										if(reader.tagName == "type" && reader.isOpeningTag)
										{
											if(reader.content == "HardRock")
											{
												formation01.objectType[formationCount] = ObjectType.HardRock;
											}
											if (reader.content == "BreakableRock")
											{
												formation01.objectType[formationCount] = ObjectType.BreakableRock;
											}
											if (reader.content == "Dust")
											{
												formation01.objectType[formationCount] = ObjectType.Dust;
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
			/*
			spawnTime = Time.time + 3.0f;
			rockFormations = new List<RockFormation> ();
			objectFormations = new List<ObjectFormation> ();
			objects = new List<GameObject> ();
			objects.Add (hardRock);
			objects.Add (breakableRock);
			objects.Add (dust);

			ObjectFormation formation01 = new ObjectFormation ();
			formation01.positions = new Vector2 [8];
			formation01.objectType = new ObjectType[8];
			formation01.positions [0] = new Vector2 (0, 4);
			formation01.objectType [0] = ObjectType.HardRock;
			formation01.positions [1] = new Vector2 (0, 2);
			formation01.objectType [1] = ObjectType.HardRock;
			formation01.positions [2] = new Vector2 (0, -2);
			formation01.objectType [2] = ObjectType.HardRock;
			formation01.positions [3] = new Vector2 (0, -4);
			formation01.objectType [3] = ObjectType.HardRock;
			formation01.positions [4] = new Vector2 (6, 2);
			formation01.objectType [4] = ObjectType.HardRock;
			formation01.positions [5] = new Vector2 (6, 0);
			formation01.objectType [5] = ObjectType.BreakableRock;
			formation01.positions [6] = new Vector2 (6, -2);
			formation01.objectType [6] = ObjectType.BreakableRock;
			formation01.positions [7] = new Vector2 (3, 0);
			formation01.objectType [7] = ObjectType.Dust;
			objectFormations.Add (formation01);
	
			ObjectFormation formation02 = new ObjectFormation ();
			formation02.positions = new Vector2 [8];
			formation02.objectType = new ObjectType[8];
			formation02.positions [0] = new Vector2 (0, 4);
			formation02.objectType [0] = ObjectType.HardRock;
			formation02.positions [1] = new Vector2 (0, 2);
			formation02.objectType [1] = ObjectType.HardRock;
			formation02.positions [2] = new Vector2 (0, 0);
			formation02.objectType [2] = ObjectType.HardRock;
			formation02.positions [3] = new Vector2 (0, -2);
			formation02.objectType [3] = ObjectType.HardRock;
			formation02.positions [4] = new Vector2 (6, 4);
			formation02.objectType [4] = ObjectType.HardRock;
			formation02.positions [5] = new Vector2 (6, 0);
			formation02.objectType [5] = ObjectType.HardRock;
			formation02.positions [6] = new Vector2 (6, -2);
			formation02.objectType [6] = ObjectType.HardRock;
			formation02.positions [7] = new Vector2 (6, 2);
			formation02.objectType [7] = ObjectType.Dust;
			objectFormations.Add (formation02);

			ObjectFormation formation03 = new ObjectFormation ();
			formation03.positions = new Vector2 [8];
			formation03.objectType = new ObjectType[8];
			formation03.positions [0] = new Vector2 (0, -4);
			formation03.objectType [0] = ObjectType.HardRock;
			formation03.positions [1] = new Vector2 (0, 2);
			formation03.objectType [1] = ObjectType.HardRock;
			formation03.positions [2] = new Vector2 (0, 0);
			formation03.objectType [2] = ObjectType.HardRock;
			formation03.positions [3] = new Vector2 (0, -2);
			formation03.objectType [3] = ObjectType.HardRock;
			formation03.positions [4] = new Vector2 (6, 4);
			formation03.objectType [4] = ObjectType.HardRock;
			formation03.positions [5] = new Vector2 (6, 2);
			formation03.objectType [5] = ObjectType.HardRock;
			formation03.positions [6] = new Vector2 (6, 0);
			formation03.objectType [6] = ObjectType.HardRock;
			formation03.positions [7] = new Vector2 (6, -2);
			formation03.objectType [7] = ObjectType.Dust;
			objectFormations.Add (formation03);

			ObjectFormation formation04 = new ObjectFormation ();
			formation04.positions = new Vector2 [15];
			formation04.objectType = new ObjectType[15];
			formation04.positions [0] = new Vector2 (0, -4);
			formation04.objectType [0] = ObjectType.HardRock;
			formation04.positions [1] = new Vector2 (2, -4);
			formation04.objectType [1] = ObjectType.HardRock;
			formation04.positions [2] = new Vector2 (4, -2);
			formation04.objectType [2] = ObjectType.HardRock;
			formation04.positions [3] = new Vector2 (6, -2);
			formation04.objectType [3] = ObjectType.HardRock;
			formation04.positions [4] = new Vector2 (0, 0);
			formation04.objectType [4] = ObjectType.HardRock;
			formation04.positions [5] = new Vector2 (2, 2);
			formation04.objectType [5] = ObjectType.HardRock;
			formation04.positions [6] = new Vector2 (4, 2);
			formation04.objectType [6] = ObjectType.HardRock;
			formation04.positions [7] = new Vector2 (6, 4);
			formation04.objectType [7] = ObjectType.HardRock;
			formation04.positions [8] = new Vector2 (6, -2);
			formation04.objectType [8] = ObjectType.HardRock;
			formation04.positions [9] = new Vector2 (8, 0);
			formation04.objectType [9] = ObjectType.HardRock;
			formation04.positions [10] = new Vector2 (8, 4);
			formation04.objectType [10] = ObjectType.HardRock;
			formation04.positions [11] = new Vector2 (10, 0);
			formation04.objectType [11] = ObjectType.HardRock;
			formation04.positions [12] = new Vector2 (10, 4);
			formation04.objectType [12] = ObjectType.HardRock;
			formation04.positions [13] = new Vector2 (12, 0);
			formation04.objectType [13] = ObjectType.Dust;	
			formation04.positions [14] = new Vector2 (14, 0);
			formation04.objectType [14] = ObjectType.Dust;	
			objectFormations.Add (formation04);

			ObjectFormation formation05 = new ObjectFormation ();
			formation05.positions = new Vector2 [14];
			formation05.objectType = new ObjectType[14];
			formation05.positions [0] = new Vector2 (10, -4);
			formation05.objectType [0] = ObjectType.HardRock;
			formation05.positions [1] = new Vector2 (8, -4);
			formation05.objectType [1] = ObjectType.HardRock;
			formation05.positions [2] = new Vector2 (6, -2);
			formation05.objectType [2] = ObjectType.HardRock;
			formation05.positions [3] = new Vector2 (4, -2);
			formation05.objectType [3] = ObjectType.HardRock;
			formation05.positions [4] = new Vector2 (10, 0);
			formation05.objectType [4] = ObjectType.HardRock;
			formation05.positions [5] = new Vector2 (8, 2);
			formation05.objectType [5] = ObjectType.HardRock;
			formation05.positions [6] = new Vector2 (6, 2);
			formation05.objectType [6] = ObjectType.HardRock;
			formation05.positions [7] = new Vector2 (4, 4);
			formation05.objectType [7] = ObjectType.HardRock;
			formation05.positions [8] = new Vector2 (4, -2);
			formation05.objectType [8] = ObjectType.HardRock;
			formation05.positions [9] = new Vector2 (2, 0);
			formation05.objectType [9] = ObjectType.HardRock;
			formation05.positions [10] = new Vector2 (2, 4);
			formation05.objectType [10] = ObjectType.HardRock;
			formation05.positions [11] = new Vector2 (0, 0);
			formation05.objectType [11] = ObjectType.HardRock;
			formation05.positions [12] = new Vector2 (0, 4);
			formation05.objectType [12] = ObjectType.HardRock;	
			formation05.positions [13] = new Vector2 (10, -2);
			formation05.objectType [13] = ObjectType.Dust;	
			objectFormations.Add (formation05);
			*/

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

		
			spawnTime = Time.time + 4.0f;
			formationNumber++;
			formationNumber %= objectFormations.Count;
		}

	}
}

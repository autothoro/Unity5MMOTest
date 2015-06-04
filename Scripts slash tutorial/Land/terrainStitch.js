#pragma strict

var terrainLeft : Terrain;
var terrainTop : Terrain;
var terrainRight : Terrain;
var terrainBottom : Terrain;

function Start () {
	var thisTerrain : Terrain = GetComponent(Terrain);
	thisTerrain.SetNeighbors(terrainLeft, terrainTop, terrainRight, terrainBottom);
}


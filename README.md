# dotbim (Version 1.0.0)

![image](https://user-images.githubusercontent.com/47977819/152003486-5d12be0e-43b2-4cf9-a37f-df406781ba11.png)

## Introduction

Introducing an open-source, accessible and simple file format for BIM.

Created by BIM developers for BIM developers.

<em>An idiot admires complexity, while a genius appreciates simplicity</em> - Terry Davis

## BIM vs IFC comparison

|                             | .bim                     | .ifc                                                      |
| --------------------------- | ------------------------ | --------------------------------------------------------- |
| Is it open?                 | Yes                      | Yes                                                       |
| Is it free?                 | Yes                      | Yes                                                       |
| Type                        | Text file                | Text file                                                 |
| What it contains            | Geometry + data attached | Geometry + data attached in a standardized way            |
| Types of geometries allowed | Triangulated meshes only | A lot of different types: meshes, extrusions, b-reps etc. |
| Pages of documentation      | 1                        | 100+                                                      |

To see much more extended comparison check out Dion's comparison here: https://github.com/paireks/dotbim/issues/8

## Apps

- C# library: you're looking at it right now ;)
- Python library: dotbimpy - https://github.com/paireks/dotbimpy
- Grasshopper plugin: dotbimGH - https://github.com/paireks/dotbimGH

## Community
Let's get this community bigger. Share it with your friends and colleagues that want to see a new BIM format: 
https://discord.gg/uhvx9sysvW

## NuGet package

https://www.nuget.org/packages/dotbim/

## Structure
![bimdot_Structure Complete](https://user-images.githubusercontent.com/23511558/152679875-404cf84d-7b2e-4172-8476-ea91ce491f28.jpg)

## File size

File size depends on the level of the deduplication made by exporter. You can reference the same mesh multiple times, which can have huge impact on decreasing the size when there is a lot of duplicate meshes.

Files created are also much more efficient once the user's meshes are being optimized, e.g. removing duplicate vertices or better discretization of geometry highly reduce the file size as well.

## Documentation

### Main information

- .bim
- License: MIT
- JSON structure
- x, y, z coordinates should be in meters
- Decimal point should be used
- JSON objects and properties should start with lowercase and with underscore as a seperator between words, e.g. schema_version 

### file

File contains 4 properties:

![bimdot_Structure GH](https://user-images.githubusercontent.com/23511558/152679932-786ae046-1bb5-4019-9246-ef87ca594cf1.jpg)

**schema_version** is the version of schema used in this file as string. Current one is "1.0.0".

### mesh

![bimdot_Mesh GH](https://user-images.githubusercontent.com/23511558/152679942-334d53dc-dc97-42f1-b418-db796fe47412.jpg)

**mesh_id** is integer >= 0 to reference this mesh later in element.

#### coordinates

It is a big array of all coordinates of a mesh. It is structured in this way:

[X0, Y0, Z0, X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, ..., XN, YN, ZN]

Let's say our mesh is defined by 3 vertices: (0.0, 0.0, 0.0), (10.0, 0.0, 0.0) and (10.0, 5.0, 0.0), then your vertices_coordinates will look like this:

[0.0, 0.0, 0.0, 10.0, 0.0, 0.0, 10.0, 5.0, 0.0]

Later in faces_ids we refer to these vertices by their order.

#### indices

It is a big array of ids (integers) that define all faces in a mesh. It is structured in this way:

[Face1_Id1, Face1_Id2, Face1_Id3, Face2_Id1, Face2_Id2, Face3_Id3, Face3_Id1, Face3_Id2, Face3_Id3, ..., FaceN_Id1, FaceN_Id2, FaceN_Id3]

If we'd like to create one-face mesh using vertices_coordinates from an example above, then it will look like this:

[0, 1, 2]

Pyramid example:

```json
  "coordinates": [
    0.0,
    0.0,
    0.0,
    10.0,
    0.0,
    0.0,
    10.0,
    10.0,
    0.0,
    0.0,
    10.0,
    0.0,
    5.0,
    5.0,
    4.0
  ],
  "indices": [
    0,
    1,
    2,
    0,
    2,
    3,
    0,
    1,
    4,
    1,
    2,
    4,
    2,
    3,
    4,
    3,
    0,
    4
  ]
```

### element

![bimdot_Element GH](https://user-images.githubusercontent.com/23511558/152679949-65c9169b-2c17-4bb7-b2dc-bd2d5ab5da33.jpg)
**guid** is a string that can be used for comparison of different elements. 

```json
"guid": "76e051c1-1bd7-44fc-8e2e-db2b64055068"
```

#### vector

Vector places referenced mesh where it should be placed as an element. It should have 3 properties:

1. x (value)
2. y (value)
3. z (value)

```json
  "vector": {
    "x": 9.9266016462536122,
    "y": 3.3910972817343494,
    "z": 52.239445879618685
  }
```

#### rotation

Rotation rotates referenced mesh how it should be rotated as element. It is a quaternion. It should have 4 properties:

1. qx (value) - first imaginary coefficient of the quaternion
2. qy (value) - second imaginary coefficient of the quaternion
3. qz (value) - third imaginary coefficient of the quaternion
4. qw (value) - real part of the quaternion

```json
  "rotation": {
    "qx": 0.63979295771454925,
    "qy": 0.10626982147910254,
    "qz": -0.12472093047736807,
    "qw": -0.7508770776915008
  }
```

#### color

color should have 3 properties:

1. r (integer between 0-255) - red
2. g (integer between 0-255) - green
3. b (integer between 0-255) - blue
4. a (integer between 0-255) - alpha

```json
  "color": {
    "r": 255,
    "g": 255,
    "b": 0,
    "a": 255
  }
```

#### type

Element type. It is a string that specifies what mesh represents. E.g. "Beam", "Plate".

```json
"type": "Beam"
```

### info

info is just a dictionary with string as key and value.

```json
  "info": {
    "Name": "Teapot",
    "Price": "2.50$"
  }
```

## Authors

- Wojciech Radaczyński

## Advisors
- Tom Van Diggelen
- Harry Collin
- Marios Messios

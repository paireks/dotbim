# dotbim (Version 1.0.0)

![image](https://user-images.githubusercontent.com/47977819/152003486-5d12be0e-43b2-4cf9-a37f-df406781ba11.png)

## Introduction

Easy to read and write file format for reliable 3D geometry exchange.

Created by BIM developers for other BIM developers.

<em>An idiot admires complexity, while a genius appreciates simplicity</em> - Terry Davis

## Community
Let's get this community bigger. Share it with your friends and colleagues that want to see a new BIM format: 
https://discord.gg/uhvx9sysvW

## BIM vs IFC comparison

|                             | .bim                     | .ifc                                                      |
| --------------------------- | ------------------------ | --------------------------------------------------------- |
| Is it open?                 | Yes                      | Yes                                                       |
| Is it free?                 | Yes                      | Yes                                                       |
| Type                        | Text file                | Text file                                                 |
| What it contains            | Geometry + data attached | Geometry + data attached in a stanadarized way            |
| Types of geometries allowed | Triangulated meshes only | A lot of different types: meshes, extrusions, b-reps etc. |
| Pages of documentation      | 1                        | 100+                                                      |

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

![image](https://user-images.githubusercontent.com/47977819/151888709-b3ea20a0-e3be-45cb-84cd-0e2abc971669.png)

**schema_version** is the version of schema used in this file as string. Current one is "1.0.0".

### mesh

![image](https://user-images.githubusercontent.com/47977819/151888781-3eeedad7-7114-4bbb-9d78-71c046490811.png)

**mesh_id** is integer >= 0 to reference this mesh later in element.

#### vertices_coordinates

It is a big array of all coordinates of a mesh. It is structured in this way:

[X0, Y0, Z0, X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, ..., XN, YN, ZN]

Let's say our mesh is defined by 3 vertices: (0.0, 0.0, 0.0), (10.0, 0.0, 0.0) and (10.0, 5.0, 0.0), then your vertices_coordinates will look like this:

[0.0, 0.0, 0.0, 10.0, 0.0, 0.0, 10.0, 5.0, 0.0]

Later in faces_ids we refer to these vertices by their order.

#### faces_ids

It is a big array of ids (integers) that define all faces in a mesh. It is structured in this way:

[Face1_Id1, Face1_Id2, Face1_Id3, Face2_Id1, Face2_Id2, Face3_Id3, Face3_Id1, Face3_Id2, Face3_Id3, ..., FaceN_Id1, FaceN_Id2, FaceN_Id3]

If we'd like to create one-face mesh using vertices_coordinates from an example above, then it will look like this:

[0, 1, 2]

### element

![image](https://user-images.githubusercontent.com/47977819/151888827-b7a815e8-5e61-4111-9477-f9f61e2f2054.png)

**mesh_id** is an id of a mesh that represents element.

**guid** is a string that can be used for comparison of different elements. 

E.g. 209a70e4-d8c7-4356-a8a9-cfa611d9c51f

#### vector

Vector places referenced mesh where it should be placed as an element. It should have 3 properties:

1. x (value)
2. y (value)
3. z (value)

#### rotation

Rotation rotates referenced mesh how it should be rotated as element. It is a quaternion. It should have 4 properties:

1. qx (value) - first imaginary coefficient of the quaternion
2. qy (value) - second imaginary coefficient of the quaternion
3. qz (value) - third imaginary coefficient of the quaternion
4. qw (value) - real part of the quaternion

#### color

color should have 3 properties:

1. r (integer between 0-255) - red
2. g (integer between 0-255) - green
3. b (integer between 0-255) - blue
4. a (integer between 0-255) - alpha

#### type

Element type. It is a string that specifies what mesh represents. E.g. "Beam", "Plate".

### info

info is a list of keys and list of values. Both lists should match. They can be useful to store all custom information. Both keys and values should be strings.

```json
"info": {
    "keys": [
        "Price",
        "Name"
    ],
    "values": [
        "2.50$",
        "Teapot"
    ]
}
```

## Authors

- Wojciech Radaczyński
- Marios Messios
- Harry Collin
- Tom Van Diggelen

![dotbim header](https://user-images.githubusercontent.com/4988604/212753228-2abcdfbe-b824-4f64-9c87-1319dae7e7ca.png)

# dotbim (Schema version 1.0.0)

[![Release](https://img.shields.io/nuget/v/dotbim?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/dotbim/)
[![.NET Standard 2.0](https://img.shields.io/badge/-.NET%20Standard%202.0-blue)](https://www.nuget.org/packages/dotbim/)
[![.NET Framework 4.0](https://img.shields.io/badge/.NET%20Framework%204.0-blue.svg)](https://www.nuget.org/packages/dotbim/)

![image](https://user-images.githubusercontent.com/47977819/152003486-5d12be0e-43b2-4cf9-a37f-df406781ba11.png)

## Introduction

Introducing an open-source, accessible, simple, minimalistic file format for BIM. Built to be easy to read and write.

Created by BIM developers for BIM developers.

<em>An idiot admires complexity, while a genius appreciates simplicity</em> - Terry Davis

Website: https://www.dotbim.net

Quick introduction video: https://www.youtube.com/watch?v=RSV-0-UrzhQ

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

## Guide for developers

If you're a developer, check out this document: https://github.com/paireks/dotbim/blob/master/DeveloperTips.md

## Apps supporting .bim

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| dotbim | C# library | you're looking at it right now ;) |  |
| dotbimpy | Python library | https://github.com/paireks/dotbimpy |  |
| dotbimGH | Grasshopper plugin | https://github.com/paireks/dotbimGH | |
| dotbim-ifc | Converts to and from IFC and dotbim | https://github.com/Moult/dotbim-ifc | Dion Moult |
| Online 3d Viewer | 3d viewer in your browser, it can also convert to and from other file formats | https://3dviewer.net/ | Viktor Kovacs, Agnes Gaschitz |
| dotbim-blender | Blender addon | https://github.com/paireks/dotbim-blender | Nathan Hild |
| dotbim-io-dxf | Converts to and from 3d DXF and dotbim | https://github.com/Gorgious56/dotbim_io_dxf | Nathan Hild |
| dotbim-ts | Typescript library | https://github.com/baid-group/dotbim-ts | Maciej Lutostański |
| dotbim-archicad | Archicad addon | https://github.com/kovacsv/dotbim-archicad | Viktor Kovacs |
| os4bim/dotbim | Converts Revit's detailed MEP to schematic 3d model | https://github.com/os4bim/dotbim | Yoann Obry |
| import_dotbim | SketchUp addon | https://github.com/MattiaBressanelli/import_dotbim | Mattia Bressanelli |
| dotbim.three.js | Three.js addon | https://github.com/ricaun/dotbim.three.js | Luiz Henrique Cassettari |
| ICEBridge | Blender plugin to send BIM data to IDA ICE | https://github.com/maxtillberg/ICEBridge | Max Tillberg |


![dotbim drawio (7)](https://user-images.githubusercontent.com/47977819/195170052-8081d7d7-d69d-4e2e-a5fd-97ff4b727543.svg)

If you're building any app that will use .bim - let me know, I'll post it here :)

## NuGet package

https://www.nuget.org/packages/dotbim/

It may require importing another nuget for Newtonsoft.Json library: https://www.nuget.org/packages/Newtonsoft.Json/9.0.1

## Structure
![bimdot_Structure Complete](https://user-images.githubusercontent.com/23511558/152679875-404cf84d-7b2e-4172-8476-ea91ce491f28.jpg)

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

.bim file format encourages users to link their data by attaching URLs inside properties of file or specific elements. E.g.:

```json
  "info": {
    "Name": "Metal sheet roofing",
    "Catalogue": "https://pruszynski.com.pl/t-20-roof,prod,99,2294.php"
  }
```

Such functionality allows also to link one model with another as well.
If you're interested in this kind of linking, check this separate document about it: https://github.com/paireks/dotbim/blob/master/LinkingData.md

## Tell me more

If you'd like to read more details about this project, a bit background + line-by-line explanation, you might find this article on BIM Corner interesting: https://bimcorner.com/a-new-bim-file-format/

## Extensions

- Multicolor extension: https://github.com/paireks/dotbim-extensions-multicolor

## Author

- Wojciech Radaczyński

## Advisors
- Tom Van Diggelen
- Harry Collin
- Marios Messios

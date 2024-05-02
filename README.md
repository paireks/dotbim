![dotbim header](https://user-images.githubusercontent.com/4988604/212753228-2abcdfbe-b824-4f64-9c87-1319dae7e7ca.png)

# dotbim (Schema version 1.1.0)

[![Release](https://img.shields.io/nuget/v/dotbim?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/dotbim/)
[![.NET Standard 2.0](https://img.shields.io/badge/-.NET%20Standard%202.0-blue)](https://www.nuget.org/packages/dotbim/)
[![.NET Framework 4.0](https://img.shields.io/badge/.NET%20Framework%204.0-blue.svg)](https://www.nuget.org/packages/dotbim/)

![AddOnIcon_154x154](https://user-images.githubusercontent.com/47977819/214624938-0e201999-7d74-4fc1-b975-03e20a961e21.png)

## Introduction

Introducing an open-source and minimalist file format for BIM. Built to be easy to read and write.

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

## Apps supporting .bim (alphabetical order)

### Export and/or Import of .bim files

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| FacadeOption | Facade modelling | https://app.facadeoption.com | FacadeOption |
| kolega.space | Generative conceptual design | https://www.kolega.space/ | Designbotic |
| Spacio | Lets you design, analyse, and bring to life properly structured building proposals – all within the same day. | https://spacio.ai/ | Spacio |
| three.model.bim | 3d modelling in browser | https://github.com/RyugaRyuzaki/three.model.bim | Ryuga Ryuzaki |
| T-Rex | Reinforcement in Grasshopper | https://www.food4rhino.com/en/app/t-rex | Wojciech Radaczyński |

### Viewers that support .bim files

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| dotbim.three.js Viewer | Viewer from dotbim.three.js | [Click](https://htmlpreview.github.io/?https://github.com/ricaun/dotbim.three.js/blob/master/index.html) | Luiz Henrique Cassettari |
| Online 3d Viewer | 3d viewer in browser | https://3dviewer.net/ | Viktor Kovacs, Agnes Gaschitz |
| STEP Viewer | 3d viewer in browser | [Click](https://githubdragonfly.github.io/viewers/templates/STEP%20Viewer.html) | GitHubDragonFly |

### Connectors - plugins that allow to export and/or import of .bim files to other software

| Name | Link | Author |
| ---- | ---- | ------ |
| dotbim-archicad | [Click](https://github.com/kovacsv/dotbim-archicad) | Viktor Kovacs |
| dotbim-blender | [Click](https://github.com/paireks/dotbim-blender) | Nathan Hild |
| DotBimConvert/RevitExporter | [Click](https://github.com/RyugaRyuzaki/DotBimConvert/tree/main/RevitExporter) | Ryuga Ryuzaki |
| dotbimGH | [Click](https://github.com/paireks/dotbimGH) | Wojciech Radaczyński |
| dotbimRH | [Click](https://github.com/seghier/DotBimRHImportExport) | Seghier Mohamed Abdelaziz |
| dotbim.three.js | [Click](https://github.com/ricaun/dotbim.three.js) | Luiz Henrique Cassettari |
| import_dotbim | [Click](https://github.com/MattiaBressanelli/import_dotbim) | Mattia Bressanelli |

### Libraries for developers

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| dotbim | C# library | you're looking at it right now ;) | Wojciech Radaczyński |
| dotbimpy | Python library | https://github.com/paireks/dotbimpy | Wojciech Radaczyński |
| dotbim-ts | Typescript library | https://github.com/baid-group/dotbim-ts | Maciej Lutostański |

### Converters - programs that allow to convert to/from .bim files

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| DotBimConvert/IFC | Convertes to IFC | https://github.com/RyugaRyuzaki/DotBimConvert/tree/main/Ifc | Ryuga Ryuzaki |
| dotbim-ifc | Converts to and from IFC and dotbim | https://github.com/Moult/dotbim-ifc | Dion Moult |
| dotbim-io-dxf | Converts to and from 3d DXF and dotbim | https://github.com/Gorgious56/dotbim_io_dxf | Nathan Hild |
| mesh2mesh | Mac application with ability to convert from .dae, .obj, .ply, .scn, .stl, .usd, .usda, .usdz | https://apps.apple.com/us/app/mesh2mesh/id1672770477 | fluthaus |
| Online 3d Viewer | 3d viewer with ability of conversion from .obj, .3ds, .stl, .ply, .gltf, .glb, .off, .3dm, .fbx, .dae, .wrl, .3mf, .amf, .ifc, .brep, .step, .iges, .fcstd. | https://3dviewer.net/ | Viktor Kovacs, Agnes Gaschitz |

### Other projects related to .bim

| Name | Purpose | Link | Author |
| ---- | ------- | ---- | ------ |
| DotBimConvert/Compress | Compress and decompress .bim files | [Click](https://github.com/RyugaRyuzaki/DotBimConvert/tree/main/Compress) | Ryuga Ryuzaki |
| ICEBridge | Blender plugin to send BIM data to IDA ICE | [Click](https://github.com/maxtillberg/ICEBridge) | Max Tillberg |
| os4bim/dotbim | Converts Revit's detailed MEP to schematic 3d model | [Click](https://github.com/os4bim/dotbim) | Yoann Obry |

If you're building any app that will use .bim - let me know, I'll post it here :)

## NuGet package

https://www.nuget.org/packages/dotbim/

It may require importing another nuget for Newtonsoft.Json library.

## Structure
![BIM_Structure_01](https://user-images.githubusercontent.com/4988604/216430744-4b06030c-72e7-4d18-ac30-e5b90ac598f5.png)


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

![BIM_file_01](https://user-images.githubusercontent.com/4988604/216434213-51b92980-1a9a-49b4-85e7-62fb439a7ef1.png)

**schema_version** is the version of schema used in this file as string.

### mesh

![BIM_Mesh_01](https://user-images.githubusercontent.com/4988604/216436783-eae0e200-7521-492c-9412-59aa5e15b4a7.png)

**mesh_id** is integer >= 0 to reference this mesh later in the element.

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

![BIM_Element_01](https://user-images.githubusercontent.com/4988604/216438260-73f6bd54-56db-41b4-9509-6c0da2281089.png)
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

#### color and face_colors

**From schema_version 1.1.0 if face_colors tag is applied, then we color element using face_colors, if there is no face_colors - we use color tag to color an element.**

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

To color single element with multiple colors add "face_colors" tag inside an element. "face_colors" is a simple list of integers (integers should be between 0-255) organised in that way:

[r1, g1, b1, a1, r2, g2, b2, a2, r3, g3, b3, a3, ... rn, gn, bn, an]

It should match each face of the mesh.

So let's say you have 3 faces inside one mesh, and wanted to color first face (triangle) as red (255,0,0,255), second as skyblue (135,206,235,255), third as white (255,255,255,255). Then you will have:

```json

"face_colors" : [ 255, 0, 0, 255, 135, 206, 235, 255, 255, 255, 255, 255 ]

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

## Authors

- Wojciech Radaczyński
- Viktor Kovacs

## Advisors
- Tom Van Diggelen
- Harry Collin
- Marios Messios

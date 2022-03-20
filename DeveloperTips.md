# Developer Tips For .bim

![image](https://user-images.githubusercontent.com/47977819/152003486-5d12be0e-43b2-4cf9-a37f-df406781ba11.png)

## Introduction

### Hey!

.bim files are simple so this guide also should be. Here you will find explanation of some concepts that will help you to write importers, exporters, parsers, or other tools based on .bim files.

### Libraries

If you're into C#, go with dotbim library (MIT License, available on NuGet): https://github.com/paireks/dotbim

If you're into Python, go with dotbimpy library (MIT License, available on PyPi): https://github.com/paireks/dotbimpy

### Apps

You will find all other libraries or apps working with .bim files here: https://github.com/paireks/dotbim#apps

### Example .bim files

They are stored there: https://github.com/paireks/dotbim/tree/master/test/ExampleFiles

### TLDR

**We transfer triangulated meshes with dictionary attached to it.**

It's good to know that **.bim files = JSON files** structured in some certain way.

Units for coordinates: **meters**.

**.bim files** were meant to be easy to work with from the developer point of view! Whole manifesto can be found here: https://dotbim.net/

## Structure

Every .bim file is structured with 4 components:

- List of meshes (it represents all geometries)
- List of elements (it represents all elements)
- Schema version: it's "1.0.0"
- Info: dictionary with information about file

It looks like this as a whole:

![image](https://user-images.githubusercontent.com/23511558/152679875-404cf84d-7b2e-4172-8476-ea91ce491f28.jpg)

## Programming exporter

### Meshes

Writing exporter means you'd have to turn all geometries into triangulated meshes.

Many CAD/BIM software already have an option that allows such discretization or they already store geometries as meshes. If it's not your case, and there is no way for you to get meshes out of your software - then it won't be a trivial task, as it will require creating also discretization part.

![2022-03-20_19h28_07](https://user-images.githubusercontent.com/47977819/159177177-c2817d7a-3cbf-4dcc-b6b4-8a92ec6b8dc6.png)

Once you have all your geometries as meshes, then you can pack them into mesh list.

Depending on a software: sometimes you can already access all deduplicated geometries - then you can save all of them and reuse one mesh multiple times using mesh_id in elements. If there is no such deduplication mechanism in software itself: you can either try to create your own, or get rid off reusing one mesh multiple times. Second option will work fine, but files can be really huge then, because of number of duplicate meshes, that will be stored.

Meshes are stored as a flattened list of coordinates and a flattened list of indices. All coordinates should be stored in **meters**.

### Elements

Pack all data about elements there in one flattened dictionary. 

With mesh_id you can reference the mesh (from meshes list above) that represents geometry of this element. With rotation and vector property you can position your mesh in a proper way.

Regarding colors 1 element = 1 color (R,G,B,A). This is to make things easier for importers, as not all software support multiple colors for 1 mesh or some more difficult concepts like e.g. textures. From the exporter perspective it means that you'd have to divide an element into separate elements if they have different colors inside and if you'd like to move these separate colors.

## Programming importer

### Meshes

Many CAD/BIM software already have the Mesh geometry type, which makes it easy to import. But not all of them have that in fact. Good news is that even if there is no Mesh geometry type, you probably can create some sort of a BREP using triangles from these meshes. So either way you should be able to import it.

### Elements

To move these geometries in a correct way you need to properly position these meshes imported first. First you need to rotate them by the rotation described for each element, and then you need to move them by a vector described for each element.

## Few other comments

### Rotation + Vector (These quaternions?!)

All elements are positioned within vector and rotation. Vector is quite obvious, while rotation are not that much, as they are described as quaternions.

First question is: why it's like that, when we could store e.g. Transformation matrices instead?

Well, decision was to do it with vector + quaternions instead, because transformation matrices can actually store some other different transformation that don't make sense for deduplication purposes, e.g. shear or scaling. This format is minimalist and for BIM, so it's much more natural to e.g. have one chair and position it and rotate, but we don't want to shear it or scale for some reason. Scale also doesn't make sense there, because we expect all meshes coordinates already as meters, so this additional scaling is also not relevant here. Transformation matrices are often treated as black box, so even though they sometimes look more straight forward - they are actually a bit harder to work with while debuging (in my opinion).

Ok, then why quaternions? Quaternions are the most elegant way to describe rotation in 3d space as it needs only 4 numbers to achieve this. Some software (e.g. Blender, Rhino) already have tools that allows to work with them. But not all BIM/CAD software have tools like this for devs. Most of them actually deal with transformation matrices all e.g. axis rotation. Good news is: you will find libraries that will help you to transfer one transformations into quaternions and other way around as well. For Python there is pyquaternion library, for C# check System.Numerics.

### File size

File size depends on:

- level of deduplication of meshes
- mesh quality

Still remember: this is text file format, which makes it big by definition. To make it smaller: compress it!

Also it's good to mention, that meshes are also by definition big in terms of file size (if we compare it to some other geometry types). Most of the time it will probably take most of the space in file. That's why we store them as flatten list of vertices and coordinates, to make it as tiny as we can in text file.

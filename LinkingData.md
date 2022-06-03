# Linking data with .bim

## Intro

.bim file format encourages users to link their data by attaching URLs inside properties of file or specific elements.

This way there is a whole new dimension of storing the data in .bim files. Inside specific element there will be a link where you can point at specific website, pdf file, spreadsheet, report etc. Or even further - point at another model. To explain it a bit better we will see how it works using model created by Robert Juchnevic. This model is available here for you to explore it: https://3dviewer.net#model=https://raw.githubusercontent.com/paireks/dotbim/master/test/ExampleFiles/TestFilesFromBlender/House.bim

## Linking data

Imagine that you want to link some pdf, chart or maybe a catalogue page for a specific element. Then just attach the URL to that data as a property value, and that's it. Online 3d Viewer will automatically recoginze that it's looking at the URL, so it will create hyperlink automatically. 

Inside .bim file it can be like this:

    "info": {
        "Name": "Metal sheet roofing",
        "Catalogue": "https://pruszynski.com.pl/t-20-roof,prod,99,2294.php"
    }

Then in Online 3d Viewer:

![2022-05-07_09h50_38](https://user-images.githubusercontent.com/47977819/167265321-fd3228c1-52c1-45ae-83f9-556924e5d532.png)

It can be especially useful to connect some spreadsheets, e.g:

![2022-05-07_10h04_59](https://user-images.githubusercontent.com/47977819/167265518-3b5298fa-7bae-4ddf-b574-b49c6540cb08.png)

Or maybe some map?

![2022-05-07_10h13_29](https://user-images.githubusercontent.com/47977819/167265566-b78464cb-a220-4925-a227-9908db661d6d.png)

## Linking models: Multilevel BIM

If we can link to some data, then why not link to another model? That could be useful for multiple different things.  E.g. it can solve the issue that many modellers in AEC deals with - too heavy models. This way you can create multidimensional model in which every level of a model will have different LOD. You can check this solution in Robert's model:

https://3dviewer.net#model=https://raw.githubusercontent.com/paireks/dotbim/master/test/ExampleFiles/TestFilesFromBlender/House.bim
https://3dviewer.net/#model=https://github.com/paireks/dotbim/blob/master/test/ExampleFiles/TestFilesFromBlender/Site%20plan%201.bim

![2022-05-07_10h25_09](https://user-images.githubusercontent.com/47977819/167265680-f18d8948-30cf-4ee4-9773-cba33a58743f.png)

![image](https://user-images.githubusercontent.com/47977819/167266031-566482c6-6dc0-4c37-ba82-5ffd8b5859a0.png)

![image](https://user-images.githubusercontent.com/47977819/169669180-545dd883-07f9-4f3d-88cd-e0688424c168.png)






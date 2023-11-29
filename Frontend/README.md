# Image gallery application

## Implementation variants
- app_1 - vanilla JS only variant
- app_2 - ReactJS variant

## Description
Each time the application is loaded - terms of use should be shown and have to be accepted. As soon as they have been accepted the main content of the application can be displayed, which is a collection of pictures with the possibility to save them to the file system.

## Requirements
JSON_DATA for steps 1-2 should be fetched from here [http://167.71.69.158/static/test.json](http://167.71.69.158/static/test.json). Allowed origin: [http://localhost:3000](http://localhost:3000).

## Functionality
1.	**Terms of Use** <br>
Show terms of use and allow accepting them by clicking the “Accept” button. <br>
** Vanilla JS version of this functionality must be Implemented as an `async function acceptTermsOfUse(termsOfUse)` so it can be awaited before showing the main content of the app.
2.	**Show an image collection** <br>
Show images as canvas elements. <br> ** Vanilla JS version of this functionality must be Implemented as a single `async function renderImageToCanvas(imageUrl)` so you can easily reuse it for rendering as many pictures as you need. <br> *** image_urls are relative to the host.
3.	Save an image <br>
Implement “Save Image” functionality via button. By clicking on this button the image should be saved to the file system.

Suggestions: do not dive deep into the design, focus on functionality. 
Host http://167.71.69.158 is safe, do not worry about absence of https.

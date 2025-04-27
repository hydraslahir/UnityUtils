## Unity utils scripts

## Setup

I currently use this repo as an external Hard-linked folder in my projets.
Allows me to reuse that util folder from within multiple projects

1. Clone the repo somewhere, e.g. "C:\Unity\"
2. Have an url to the asset folder of one of your projects e.g. "C:\Unity\Projects\ABigCat\Assets\"
3. Create an hard-link to that folder from your existing project 
<br><pre>
[Admin cmd]
mklink /D C:\Unity\Projects\ABigCat\Assets\Utils C:\Unity\Utils
</pre>
4. Add Utils to your .gitignore file (or don't, but bear the consequences of having duplicates repos and merge conflicts)
5. From time to time, commit and push your modifications within "C:\Unity\"

----

### ChannelMerger

Takes up to 4 maps, reads a <see cref="Mapping"/> Channel and writes it to an output.
Allows to create MaskMaps <see cref="https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@13.1/manual/Mask-Map-and-Detail-Map.html"/>

Requirements:
1. All input must be Read/write in the import (you could convert non-readable to readable with RenderTextures)

Considerations:
1. If Alpha is all black, no output will be pushed in the alpha channel
1. The output extention is not respected, '.image' will be overriden by either '.jpg' or '.png'
1. If there are no map, black is written, could be optimized to have a 2 channels maps and swizzle in unity, but I didn't bother.

Unity Mask map mapping:<br>
R : Metallic <br>
G : AO <br>
B : Detail <br>
A : Smoothness

![alt text](/Docs/ChannelMerger.png)
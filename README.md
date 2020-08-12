# ImOrg
Image and video files renaming tool.
Recommended branch: WMP

Features:
- Directory tree to explore your local drives.
- View images and videos.
- Rename or move files by typing a new filename.
- Customize background and text color.
- Change image or video format.
- Auto rename to avoid filename conflict using windows's standard method: (?).

Instructions:
- Compile with Visual Studio 2019 Community Edition or download a precompiled version from the Releases page or from DeepStringDump\bin\Release for a more regular binary push.
- Open a folder, click on a file at the bottom of the app and use up/down arrow keys to view the next or previous image or video.
- Only supported files will be shown. Click on the dropdown list at the bottom left to show all files or change various settings.
- Current keybinds:
ESC : cancel last new name
F1  : use the last typed name
F2  : change renaming mode
F11 : change video view mode
F12 : change image view mode

Features to add:
- Implement CTRL+Z or other key to revert name changes.
- Save settings and last used path to appdata.
- Replace Windows Media Player with FFMPEG for more codecs compatibility, eliminate memory leak, and speed up video loading and renaming.
- Add text files support.
- Hex viewer for unsupported files.
- Preload images for a faster viewing experience.
- Implement a proper fullscreen mode.
- Files list auto scroll should keep the highlighted item in the middle of the list, to see above and bellow it.

Current known issues:
- Short freeze when renaming a video, occurs randomly. (probably due to memory leak)
- Can't rename when there's only one file in the selected folder.

Current major issues:
- Severe memory leak when reading certain video files.

Tested supported file formats:
- Image: jpg, png, gif, tif, bmp, ico, tiff, jpeg
- Video: webm, mp4, mkv

Unsupported file formats:
- Image: webp, dds, tga
- Video: flv

Complete list of supported file formats based on the used Windows Media Player library.
- Any file type supported by WinForms PictureBox:
(BMP, GIF, JPEG, EXIF, PNG and TIFF)
- Any file type supported by Windows Media Player:
(asf, wma, wmv, wm, asx, wax, wvx, wmx, wpl, dvr-ms, wmd, avi, mpg, mpeg, m1v, mp2, mp3, mpa, mpe, m3u, mid, midi, rmi, aif, aifc, aiff, au, snd, wav, cda, ivf, wmz, wms, mov, m4a, mp4, m4v, mp4v, 3g2, 3gp2, 3gp, 3gpp, aac, adt, adts, m2ts, flac)

See DeepStringDump\bin\Release for more regular binary push than the releases page.
![Image of current version](https://github.com/dany5639/ImOrg/releases/download/1.0/2020-01-18.17_11_32-ImOrg.jpg)

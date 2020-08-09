# ImOrg
Image and video files renaming tool.
Recommended branch: WMP

Features:
- Directory tree to explore your local drives.
- View images and videos.
- Rename files by typing a new filename.
- Move file to a new subdirectory by typing a new name.
- Customize background and text color.

Instructions:
- Compile with Visual Studio 2019 Community Edition or download a precompiled version from the Releases page.
- Extract and run the program.
- Select the drive and folder in the list on the left.
- Click on a file in the bottom files list and use arrow keys to view the next or previous image or video.
- Only supported files will be shown. Click on the dropdown list at the bottom left to allow all files.
- Use F11 (images) and F12 (videos) to resize the viewer.

Features to add:
- Implement CTRL+Z or other key to revert name changes.
- Save settings and last used path to appdata.
- Replace Windows Media Player with FFMPEG for more codecs compatibility.
- Preload images for a faster viewing experience.
- Add text files support for viewing.
- Implement a proper fullscreen mode.
- Add feature to append name at the start or end of the original filename.
- Hex viewer.
- Files list auto scroll should keep the highlighted item in the middle of the list, to see above and bellow it.

Current known issues:
- Short freeze when renaming a video, occurs randomly.
- Enter has effect if there's only one viewable item in the folder.
- Left and right arrow don't rename items when viewing the next item.
- Enter key should rename the currently viewed item and update the files list with the new name.
- Files list doesn't auto scroll properly.

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

![Image of current version](https://github.com/dany5639/ImOrg/releases/download/1.0/2020-01-18.17_11_32-ImOrg.jpg)

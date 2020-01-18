# ImOrg
Image and video files renaming tool.

Features:
- Directory tree to explore your local drives.
- Load images and videos.
- Rename files by typing the new name.
- Change program background and text colors.

Instructions:
- Compile with Visual Studio 2019 Community Edition or download a precompiled version from the Releases page.
- Extract and run the program.
- Select the drive, folder, or expand, to view files in the bottom file list.
- Click on a file or use arrow keys to view the image or video.
- Only supported files will be shown.
- Click at the bottom left to display all file types.

To Do:
- Implement CTRL+Z or other functionality to revert name changes.
- Save settings to file.
- Replace Windows Media Player with FFMPEG for more codes compatibility.
- Prevent delay when renaming videos.
- Preload images for a faster viewing experience.
- Notify the user if a file is unreadable.
- Notify the user if a file has the wrong extension.
- Add text files support.
- Add more file types support.
- Allow directory change when renaming files ( F:\image1.jpg: renaming to new\image1 would create the "new" folder and move the file)

Tested supported file formats:
- Image: jpg, png, gif, tif, bmp, ico, tiff, jpeg
- Video: webm, mp4, mkv

Unsupported file formats:
- Image: webp, dds, tga
- Video: flv

Complete list of supported file formats based on the used libraries.
- Any file type supported by WinForms PictureBox:
(BMP, GIF, JPEG, EXIF, PNG and TIFF)
- Any file type supported by Windows Media Player:
(asf, wma, wmv, wm, asx, wax, wvx, wmx, wpl, dvr-ms, wmd, avi, mpg, mpeg, m1v, mp2, mp3, mpa, mpe, m3u, mid, midi, rmi, aif, aifc, aiff, au, snd, wav, cda, ivf, wmz, wms, mov, m4a, mp4, m4v, mp4v, 3g2, 3gp2, 3gp, 3gpp, aac, adt, adts, m2ts, flac)

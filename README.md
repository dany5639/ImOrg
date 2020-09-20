# ImOrg
TLDR: Tool to rename files as you them, such as images, videos, sound files, text files.
Uses FFPLAY/FFMPEG to read videos and sound files.

Features:
- Directory tree to explore local drives.
- View images, videos, text files, play sound files.
- Rename files by typing a new filename.
- Move file to a new subdirectory by changing the settings and typing a new name.
- Restore original filename before renaming it with a hotkey.
- Customize background and text color.
- Current keybinds:
ESC : cancel last new name
F1  : use the last typed name
F2  : change renaming mode
F3  : restore the original filename before renaming it in this session.

Instructions:
- Compile with Visual Studio 2019 Community Edition or download a binary from the Releases page or ImOrg/bin/x64/Debug/ImOrg.exe for the most frequent updates.
- Compile or download a precompiled build of FFMPEG to get FFPLAY.exe : https://ffmpeg.org/download.html (FFPLAY.EXE needs to be in the same folder as ImOrg.exe)
- Double click on ImOrg.exe to open it as a program.
- Once it's open, select the folder to open from the list of drives on the left panel.
- Once a folder is selected, all supported files will appear in the bottom list.
- Click on the bottom left icon to change the settings.
- Note on text files: only 200 lines are read unless the settings are changed.

Features to add:
- Save settings and the last used path.
- Preload images for a faster viewing experience.
- Add a hexadecimal/raw viewer for unsupported files.
- Files list auto scroll should keep the highlighted item in the middle of the list, to see the items above and bellow it.
- Allow user to resize the left and bottom panels.

To Fix ASAP:
- Fast forwarding in a video will cause the window to not be focused anymore. 
Current behavior: press arrow, video fast forwards, click on window to focus again, type new name.
Expected behavior: press arrow, video fast forwards, type new name.

Current known issues:
- Using F3 to restore the original name won't move the file to its original folder if it was moved with the move option.
- In some rare cases, FFPLAY can run detached from the program.

Tested supported file formats:
- Image: jpg, png, tif, bmp (any formats supported by WinForms' PictureBox)
- Video: mp4, webm, gif (any formats supported by FFPLAY)
- Text: txt, csv, log, xml, json, ahk, ini, amgp, cs, etc

IMPORTANT:
Do NOT rename any files that may cause damage to the OS or Programs or other. You are sole responsible on how you use this program.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

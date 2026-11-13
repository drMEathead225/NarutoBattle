NARUTO BATTLE ARENA - SOURCE FILES
==================================

These are the code files only. Visual Studio generates the icons, fonts and
Windows manifest, so you start from a new project and drop these files in.

SETUP (about 10 minutes)
1. Visual Studio > Create a new project > ".NET MAUI App" > name it exactly:  NarutoBattle
   (the name matters: every file uses the namespace NarutoBattle)
2. Set the debug target (top toolbar) to "Windows Machine".
   If Windows asks, turn on Developer Mode (Settings > Privacy & security > For developers).
3. In Solution Explorer, DELETE:  MainPage.xaml  (this also removes MainPage.xaml.cs)
4. Copy every file from this folder into the project root, replacing the template's
   App.xaml, AppShell.xaml and AppShell.xaml.cs when asked.
   (Do NOT overwrite App.xaml.cs or MauiProgram.cs - leave those as the template made them.)
   Easiest way: select the files here, drag them onto the project name in Solution Explorer.
5. The 8 character pictures are included in this zip (Resources/Images folder, already named
   correctly). Drag them into Resources > Images in Solution Explorer. Names used:
      naruto.jpg  madara.jpg  pain.jpg  sakura.jpg
      orochimaru.jpg  itachi.jpg  gaara.jpg  kurenai.jpg
   If yours are .png, change the extensions in GameState.cs.
6. Press F5.

FILES
Fighter.cs, GameState.cs ........ data shared by all screens
App.xaml ........................ shared colors and styles
AppShell.xaml / .cs ............. navigation routes
TitlePage ....................... screen 1 (Enter)
CharacterSelectPage ............. screen 2 (pick 2 fighters)
BattleTypePage .................. screen 3 (Solo Battle)
SoloBattlePage .................. screen 4 (the fight)
VictoryPage ..................... screen 5 (winner and why)

IF IT DOES NOT BUILD
- Image missing: file name must match GameState.cs exactly (lowercase, same extension).
- Namespace errors: the project must be named NarutoBattle.
- Duplicate MainPage errors: make sure MainPage.xaml was deleted.

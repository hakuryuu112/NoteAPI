# NoteAPI

Database :
restore Database NoteDB in SQLSever
src : NoteAPI/Database/NoteDB.bak

Running .Net Web API :
edit appsetiing.json with your DB
"DefaultConnection": "Server=ALMIRAJ;Database=NoteDB;Trusted_Connection=True;TrustServerCertificate=True;" // Your Database

Running Electron App :
Edit API_CWD in index.js with your specific .NET API folder.
const API_CWD = 'E:/Data Kerja/repos/NoteAPI/.Net Web API/NoteAPI'; // Your .NET API folder
cd electron-note-app
npm install
npm start

or running .Net web API using visual Studio and the tray running again Electron App if the instruction above failed.

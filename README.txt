Wellness Center Project
Repository Setup:
1.Initialize an empty repository on your computer: git init
2.Clone the main repository: git clone https://github.com/ArkadiuszSchabowski/WellnessCenter.git


Open Backend in Visual Studio:
1.Choose the "Open Project or Solution" option and select the program.cs file.
2.On the top navbar, select the HTTP profile.
3.Click the green arrow button next to the profile to run the project.

Open Backend in Visual Studio Code:
1.Download the .NET SDK Core plugin.
2.Navigate to the SpaSalon folder in WellnessCenter/Backend: cd WellnessCenter/Backend/SpaSalon
3.Run the project in the command line: dotnet run --launch-profile http start http://localhost:5267/swagger/index.html
4.Click on the link: http://localhost:5267/swagger/index.html


Open Frontend in Visual Studio Code:
1. Navigate to the WellnessCenter folder: cd WellnessCenter
2.Create a new folder for the frontend project, e.g., Frontend_YourName, if it doesn't exist.
3.Inside this folder, create a React or Angular project, if it doesn't exist.
4.Configure the new project: Set the frontend port to 5173 and the backend port to 5267.
5.Run the project in the command line: npm run dev
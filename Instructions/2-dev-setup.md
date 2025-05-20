# Dev Set up and Project Structure 
This part of the tutorial will walk you thorugh the steps needed to setup your lab environment. 

Your VM should have the following apps available in the task bar: 
- Visual Studio 2022
- Command Prompt
- File Explorer
- Edge

You will now install the developer tools and samples needed to complete the scenarios.  

## 1. Clone the repository
This repository has the sample apps that you will build action experiences. Type in to command prompt:

``` git clone "https://github.com/microsoft/Lab370.git" ```

Then authenticate by logging in to GitHub.

## 2. Install the VSIX and Code Generation Nuget Package
These tools will be used in the first scenario to make action developement easier. 

- Navigate to the [latest Release for this repository](https://github.com/microsoft/Build25-LAB370/releases/tag/v1.0.0) and download **Lab370DevTools.zip** from the Assets.
- Extract the **Lab370DevTools** file
- Double Click on the Windows Action VSIX to install it in Visual Studio
- Copy the Nuget package **Microsoft.AI.Actions.Annotations.0.1.0.nupkg** to your `C:\LocalNuget folder`.


## 3. Install App Actions Testing Playground 
This test tool will be used in the first scenario so you can test the actions you create.

- Navigate to the [latest Release for this repository](https://github.com/microsoft/Build25-LAB370/releases/tag/v1.0.0) and download **Microsoft.ActionsTestingTool.zip** from the Assets.
- Extract the **Microsoft.ActionsTestingTool.zip** file
- Double click on the file to launch the test tool installer to install the tool

  Once the test tool is installed, open the test tool and you should see the landing page of the tool look something similar to what is shown below:
  
  ![image](https://github.com/user-attachments/assets/7d3b9636-7e9f-48db-83e3-a6c1561541e5)

  
 

Now that your environment is setup, [let's build some actions](./3-build-actions.md)
